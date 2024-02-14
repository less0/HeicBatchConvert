using System.IO;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HeicBatchConvert.Application;
using HeicBatchConvert.Core;
using Microsoft.Win32;

namespace HeicBatchConvert;

public partial class MainWindowViewModel(IConvertFilesCommand convertFilesCommand, IListFilesQuery listFilesQuery)
    : ObservableObject
{
    private string _folder = null!;

    [ObservableProperty] private bool _conversionInProgress;
    [ObservableProperty] private FileToConvert[] _filesToConvert = {};
    [ObservableProperty] private float _progress;

    public string Folder
    {
        get => _folder;
        set
        {
            if (value == _folder)
            {
                return;
            }

            _folder = value;
            OnPropertyChanged();
            OnFolderChanged();
        }
    }

    [RelayCommand]
    private void Loaded()
    {
        Folder = Directory.GetCurrentDirectory();
    }

    [RelayCommand]
    private async Task Convert()
    {
        ConversionInProgress = true;
        await convertFilesCommand.ConvertFiles(FilesToConvert, progress => Progress = progress);
        ConversionInProgress = false;
    }

    [RelayCommand]
    private void Browse()
    {
        OpenFolderDialog dialog = new OpenFolderDialog();
        if (dialog.ShowDialog() ?? false)
        {
            Folder = dialog.FolderName;
        }
    }

    private void OnFolderChanged() => FilesToConvert = listFilesQuery.ListFiles(Folder);
}