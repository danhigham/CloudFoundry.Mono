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
 
