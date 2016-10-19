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
using System.Windows.Shapes;

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
            Close();
        }
    }
}
