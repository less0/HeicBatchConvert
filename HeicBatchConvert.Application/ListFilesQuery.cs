using HeicBatchConvert.Core;

namespace HeicBatchConvert.Application;

public class ListFilesQuery(IDirectoryLister directoryLister) : IListFilesQuery
{
    public FileToConvert[] ListFiles(string directory) => directoryLister.ListFiles(directory)
        .Select(f => new FileToConvert(f))
        .ToArray();
}