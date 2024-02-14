using HeicBatchConvert.Core;

namespace HeicBatchConvert.Application;

public interface IConvertFilesCommand
{
    Task ConvertFiles(IEnumerable<FileToConvert> files, Action<float> progressUpdated);
}