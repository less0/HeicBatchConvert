using HeicBatchConvert.Core;

namespace HeicBatchConvert.Application;

public class ConvertFilesCommand(IFileConverter fileConverter) : IConvertFilesCommand
{
    public async Task ConvertFiles(IEnumerable<FileToConvert> files, Action<float> progressUpdated)
    {
        var filesToConvert = files.Where(f => f.IsSelected).ToArray();

        Progress progress = new(filesToConvert.Length);
        progressUpdated(progress.Value);

        foreach (var file in filesToConvert)
        {
            await fileConverter.ConvertFile(file);
            progress.NumberOfFilesConverted++;
            progressUpdated(progress.Value);
        }
    }
}