using HeicBatchConvert.Core;

namespace HeicBatchConvert.Application;

public interface IFileConverter
{
    Task ConvertFile(FileToConvert file);
}