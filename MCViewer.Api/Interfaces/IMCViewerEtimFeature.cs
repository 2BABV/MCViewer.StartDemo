namespace MCViewer.Api.Interfaces
{
    public interface IMCViewerEtimFeature
    {
        string AlphaNumericValue { get; set; }
        string FeatureId { get; set; }
        bool? LogicalValue { get; set; }
        decimal? NumericValue { get; set; }
        int? Portcode { get; set; }
        decimal? RangeLowerValue { get; set; }
        decimal? RangeUpperValue { get; set; }
    }
}