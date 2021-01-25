using MCViewer.Api;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MCViewer.Demo
{
	class Program
	{
		static async Task Main(string[] args)
		{
			var serviceProdiver = GetServiceProvider();

			// Get the MCViewerClient from the service provider
			var mcClient = serviceProdiver.GetService<MCViewerClient>();

			// Create a payload
			var payload = new MCViewerRequest()
			{
				HookUrl = "https://www.2ba.nl",
				LanguageCode = "NL",
				Content = new MCViewerRequestContent()
				{
					ClassId = "MC000043",
					Features = new List<MCViewerEtimFeature>
					{
						new MCViewerEtimFeature
						{
							FeatureId = "EF010527",
							Portcode= 2,
							NumericValue= 89,
							LogicalValue= null,
							RangeLowerValue= null,
							RangeUpperValue= null,
							AlphaNumericValue= null
						}
					}
					/* And more... */
				}
			};

			Console.WriteLine("Posting to MCViewer with parameters: ");
			Console.WriteLine(JsonConvert.SerializeObject(payload, Formatting.Indented));


			var response = await mcClient.RequestAsync(payload);

			Console.WriteLine("Response from MCViewer received: ");
			Console.WriteLine(JsonConvert.SerializeObject(response, Formatting.Indented));

			Console.WriteLine($"Opening {response.ViewUrl} in default browser over 2 seconds...");
			await Task.Delay(2000);
			System.Diagnostics.Process.Start(new ProcessStartInfo(response.ViewUrl.ToString()) { UseShellExecute = true });

			Console.WriteLine();
			Console.WriteLine();
		}

		private static IServiceProvider GetServiceProvider()
		{
			var serviceProvider = new ServiceCollection()
				.AddMCViewer(new Uri("https://mc.alpha.2ba.nl")); // register MCViewerClient with DependancyInjection

			return serviceProvider.BuildServiceProvider();
		}
	}
}
