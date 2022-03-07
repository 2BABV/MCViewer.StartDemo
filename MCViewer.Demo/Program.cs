using MCViewer.Api;
using MCViewer.Api.Interfaces;
using MCViewer.Api.Extensions;
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
			var mcClient = serviceProdiver.GetService<IMCViewerClient>();

			// Create a payload
			var payload = new MCViewerRequest()
			{
				HookUrl = "https://www.2ba.nl",
				LanguageCode = "NL",
				Style = MCViewerStyle.UOL,
				Content = new MCViewerRequestContent()
				{
					ClassId = "MC000043",
					Features = new List<IMCViewerEtimFeature>
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
					},
					Reference = new
					{
						This = "can be any object",
						You = "would like it to be.",
						As = "long as it is json-seralizable.",
						We = "recommend to store a token",
						In = "here, either as string",
						Or = "as object (this example is an object)",
						Good = "luck!"
					}
				},
				DisplayProperties = new List<IDisplayProperty>()
				{
					new DisplayProperty
					{
						Name = "Productomschrijving",
						Value = "Demo product voor MC-Viewer",
						SortOrder = 1
					},
					new DisplayProperty
					{
						Name = "Productcode",
						Value = "prod.code.demo",
						SortOrder = 2
					}
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
				//.AddMCViewer(new Uri("https://localhost:44395")); // register MCViewerClient with DependancyInjection

			return serviceProvider.BuildServiceProvider();
		}
	}
}
