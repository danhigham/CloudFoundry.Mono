using System;
using System.Runtime.Serialization;

namespace CloudFoundry.Mono.Models
{
	[DataContract]
	public class ApplicationLimits
	{
		[DataMember]
		public int Mem;

		[DataMember]
		public int Disk;

		[DataMember]
		public int Fds;
	}
}

