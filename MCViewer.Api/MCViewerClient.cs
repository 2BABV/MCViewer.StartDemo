using MCViewer.Api.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace MCViewer.Api
{
    public class MCViewerClient : IMCViewerClient
    {
        private readonly HttpClient _httpClient;

        public MCViewerClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async System.Threading.Tasks.Task<MCViewerResponse> RequestAsync(MCViewerRequest request)
        {
            if (request is null)
            {
                throw new ArgumentNullException("Request cannot be null.");
            }

            if (request.DisplayProperties != null && request.DisplayProperties.Count > 8)
            {
                throw new ArgumentException($"DisplayProperties may not contain more than 8 entries.");
            }

            // Create a json string from the request
            var payload = JsonConvert.SerializeObject(request);
            HttpResponseMessage response;
            using (var msg = new HttpRequestMessage(HttpMethod.Post, "ApiService/GetViewCodeFromInputFromBody"))
            {
                // Add payload to message
                msg.Content = new StringContent(payload, Encoding.UTF8, "application/json");

                // Send the request
                response = await _httpClient.SendAsync(msg);
            }

            // Fail if statuscode is not 2xx
            response.EnsureSuccessStatusCode();
            var contentStr = await response.Content.ReadAsStringAsync();

            // Deserialize the response
            var responseObject = JsonConvert.DeserializeObject<MCViewerResponse>(contentStr);

            // Set the viewer url which the caller can open it in the browser.
            var b = new UriBuilder(_httpClient.BaseAddress)
            {
                Path = $"{request.LanguageCode ?? "NL"}/View/{responseObject.ViewCode}"
            };

            responseObject.ViewUrl = b.Uri;

            return responseObject;
        }
    }
}
