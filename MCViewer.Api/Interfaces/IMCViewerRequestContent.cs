using System.Collections.Generic;

namespace MCViewer.Api.Interfaces
{
    public interface IMCViewerRequestContent
    {
        string ClassId { get; set; }
        List<IMCViewerEtimFeature> Features { get; set; }
        object Reference { get; set; }
    }
}