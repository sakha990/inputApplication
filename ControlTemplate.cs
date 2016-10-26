using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace inputApplication
{
    public class ControlTemplate
    {
        [JsonProperty("display")]
        public string Display { get; set; }

        [JsonProperty("controltype")]
        public string ControlType { get; set; }

        [JsonProperty("id")]
        public string ID { get; set; }

        [JsonProperty("propertyName")]
        public string PropertyName { get; set; }

        [JsonProperty("required")]
        public bool Required { get; set; }

        [JsonProperty("units")]
        public string Units { get; set; }

        [JsonProperty("multiline")]
        public bool Multiline { get; set; }

        [JsonProperty("datatype")]
        public string DataType { get; set; }

        public ControlTemplate()
        {

            Multiline = false;
            Required = false;
            DataType = "text";
        }

    }
}
