using Microsoft.AspNetCore.Components;

namespace CobolStudioGui.Services;

public class ApiConfig
{
    private readonly NavigationManager _nav;

    public ApiConfig(NavigationManager nav)
    {
        _nav = nav;
    }

    public string BaseUrl
    {
        get
        {
            var host = new Uri(_nav.BaseUri).Host;
            return host == "localhost"
                ? "http://localhost:5000"
                : "https://cobol-ai-studio-d0c7533a4035.herokuapp.com";
        }
    }
}
