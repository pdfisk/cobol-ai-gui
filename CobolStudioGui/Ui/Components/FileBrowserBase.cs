using Microsoft.AspNetCore.Components;

namespace CobolStudioGui.Ui.Components;

public abstract class FileBrowserBase : ComponentBase
{
    protected abstract string Title { get; }

    protected string? SelectedFile { get; set; }
    protected string FileContent { get; set; } = string.Empty;
    protected List<string> Files { get; set; } = new();

    protected void SelectFile(string? file)
    {
        SelectedFile = file;
        FileContent = file is not null ? LoadContent(file) : string.Empty;
    }

    protected virtual string LoadContent(string file) => string.Empty;
}
