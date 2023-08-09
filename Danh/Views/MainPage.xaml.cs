using System.Collections.ObjectModel;
using System.ComponentModel;
using Danh.Items;
using Danh.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.WindowsAppSDK.Runtime.Packages;
using Windows.Media.Playback;

namespace Danh.Views;

internal sealed partial class MainPage : Page, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    public ObservableCollection<ImageItem> ImageItems { get; private set; } = new();


    public MainViewModel ViewModel
    {
        get;
    }


    public MainPage()
    {
        ViewModel = App.GetService<MainViewModel>();
        InitializeComponent();
        DataContext = this;
    }

    private void Page_Loaded(object sender, RoutedEventArgs e)
    {
        ImageItems.Clear();
        ImageItems.Add(new ImageItem { Title = "Image A", Weight = "100MB" });
        ImageItems.Add(new ImageItem { Title = "Image B", Weight = "100MB" });
        ImageItems.Add(new ImageItem { Title = "Image C", Weight = "100MB" });
        ImageItems.Add(new ImageItem { Title = "Image D", Weight = "100MB" });
        PropertyChanged?.Invoke(this, new(nameof(ImageItems)));
    }
    private void OptionsButton_Click(SplitButton sender, SplitButtonClickEventArgs args)
    {

    }

    private async void ShowDialog_Click(object sender, RoutedEventArgs e)
    {
        ContentDialog dialog = new ContentDialog();

        // XamlRoot must be set in the case of a ContentDialog running in a Desktop app
        dialog.XamlRoot = this.XamlRoot;
        dialog.Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style;
        dialog.Title = "Save your work?";
        dialog.PrimaryButtonText = "Save";
        dialog.SecondaryButtonText = "Don't Save";
        dialog.CloseButtonText = "Cancel";
        dialog.DefaultButton = ContentDialogButton.Primary;
        dialog.Content = new ContentDialogContent();

        var result = await dialog.ShowAsync();
    }

    private void FileGridView_ContainerContentChanging(ListViewBase sender, ContainerContentChangingEventArgs args)
    {

    }
}
