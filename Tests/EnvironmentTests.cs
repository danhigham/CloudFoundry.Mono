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


		}

		[Test()]
		// 
		public void ProvisionedServicesIsAList()
		{
			var services = Environment.ProvisionedServices ();
			Assert.IsInstanceOf<List<Service>> (services);

			var service = services.Find (e => e.Name == "service-ab123");

			Assert.IsNotNull (service);
			Assert.AreEqual (service.Label, "service-n/a");

			Assert.IsInstanceOf<ServiceCredential> (service.Credentials);

			Assert.AreEqual (service.Credentials.JDBCUrl, "jdbc:mysql://db_username:db_password@somedatabase.com:3306/database_name");
		}
	}
}

