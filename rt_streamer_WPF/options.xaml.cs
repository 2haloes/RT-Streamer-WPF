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
            string[] lines = File.ReadAllLines("rtStream.conf");
            VLCtextBox.Text = lines[0];
            FFmpegtextBox.Text = lines[1];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] lines = File.ReadAllLines("rtStream.conf");
            lines[0] = VLCtextBox.Text;
            lines[1] = FFmpegtextBox.Text;
            File.WriteAllLines("rtStream.conf", lines);
            Close();
        }
    }
}
