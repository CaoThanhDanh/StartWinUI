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

    public ObservableCollection<VideoItem> VideoItems { get; private set; } = new();


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
        VideoItems.Clear();
        VideoItems.Add(new VideoItem { VideoName = "Ngày Mai Em Đi Mất", Chanel = "Lofi Music", Views = "10N lượt xem", Time = "1 ngày trước" });
        VideoItems.Add(new VideoItem { VideoName = "Lại Nhớ Em Rồi", Chanel = "Lofi Music", Views = "100N lượt xem", Time = "10 ngày trước" });
        VideoItems.Add(new VideoItem { VideoName = "Đơn Giản Anh Yêu Em", Chanel = "Lofi Music", Views = "10Tr lượt xem", Time = "13 ngày trước" });
        VideoItems.Add(new VideoItem { VideoName = "Điệp Khúc Chia Tay", Chanel = "Lofi Music", Views = "100N lượt xem", Time = "17 ngày trước" });

    PropertyChanged?.Invoke(this, new(nameof(VideoItems)));
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
