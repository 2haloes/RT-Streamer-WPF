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
            // This takes the paths for VLC and FFmpeg and puts them in the textboxes
            VLCtextBox.Text = Properties.Settings.Default.VLC;
            FFmpegtextBox.Text = Properties.Settings.Default.FFmpeg;
        }

        /// <summary>
        /// This saves the settings for VLC and FFmpeg and changes the text of an invisable label
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.VLC = VLCtextBox.Text;
            Properties.Settings.Default.FFmpeg = FFmpegtextBox.Text;
            Properties.Settings.Default.Save();
            SaveConfirmLabel.Content = "Saved";
        }

        /// <summary>
        /// When clicked, it opens a file dialog that allows the user to find and select VLC
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// When clicked, it opens a file dialog that allows the user to find and select FFmpeg
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Resets the settings within the program 
        /// (Does not effect the browser window)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Reset();
            ResetConfirmLabel.Content = "Settings reset";
        }
    }
}
