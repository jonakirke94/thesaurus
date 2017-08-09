using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Ordbog.Models.Lemmas
{
    public class Metadata
    {

        [JsonProperty("limit")]
        public int Limit { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("offset")]
        public int Offset { get; set; }

        [JsonProperty("provider")]
        public string Provider { get; set; }

        [JsonProperty("sourceLanguage")]
        public string SourceLanguage { get; set; }
    }

    public class Result
    {

        [JsonProperty("inflection_id")]
        public string InflectionId { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("matchString")]
        public string MatchString { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("matchType")]
        public string MatchType { get; set; }

        [JsonProperty("word")]
        public string Word { get; set; }
    }

    public class LemmaResponse
    {

        [JsonProperty("metadata")]
        public Metadata Metadata { get; set; }

        [JsonProperty("results")]
        public IList<Result> Results { get; set; }
    }
}
