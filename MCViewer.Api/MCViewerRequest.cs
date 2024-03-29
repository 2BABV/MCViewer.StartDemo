﻿using MCViewer.Api.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;

namespace MCViewer.Api
{
    public class MCViewerRequest : IMCViewerRequest
    {
        /// <summary>
        /// Gets or sets the HookUrl.
        /// This URL is used to do a post-back when finishing editing.
        /// </summary>
        [JsonProperty("HookUrl")]
        public string HookUrl { get; set; }

        /// <summary>
        /// Gets or sets the LanguageCode
        /// This will set the language in the viewer
        /// </summary>
        [JsonProperty("LanguageCode")]
        public string LanguageCode { get; set; }

        /// <summary>
        /// Gets or sets the CancelUrl.
        /// This URL will be called when the user whiches to leave the viewer via the "cancel" button.
        /// </summary>
        [JsonProperty("CancelUrl")]
        public string CancelUrl { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether or not to disable animations.
        /// It is recomended to set this bool to true when using Internet Explorer, or on slower machiens.
        /// </summary>
        [JsonProperty("DisableAnimation")]
        public bool DisableAnimation { get; set; }

        /// <summary>
        /// Gets or sets the Reference.
        /// This value is passed back when posting back to the HookUrl.
        /// </summary>
        [JsonProperty("Reference")]
        public string Reference { get; set; }

        /// <summary>
        /// Gets or sets the Content ("json" property in the request).
        /// </summary>
        [JsonProperty("Content")]
        public IMCViewerRequestContent Content { get; set; }

        [JsonProperty("Style")]
        [JsonConverter(typeof(StringEnumConverter))]
        public MCViewerStyle Style { get; set; }

        [JsonProperty("DisplayProperties")]
        public List<IDisplayProperty> DisplayProperties { get; set; }
    }
}
