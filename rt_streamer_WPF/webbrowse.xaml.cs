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
            // Forms browser is used because it can stop JS errors, this does that
            (WFH.Child as WebBrowser).ScriptErrorsSuppressed = true;
            // Loads the RT site
            (WFH.Child as WebBrowser).Navigate("http://www.roosterteeth.com");
        }
        
        /// <summary>
        /// Goes back a page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Back_Click(object sender, EventArgs e)
        {
            (WFH.Child as WebBrowser).GoBack();
        }

        /// <summary>
        /// Goes forward a page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Forward_Click(object sender, EventArgs e)
        {
            (WFH.Child as WebBrowser).GoForward();
        }

        /// <summary>
        /// Refreshes the page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Refresh_Click(object sender, EventArgs e)
        {
            (WFH.Child as WebBrowser).Refresh();
        }


        /// <summary>
        /// Opens a save file dialog to find wherre to save the video pefore loading FFmpeg
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Download_Click(object sender, EventArgs e)
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

        /// <summary>
        /// Loads VLC
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Stream_Click(object sender, EventArgs e)
        {
            StreamExtract.LoadFromBrowser((WFH.Child as WebBrowser).DocumentText, comboBox.Text, false, null);
        }

        /// <summary>
        /// When the page loads, it's put into the URL bar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
