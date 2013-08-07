//	VCAP_SERVICES={"cleardb-n/a":[{"name":"cleardb-4fddc","label":"cleardb-n/a","tags":[],"plan":"spark","credentials":{"jdbcUrl":"jdbc:mysql://b5ae74fdb3e19d:d38ec28e@us-cdbr-east-04.cleardb.com:3306/ad_a6f52a023ac7f7f","uri":"mysql://b5ae74fdb3e19d:d38ec28e@us-cdbr-east-04.cleardb.com:3306/ad_a6f52a023ac7f7f?reconnect=true","name":"ad_a6f52a023ac7f7f","hostname":"us-cdbr-east-04.cleardb.com","port":"3306","username":"b5ae74fdb3e19d","password":"d38ec28e"}}]}

using System;
using System.Runtime.Serialization;

namespace CloudFoundry.Mono.Models
{
	[DataContract]
	public class ServiceCredential
	{
		[DataMember]
		public String JDBCUrl;

		[DataMember]
		public String URI;

		[DataMember]
		public String Hostname;

		[DataMember]
		public String Port;

		[DataMember]
		public String Username;
	
		[DataMember]
		public String Password;
	}
}

