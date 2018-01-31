using System;
using Nancy.Hosting.Self;

namespace Nancy.Simple
{
	class App
	{
		const string StagingPort = "8080";

		static readonly string PORT = Environment.GetEnvironmentVariable ("PORT");

		static NancyHost Host;

		enum Env { Staging, Deployment }

		static string BindHost
		{
			get
			{
				return PORT == null ? "127.0.0.1" : "0.0.0.0";
			}
		}

		static string BindPort {
			get {
				return PORT == null ? "8080" : PORT;
			}
		}

		static Uri BindAddress {
			get {
				return new Uri (String.Format("http://{0}:{1}", BindHost, BindPort));
			}
		}

		static void Main (string[] args)
		{
			Host = new NancyHost (BindAddress);
			Host.Start ();
			Console.WriteLine ("Nancy is started and listening on {0}...", BindAddress);
			while (Console.ReadLine () != "quit");
			Host.Stop ();
		}
	}
}
