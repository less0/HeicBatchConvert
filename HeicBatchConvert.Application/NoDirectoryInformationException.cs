namespace HeicBatchConvert.Application;

/// <summary>
/// Is thrown if a file path is missing directory information.
/// </summary>
public class NoDirectoryInformationException : Exception
{
    public override string Message => "File path does not contain a directory information.";
}