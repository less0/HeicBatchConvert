using HeicBatchConvert.Application;

namespace HeicBatchConvert.Infrastructure;

public class DirectoryLister : IDirectoryLister
{
    public string[] ListFiles(string directory) => Directory.GetFiles(directory, "*.heic");
}