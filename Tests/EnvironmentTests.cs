using System;
using System.Data.Linq;
using System.Collections.Generic;
using CloudFoundry.Mono;
using CloudFoundry.Mono.Models;
using NUnit.Framework;

namespace CloudFoundry.Mono.Tests
{
	[TestFixture()]
	//Tests for CF Environmental variables
	public class EnvironmentTests
	{

		[TestFixtureSetUp()]
		public void SetUp()
		{
			System.Environment.SetEnvironmentVariable (
				"VCAP_SERVICES",
				"{\"service-n/a\":[{\"name\":\"service-ab123\",\"label\":\"service-n/a\",\"tags\":[],\"plan\":\"entry\",\"credentials\":{\"jdbcUrl\":\"jdbc:mysql://db_username:db_password@somedatabase.com:3306/database_name\",\"uri\":\"mysql://db_username:db_password@somedatabase.com:3306/database_name?reconnect=true\",\"name\":\"database_name\",\"hostname\":\"somedatabase.com\",\"port\":\"3306\",\"username\":\"db_username\",\"password\":\"db_password\"}}]}"
			);

			System.Environment.SetEnvironmentVariable (
				"VCAP_APPLICATION",
				"{\"application_users\":[],\"instance_id\":\"d26ccab0b80e86cd3f29ca7019dc86d1\",\"instance_index\":0,\"application_version\":\"511a675f-7bac-42b0-982c-608ab7d4c674\",\"application_name\":\"nancy-hello-world\",\"application_uris\":[\"nancy-hello-world.cfapps.io\"],\"started_at\":\"2013-08-07 09:55:36 +0000\",\"started_at_timestamp\":1375869336,\"host\":\"0.0.0.0\",\"port\":64447,\"limits\":{\"mem\":512,\"disk\":1024,\"fds\":16384},\"version\":\"511a675f-7bac-42b0-982c-608ab7d4c674\",\"name\":\"nancy-hello-world\",\"uris\":[\"nancy-hello-world.cfapps.io\"],\"users\":[],\"start\":\"2013-08-07 09:55:36 +0000\",\"state_timestamp\":1375869336}"
			);
		}

		[Test()]
		// 
		public void ProvisionedServices()
		{
			var services = Environment.ProvisionedServices ();
			Assert.IsInstanceOf<List<Service>> (services);

			var service = services.Find (e => e.Name == "service-ab123");

			Assert.IsNotNull (service);
			Assert.AreEqual (service.Label, "service-n/a");

			Assert.IsInstanceOf<ServiceCredential> (service.Credentials);

			Assert.AreEqual (service.Credentials.JDBCUrl, "jdbc:mysql://db_username:db_password@somedatabase.com:3306/database_name");
		}

		[Test()]
		//
		public void Application()
		{
			var app = Environment.Application ();
			Assert.IsInstanceOf<String>(app.InstanceId);
			Assert.AreEqual (app.InstanceId, "d26ccab0b80e86cd3f29ca7019dc86d1");

			Assert.IsInstanceOf<String[]> (app.URIs);
		}
	}
}

