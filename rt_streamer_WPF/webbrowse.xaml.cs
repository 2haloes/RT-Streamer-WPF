using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Forms;

namespace rt_streamer_WPF
{
    /// <summary>
    /// Interaction logic for webbrowse.xaml
    /// </summary>
    public partial class webbrowse : Window
    {
        public webbrowse()
        {
            
            InitializeComponent();
            (WFH.Child as WebBrowser).ScriptErrorsSuppressed = true;
            (WFH.Child as WebBrowser).Navigate("http://www.roosterteeth.com");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            (WFH.Child as WebBrowser).GoBack();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            (WFH.Child as WebBrowser).GoForward();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            (WFH.Child as WebBrowser).Refresh();
        }


        //FFmpeg stream
        private void button4_Click(object sender, EventArgs e)
        {
            Microsoft.Win32.SaveFileDialog findpage = new Microsoft.Win32.SaveFileDialog();
            findpage.Filter = "Video file | *.mp4";
            findpage.FilterIndex = 1;
            if (findpage.ShowDialog() == true)
            {
                if (!string.IsNullOrEmpty(findpage.FileName))
                {
                    StreamExtract.LoadFromBrowser((WFH.Child as WebBrowser).DocumentText, comboBox.Text, true, findpage.FileName);
                }
            }
        }

        // VLC stream
        private void button5_Click(object sender, EventArgs e)
        {
            StreamExtract.LoadFromBrowser((WFH.Child as WebBrowser).DocumentText, comboBox.Text, false, null);
        }

        private void RTPageLoad(object sender,
        WebBrowserNavigatingEventArgs e)
        {
            try
            {
                URLBar.Text = (WFH.Child as WebBrowser).Url.ToString();
            }
            catch (Exception)
            {
                return;
            }
        }

    }
}
