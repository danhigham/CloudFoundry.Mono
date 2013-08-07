using System;
using System.Runtime.Serialization;

namespace CloudFoundry.Mono.Models
{
	[DataContract]
	public class Service
	{
		[DataMember]
		public String Name;

		[DataMember]
		public String Label;

		[DataMember]
		public String Plan;

		[DataMember]
		public String[] Tags;

		[DataMember]
		public ServiceCredential Credentials;
	}
}

