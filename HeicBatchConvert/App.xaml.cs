using System.Windows;
using HeicBatchConvert.Application;
using HeicBatchConvert.Infrastructure;
using Unity;

namespace HeicBatchConvert;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App
{
    private readonly IUnityContainer _container = new UnityContainer();
    
    protected override void OnStartup(StartupEventArgs e)
    {
        RegisterDependencies();
        base.OnStartup(e);
    }

    protected override void OnActivated(EventArgs e)
    {
        base.OnActivated(e);
        MainWindow.DataContext ??= _container.Resolve<MainWindowViewModel>();
    }

    private void RegisterDependencies()
    {
        _container.RegisterType<IFileConverter, ImageMagickFileConverter>();
        _container.RegisterType<IDirectoryLister, DirectoryLister>();
        _container.RegisterType<IConvertFilesCommand, ConvertFilesCommand>();
        _container.RegisterType<IListFilesQuery, ListFilesQuery>();
    }
}