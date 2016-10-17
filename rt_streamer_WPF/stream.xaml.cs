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
            comboBox1.SelectedIndex = 4;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog findpage = new OpenFileDialog();
            findpage.Filter = "Rooster Teeth web page|*.html;*.htm";
            findpage.FilterIndex = 1;
            if (findpage.ShowDialog() == true)
            {
                if (!string.IsNullOrEmpty(findpage.FileName) && File.Exists(findpage.FileName))
                {
                    textBox2.Text = "";
                    textBox2.Text = findpage.FileName;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StreamExtract.LoadProgram(comboBox1.Text, textBox1.Text, textBox2.Text, textBox3.Text, false, download_to.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            StreamExtract.LoadProgram(comboBox1.Text, textBox1.Text, textBox2.Text, textBox3.Text, true, download_to.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog findpage = new SaveFileDialog();
            findpage.Filter = "Video file | *.mp4";
            findpage.FilterIndex = 1;
            if (findpage.ShowDialog() == true)
            {
                if (!string.IsNullOrEmpty(findpage.FileName))
                {
                    download_to.Text = "";
                    download_to.Text = findpage.FileName;
                }
            }
        }

    }
}
