// VCAP_APPLICATION={"application_users":[],"instance_id":"d26ccab0b80e86cd3f29ca7019dc86d1","instance_index":0,"application_version":"511a675f-7bac-42b0-982c-608ab7d4c674","application_name":"nancy-hello-world","application_uris":["nancy-hello-world.cfapps.io"],"started_at":"2013-08-07 09:55:36 +0000","started_at_timestamp":1375869336,"host":"0.0.0.0","port":64447,"limits":{"mem":512,"disk":1024,"fds":16384},"version":"511a675f-7bac-42b0-982c-608ab7d4c674","name":"nancy-hello-world","uris":["nancy-hello-world.cfapps.io"],"users":[],"start":"2013-08-07 09:55:36 +0000","state_timestamp":1375869336}

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CloudFoundry.Mono.Models
{
	[DataContract]
	public class Application
	{
		[DataMember]
		private string instance_id;
		public string InstanceId { get { return instance_id; } }

		[DataMember]
		private int instance_index;
		public int InstanceIndex { get { return instance_index; } }

		[DataMember]
		private string application_version;
		public string ApplicationVersion { get { return application_version; } }

		[DataMember]
		private string application_name;
		public string ApplicationName { get { return application_name; } }

		[DataMember]
		private string[] application_uris;
		public string[] ApplicationURIs { get { return application_uris; } }

		[DataMember]
		private string started_at;
		public string StartedAt { get { return started_at; } }

		[DataMember]
		private int started_at_timestamp;
		public int StartedAtTimestamp { get { return started_at_timestamp; } }

		[DataMember]
		public string Host;

		[DataMember]
		public string Port;

		[DataMember]
		public ApplicationLimits Limits;

		[DataMember]
		public string Version;

		[DataMember]
		public string Name;

		[DataMember]
		public string[] URIs;

		[DataMember]
		public string Start;

		[DataMember]
		private int state_timestamp;
		public int StateTimestamp { get { return state_timestamp; } }

		public Uri[] getFullUris() {

			List<Uri> uriList = new List<Uri> ();

			foreach (string uri in URIs)
				uriList.Add (new Uri ("http://" + uri + ":" + Port));

			return uriList.ToArray ();
		}

	}
}
 
