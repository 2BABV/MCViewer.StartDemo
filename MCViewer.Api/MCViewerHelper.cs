using MCViewer.Api.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MCViewer.Api
{
    public static class MCViewerHelper
	{
		public static IServiceCollection AddMCViewer(this IServiceCollection serviceCollection, Uri mcviewerBaseAddress)
		{
			serviceCollection.AddHttpClient<IMCViewerClient, MCViewerClient>(c =>
			{
				c.BaseAddress = mcviewerBaseAddress;
			});

			return serviceCollection;
		}
	}
}
