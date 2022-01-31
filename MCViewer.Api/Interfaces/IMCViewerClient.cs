using System.Threading.Tasks;

namespace MCViewer.Api.Interfaces
{
    public interface IMCViewerClient
    {
        Task<MCViewerResponse> RequestAsync(MCViewerRequest request);
    }
}