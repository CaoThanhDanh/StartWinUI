using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danh.Items
{
    class VideoItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public string VideoName
        {
            get; set;
        }
        public string Chanel
        {
            get; set;
        }
        public string Views
        {
            get; set;
        }
        public string Time
        {
            get; set;
        }

    }
}
