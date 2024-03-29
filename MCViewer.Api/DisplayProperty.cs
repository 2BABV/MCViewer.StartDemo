﻿using MCViewer.Api.Interfaces;
using Newtonsoft.Json;

namespace MCViewer.Api
{
    public class DisplayProperty : IDisplayProperty
    {
        public DisplayProperty()
        {
        }

        public DisplayProperty(string name, string value, int sortOrder)
        {
            Name = name;
            Value = value;
            SortOrder = sortOrder;
        }

        public DisplayProperty(string name, string value)
        {
            Name = name;
            Value = value;
        }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Value")]
        public string Value { get; set; }

        [JsonProperty("SortOrder")]
        public int SortOrder { get; set; }
    }
}
