using Newtonsoft.Json;
using System.Collections.Generic;

namespace Ordbog.Models.Synonyms
{
    
public class Metadata
    {

        [JsonProperty("provider")]
        public string Provider { get; set; }
    }

    public class Antonym
    {

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }

    public class Example
    {

        [JsonProperty("text")]
        public string Text { get; set; }
    }

    public class Subsens
    {

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("synonyms")]
        public IList<Synonym> Synonyms { get; set; }

        [JsonProperty("registers")]
        public IList<string> Registers { get; set; }

        [JsonProperty("regions")]
        public IList<string> Regions { get; set; }
    }

    public class Synonym
    {

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }

    public class Sens
    {

        [JsonProperty("antonyms")]
        public IList<Antonym> Antonyms { get; set; }

        [JsonProperty("examples")]
        public IList<Example> Examples { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("subsenses")]
        public IList<Subsens> Subsenses { get; set; }

        [JsonProperty("synonyms")]
        public IList<Synonym> Synonyms { get; set; }
    }

    public class Entry
    {

        [JsonProperty("homographNumber")]
        public string HomographNumber { get; set; }

        [JsonProperty("senses")]
        public IList<Sens> Senses { get; set; }
    }

    public class LexicalEntry
    {

        [JsonProperty("entries")]
        public IList<Entry> Entries { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("lexicalCategory")]
        public string LexicalCategory { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }

    public class Result
    {

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("lexicalEntries")]
        public IList<LexicalEntry> LexicalEntries { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("word")]
        public string Word { get; set; }
    }

    public class SynAntoResponse
    {

        [JsonProperty("metadata")]
        public Metadata Metadata { get; set; }

        [JsonProperty("results")]
        public IList<Result> Results { get; set; }
    }


}