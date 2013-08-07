using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using CloudFoundry.Mono.Models;

namespace CloudFoundry.Mono
{
	public static class Environment
	{
		public static List<Service> ProvisionedServices ()
		{
			var servicesJSON = System.Environment.GetEnvironmentVariable ("VCAP_SERVICES");
			List<Service> _services = new List<Service> ();

			JsonTextReader jtr = new JsonTextReader (new StringReader(servicesJSON));
			JsonSerializer se = new JsonSerializer();
			JObject parsedData = (JObject)se.Deserialize(jtr);

			var _topLevel = parsedData.First;

			foreach (var serviceProvider in _topLevel) {
				foreach (var serviceJSON in serviceProvider)
					_services.Add(JsonConvert.DeserializeObject<Service> (serviceJSON.ToString ()));
			};

			return _services;
		}
	}
}

