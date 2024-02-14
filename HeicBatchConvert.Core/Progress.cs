namespace HeicBatchConvert.Core;

public class Progress(int numberOfFilesToConvert)
{
    private int NumberOfFilesToConvert { get; } = numberOfFilesToConvert;
    public int NumberOfFilesConverted { get; set; } = 0;
    
    public float Value => NumberOfFilesConverted / (float)NumberOfFilesToConvert;
}