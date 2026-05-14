using System.Text.Json.Serialization;

namespace CobolStudioGui.Models;

public class SourceFile
{
    [JsonPropertyName("fileName")]
    public string FileName { get; set; } = string.Empty;

    [JsonPropertyName("content")]
    public string Content { get; set; } = string.Empty;
}
