using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OctoEngine.Formats
{
    public class WebsiteSection
    {
        [JsonProperty("elementId")]
        public string ElementId { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("backgroundImage")]
        public string BackgroundImage { get; set; }
        [JsonProperty("hasButton")]
        public bool HasButton { get; set; }
        [JsonProperty("buttonEnabled")]
        public bool ButtonEnabled { get; set; }
        [JsonProperty("buttonText")]
        public string ButtonText { get; set; }
        [JsonProperty("buttonLink")]
        public string ButtonLink { get; set; }
    }

    public class SectionListObject
    {
        [JsonProperty("sections")]
        public List<WebsiteSection> Sections { get; set; }
    }

    public class EventBanner
    {
        [JsonProperty("isEnabled")]
        public bool IsEnabled { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("hasButton")]
        public bool HasButton { get; set; }
        [JsonProperty("buttonLink")]
        public string ButtonLink { get; set; }
        [JsonProperty("buttonText")]
        public string ButtonText { get; set; }
    }

    public class WebsiteConfig
    {
        [JsonProperty("tagline")]
        public string Tagline { get; set; }
        [JsonProperty("aboutText")]
        public string AboutText { get; set; }
        [JsonProperty("logoUrl")]
        public string LogoURL { get; set; }
        [JsonProperty("headerBgUrl")]
        public string HeaderBgURL { get; set; }
        [JsonProperty("aboutBgUrl")]
        public string AboutBgURL { get; set; }
    }
}
