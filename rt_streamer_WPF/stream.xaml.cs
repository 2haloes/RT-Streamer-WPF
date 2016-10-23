using System;
using System.IO;
using System.Collections.Generic;
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
using Microsoft.Win32;
using System.Diagnostics;
using System.Net;

namespace rt_streamer_WPF
{
    /// <summary>
    /// Interaction logic for stream.xaml
    /// </summary>
    public partial class stream : Window
    {
        public stream()
        {
            InitializeComponent();
            // Defaults the quality selection to 1080p
            QualityComboBox.SelectedIndex = 4;
        }

        /// <summary>
        /// Opens a file dialog that allows the user to locate the HTML file
        /// of a page that hosts a video (As long as the user can access it within their browser)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HTMLButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog findpage = new OpenFileDialog();
            findpage.Filter = "Rooster Teeth web page|*.html;*.htm";
            findpage.FilterIndex = 1;
            if (findpage.ShowDialog() == true)
            {
                if (!string.IsNullOrEmpty(findpage.FileName) && File.Exists(findpage.FileName))
                {
                    HTMLTextBox.Text = "";
                    HTMLTextBox.Text = findpage.FileName;
                }
            }
        }

        // These 2 methods load VLC and FFmpeg respectively, true for FFmpeg and false for VLC
        private void StreamButton_Click(object sender, EventArgs e)
        {
            StreamExtract.LoadProgram(QualityComboBox.Text, VideoIDTextBox.Text, HTMLTextBox.Text, URLTextBox.Text, false, DownloadToTextBox.Text);
        }

        private void DownloadButton_Click(object sender, EventArgs e)
        {
            StreamExtract.LoadProgram(QualityComboBox.Text, VideoIDTextBox.Text, HTMLTextBox.Text, URLTextBox.Text, true, DownloadToTextBox.Text);
        }

        /// <summary>
        /// Opens a file dialog to find where to save the video file (If needed)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DownloadToButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog findpage = new SaveFileDialog();
            findpage.Filter = "Video file | *.mp4";
            findpage.FilterIndex = 1;
            if (findpage.ShowDialog() == true)
            {
                if (!string.IsNullOrEmpty(findpage.FileName))
                {
                    DownloadToTextBox.Text = "";
                    DownloadToTextBox.Text = findpage.FileName;
                }
            }
        }

    }
}
