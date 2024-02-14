using System.Diagnostics;
using HeicBatchConvert.Application;
using HeicBatchConvert.Core;

namespace HeicBatchConvert.Infrastructure;

public class ImageMagickFileConverter : IFileConverter
{
    public Task ConvertFile(FileToConvert file)
    {
        // TODO the converter shall not be responsible for determining the target filepath
        
        var directoryName = Path.GetDirectoryName(file.FileName) ?? throw new NoDirectoryInformationException();
        var targetFolder = Path.Combine(directoryName, "jpg");
        var targetFile = Path.ChangeExtension(Path.Combine(targetFolder, Path.GetFileName(file.FileName)), "jpg");
        
        Directory.CreateDirectory(targetFolder);
        
        var process = Process.Start(new ProcessStartInfo("magick")
        {
            Arguments = $"\"{file.FileName}\" \"{targetFile}\"",
            CreateNoWindow = true,
            UseShellExecute = false
        }) ?? throw new ImageConversionFailedException();
        return Task.Run(process.WaitForExit);
    }
}