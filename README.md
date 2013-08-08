CloudFoundry.Mono
=================

A Mono / .NET runtime helper library for CloudFoundry

This library provides ease in reading variables from the CloudFoundry environment. This is most useful when binding an application to the correct port and host header and also when connecting to services bound to an application.

As an example, below is an example of creating a NancyHost and binding it to the correct address and port.

```
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using Nancy.Hosting.Self;

namespace NancyHelloWorld
{
	public class MainClass
	{
		public static void Main (string[] args)
		{
			var app = CloudFoundry.Mono.Environment.Application ();
			var uris = app.getFullUris ();
			var nancyHost = new NancyHost(uris);

			nancyHost.Start ();
			Console.WriteLine ("Nancy Listening to " + String.Join(",", uris.Select (e => e.AbsoluteUri)));

			while (1==1) {
				Thread.Sleep (10);
			}
		}
	}
}
```

Also, getting the URI for a service is as easy as;

```
var myServiceName = 'MySQLDB1';
Environment.ProvisionedServices ().Find (s => s.Name == myServiceName).Credentials.URI;
```