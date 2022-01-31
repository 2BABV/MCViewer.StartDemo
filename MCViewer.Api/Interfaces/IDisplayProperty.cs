namespace MCViewer.Api.Interfaces
{
    public interface IDisplayProperty
    {
        string Name { get; set; }
        int SortOrder { get; set; }
        string Value { get; set; }
    }
}