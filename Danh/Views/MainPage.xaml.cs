using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using Danh.Items;
using Danh.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Imaging;
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
        VideoItems.Add(new VideoItem() { VideoName = "Ngày Mai Em Đi Mất", Chanel = "Lofi Music", Views = "10N lượt xem", Time = "1 ngày trước" });
        VideoItems.Add(new VideoItem() { VideoName = "Lại Nhớ Em Rồi", Chanel = "Lofi Music", Views = "100N lượt xem", Time = "10 ngày trước" });
        VideoItems.Add(new VideoItem() { VideoName = "Đơn Giản Anh Yêu Em", Chanel = "Lofi Music", Views = "10Tr lượt xem", Time = "13 ngày trước" });
        VideoItems.Add(new VideoItem() { VideoName = "Điệp Khúc Chia Tay", Chanel = "Lofi Music", Views = "100N lượt xem", Time = "17 ngày trước" });

    PropertyChanged?.Invoke(this, new(nameof(VideoItems)));
    }
}
