using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace rt_streamer_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            // If the program has run then skip the first time start up
            if (Properties.Settings.Default.HasRun)
            {
                InitializeComponent();
            }
            else
            {
                MessageBox.Show("Disclaimer: I am not related to FFmpeg, VLC or Rooster Teeth, I am simply a fan of Rooster Teeth and someone who wanted to watch RT on my rubbish laptop.");

                // This allows the user to find a FFmpeg *.exe file (For downloading)
                MessageBoxResult FFmpegBoxResult = MessageBox.Show("Do you want to link to FFmpeg? This is required for downloading", "FFmpeg", MessageBoxButton.YesNo);
                if (FFmpegBoxResult == MessageBoxResult.Yes)
                {
                    OpenFileDialog FFmpegFindFile = new OpenFileDialog();
                    FFmpegFindFile.Filter = "FFmpeg exe | *.exe";
                    FFmpegFindFile.FilterIndex = 1;
                    if (FFmpegFindFile.ShowDialog() == true)
                    {
                            Properties.Settings.Default.FFmpeg = FFmpegFindFile.FileName;
                    }
                }

                // This allows the user to find a VLC *exe file (For streaming)
                MessageBoxResult VLCBoxResult = MessageBox.Show("Do you want to link to VLC? This is required for Streaming", "VLC", MessageBoxButton.YesNo);
                if (VLCBoxResult == MessageBoxResult.Yes)
                {
                    OpenFileDialog VLCFindFile = new OpenFileDialog();
                    VLCFindFile.Filter = "VLC exe | *.exe";
                    VLCFindFile.FilterIndex = 1;
                    if (VLCFindFile.ShowDialog() == true)
                    {
                        Properties.Settings.Default.VLC = VLCFindFile.FileName;
                    }
                }
                // Changes the settings so that the program doesn't run the first time setup again
                Properties.Settings.Default.HasRun = true;
                // Saves the settings so that they can be used in future
                Properties.Settings.Default.Save();
                InitializeComponent();
            }
        }

       // These methods open new windows depending on what button was clicked
       // (e.g. clicking About opens the about window)
        private void About_Click(object sender, EventArgs e)
        {
            about ab = new about();
            ab.Show();
        }

        private void Stream_Click(object sender, EventArgs e)
        {
            stream stream = new stream();
            stream.Show();
        }

        private void Options_Click(object sender, EventArgs e)
        {
            options OP = new options();
            OP.Show();
        }

        private void RTBrowser_Click(object sender, RoutedEventArgs e)
        {
            webbrowse web = new webbrowse();
            web.Show();
        }
    }
}
