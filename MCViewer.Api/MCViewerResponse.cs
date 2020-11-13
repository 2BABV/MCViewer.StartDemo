using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCViewer.Api
{
	public class MCViewerResponse
	{
		[JsonProperty("ViewCode")]
		public string ViewCode { get; set; }

		public Uri ViewUrl { get; set; }
	}
}
