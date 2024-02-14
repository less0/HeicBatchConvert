using HeicBatchConvert.Core;

namespace HeicBatchConvert.Application;

public interface IListFilesQuery
{
    FileToConvert[] ListFiles(string directory);
}