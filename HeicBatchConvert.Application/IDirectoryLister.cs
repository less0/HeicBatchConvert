namespace HeicBatchConvert.Application;

public interface IDirectoryLister
{
    string[] ListFiles(string directory);
}