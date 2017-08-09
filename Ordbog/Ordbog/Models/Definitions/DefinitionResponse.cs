using Newtonsoft.Json;
using System.Collections.Generic;

public class Metadata
{

    [JsonProperty("provider")]
    public string Provider { get; set; }
}

public class Subsens
{

    [JsonProperty("definitions")]
    public IList<string> Definitions { get; set; }

    [JsonProperty("id")]
    public string Id { get; set; }
}

public class Sens
{

    [JsonProperty("definitions")]
    public IList<string> Definitions { get; set; }

    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("subsenses")]
    public IList<Subsens> Subsenses { get; set; }
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

public class DefinitionResponse
{

    [JsonProperty("metadata")]
    public Metadata Metadata { get; set; }

    [JsonProperty("results")]
    public IList<Result> Results { get; set; }
}
