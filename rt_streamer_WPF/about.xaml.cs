using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for about.xaml
    /// </summary>
    public partial class about : Window
    {
        public about()
        {
            InitializeComponent();
        }

        // These methods load websites based on the default browser
        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.videolan.org/vlc/");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.ffmpeg.org");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.roosterteeth.com");
        }
    }
}
