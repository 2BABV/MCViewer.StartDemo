using Newtonsoft.Json;

namespace MCViewer.Api
{
	public class MCViewerEtimFeature
	{
		[JsonProperty("FeatureId")]
		public string FeatureId { get; set; }

		[JsonProperty("Portcode")]
		public int? Portcode { get; set; }

		[JsonProperty("NumericValue")]
		public decimal? NumericValue { get; set; }

		[JsonProperty("LogicalValue")]
		public decimal? LogicalValue { get; set; }

		[JsonProperty("RangeLowerValue")]
		public decimal? RangeLowerValue { get; set; }

		[JsonProperty("RangeUpperValue")]
		public decimal? RangeUpperValue { get; set; }

		[JsonProperty("AlphaNumericValue")]
		public string AlphaNumericValue { get; set; }
	}
}