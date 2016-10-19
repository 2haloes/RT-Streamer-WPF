using Microsoft.Win32;
using System;
using System.Windows;

namespace rt_streamer_WPF
{
    /// <summary>
    /// Interaction logic for options.xaml
    /// </summary>
    public partial class options : Window
    {
        public options()
        {
            InitializeComponent();
            VLCtextBox.Text = Properties.Settings.Default.VLC;
            FFmpegtextBox.Text = Properties.Settings.Default.FFmpeg;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.VLC = VLCtextBox.Text;
            Properties.Settings.Default.FFmpeg = FFmpegtextBox.Text;
            Properties.Settings.Default.Save();
            SaveConfirmLabel.Content = "Saved";
        }

        private void VLCOpenButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog VLCFindFile = new OpenFileDialog();
            VLCFindFile.Filter = "VLC exe | *.exe";
            VLCFindFile.FilterIndex = 1;
            if (VLCFindFile.ShowDialog() == true)
            {
                VLCtextBox.Text = VLCFindFile.FileName;
            }
        }

        private void FFmpegOpenButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog FFmpegFindFile = new OpenFileDialog();
            FFmpegFindFile.Filter = "FFmpeg exe | *.exe";
            FFmpegFindFile.FilterIndex = 1;
            if (FFmpegFindFile.ShowDialog() == true)
            {
                FFmpegtextBox.Text = FFmpegFindFile.FileName;
            }
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Reset();
            ResetConfirmLabel.Content = "Settings reset";
        }
    }
}
