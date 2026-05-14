using System.Net.Http.Json;
using CobolStudioGui.Models;

namespace CobolStudioGui.Services;

public class SourceFileService
{
    private readonly HttpClient _http;
    private readonly ApiConfig _apiConfig;


    public SourceFileService(HttpClient http, ApiConfig apiConfig)
    {
        _http = http;
        _apiConfig = apiConfig;
    }

    public async Task<List<string>> GetFileNamesAsync(string table)
    {
        var files = await _http.GetFromJsonAsync<List<SourceFile>>(
            $"{_apiConfig.BaseUrl}/{table}");
        return files?.Select(f => f.FileName).ToList() ?? new();
    }

    public async Task<string> GetContentAsync(string table, string fileName)
    {
        var file = await _http.GetFromJsonAsync<SourceFile>(
            $"{_apiConfig.BaseUrl}/{table}/{Uri.EscapeDataString(fileName)}");
        return file?.Content ?? string.Empty;
    }
}
