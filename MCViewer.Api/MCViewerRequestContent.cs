﻿using MCViewer.Api.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MCViewer.Api
{
    public class MCViewerRequestContent : IMCViewerRequestContent
    {
        /// <summary>
        /// Gets or sets the ClassId.
        /// The ClassId refers to the ETIM Modelling Class (e.g. MC000043)
        /// </summary>
        [JsonProperty("ClassId")]
        public string ClassId { get; set; }

        /// <summary>
        /// Gets or sets the list of ETIM Features.
        /// These features should be features which belong to <see cref="ClassId"/>.
        /// </summary>
        [JsonProperty("Features")]
        public List<IMCViewerEtimFeature> Features { get; set; }

        [JsonProperty("Reference")]
        public object Reference { get; set; }
    }
}