namespace HeicBatchConvert.Core;

public class FileToConvert(string fileName)
{
    public bool IsSelected { get; set; } = true;
    public string FileName { get; set; } = fileName;
}