using System;
using System.Configuration;
using System.IO;
using System.Linq;
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
			List<Service> services = new List<Service> ();

			JsonTextReader jtr = new JsonTextReader (new StringReader(servicesJSON));
			JsonSerializer se = new JsonSerializer();
			JObject parsedData = (JObject)se.Deserialize(jtr);

			var _topLevel = parsedData.First;

			foreach (var serviceProvider in _topLevel) {
				foreach (var serviceJSON in serviceProvider) {
					Service service = JsonConvert.DeserializeObject<Service> (serviceJSON.ToString ());
					services.Add (service);
					AddServiceToDotNETConfiguration (service);
				}
			};

			return services;
		}

		public static Application Application()
		{
			var applicationJSON = System.Environment.GetEnvironmentVariable ("VCAP_APPLICATION");
			return JsonConvert.DeserializeObject<Application> (applicationJSON);
		}

		private static void AddServiceToDotNETConfiguration(Service service) 
		{
			ConnectionStringSettingsCollection settings =
				ConfigurationManager.ConnectionStrings;

			if (settings[service.Name] == null) {
//			if (((IEnumerable<ConnectionStringSettings>)settings.GetEnumerator()).Where (s => s.Name == service.Name).First() == null) {
				ConnectionStringSettings setting = new ConnectionStringSettings ();
				setting.ConnectionString = "server=" + service.Credentials.Hostname + 
					";database=" + service.Credentials.DatabaseName + 
					";uid=" + service.Credentials.Username + 
					";password=" + service.Credentials.Password +
					";port=" + service.Credentials.Port;

//				setting.ProviderName = 
				setting.Name = service.Name;

				settings.Add (setting);
			}
		}
	}
}

