using System.Collections.Generic;

namespace MCViewer.Api.Interfaces
{
    public interface IMCViewerRequest
    {
        string CancelUrl { get; set; }
        IMCViewerRequestContent Content { get; set; }
        bool DisableAnimation { get; set; }
        List<IDisplayProperty> DisplayProperties { get; set; }
        string HookUrl { get; set; }
        string LanguageCode { get; set; }
        string Reference { get; set; }
        MCViewerStyle Style { get; set; }
    }
}