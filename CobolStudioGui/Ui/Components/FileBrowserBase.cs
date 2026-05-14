using Microsoft.AspNetCore.Components;
using CobolStudioGui.Services;

namespace CobolStudioGui.Ui.Components;

public abstract class FileBrowserBase : ComponentBase
{
    [Inject] protected SourceFileService FileService { get; set; } = default!;

    protected abstract string Title { get; }
    protected abstract string TableName { get; }

    protected string? SelectedFile { get; set; }
    protected string FileContent { get; set; } = string.Empty;
    protected List<string> Files { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {
        Files = await FileService.GetFileNamesAsync(TableName);
    }

    protected async Task SelectFile(string? file)
    {
        SelectedFile = file;
        FileContent = file is not null
            ? await FileService.GetContentAsync(TableName, file)
            : string.Empty;
    }
}
