using Newtonsoft.Json;
using System;

namespace MCViewer.Api
{
    public class MCViewerResponse
	{
		[JsonProperty("ViewCode")]
		public string ViewCode { get; set; }

		public Uri ViewUrl { get; set; }
	}
}
