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
            if (File.Exists("rtStream.conf"))
            {
                InitializeComponent();
            }
            else
            {
                MessageBox.Show("This program on it's own is licensed MIT while VLC and FFmpeg have their own (Compatable) licenses, a copy of this license is included with the program and the source code is available upon request or available on my website. I am not related to FFmpeg, VLC or Rooster Teeth, I am simply a fan of Rooster Teeth and someone who wanted to make a nice open source project. To set up FFmpeg and VLC, use the instructions in the about page");


                string[] lines = { null, null };
                File.WriteAllLines("rtStream.conf", lines);

                InitializeComponent();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("It's a streamer, downloader and slight easter egger");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            about ab = new about();
            ab.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            stream stream = new stream();
            stream.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            options OP = new options();
            OP.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            webbrowse web = new webbrowse();
            web.Show();
        }
    }
}
