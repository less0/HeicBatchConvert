namespace HeicBatchConvert.Application;

/// <summary>
/// Is thrown if the image conversion failed.
/// </summary>
public class ImageConversionFailedException : Exception
{
    public override string Message => "The process was not started.";
}