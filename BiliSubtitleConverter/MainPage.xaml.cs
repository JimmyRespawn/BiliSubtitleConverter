using System;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Newtonsoft.Json;
using BiliSubtitleConverter.Models;

namespace BiliSubtitleConverter
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string jsonText = InputJsonTextBox.Text;
            if(jsonText != "")
            {
                var dynObj = JsonConvert.DeserializeObject<ObservableCollection<Lines>>(jsonText);
                int i = 0;
                string convertedSrtString = "";
                foreach (var line in dynObj)
                {
                    string startTime;
                    string endTime;
                    startTime = SecondsToTime(line.from);
                    endTime = SecondsToTime(line.to);
                    convertedSrtString += ((i + 1) + "\r\n");
                    convertedSrtString += ((startTime) + " --> " + (endTime) + "\r\n");
                    convertedSrtString += ((line.content) + "\r\n\r\n");
                    ++i;
                }
                OutputJsonTextBox.Text = convertedSrtString;
            }
        }

        public string SecondsToTime(double seconds)
        {
            TimeSpan time = TimeSpan.FromSeconds(seconds);
            return time.ToString(@"hh\:mm\:ss\,fff");
        }
    }
}
