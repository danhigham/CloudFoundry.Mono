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

