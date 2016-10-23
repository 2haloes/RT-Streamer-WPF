using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Windows;

namespace rt_streamer_WPF
{
    class StreamExtract
    {
        /// <summary>
        /// Check weather the URL is of the old or the new format (There is a difference)
        /// The 'new' videos contain NewHLS- in the URL
        /// </summary>
        public static string OldOrNew(string id, string Quality)
        {
            string webpage = id;
            string playfile = "http://wpc.1765A.taucdn.net/801765A/video/uploads/videos/" + webpage + "/NewHLS-" + Quality + "P.m3u8";

            // If someone knows how to try not to force a crash to check the URL, please suggest an improvement
            try
            {
                WebClient downloader = new WebClient();
                downloader.DownloadFile(playfile, "test.m3u8");
            }
            catch (WebException)
            {
                if (Quality == "360")
                {
                    playfile = playfile.Replace("NewHLS-360", "480");
                }
                else
                {
                    playfile = playfile.Replace("NewHLS-" + Quality, Quality);
                }
            }
            playfile = playfile.Insert(4, "s");
            return playfile;
        }

        /// <summary>
        /// Find the video ID within a page if a URL or a HTML file were selected
        /// I can't find a way to log in though C#,current workaround uses the web browser
        /// </summary>
        /// <param name="fullpage"></param>
        /// <returns></returns>
        public static string findid(string fullpage, string pageurl)
        {
            string webpage = fullpage;
            int checkchar = 0;
            checkchar = webpage.IndexOf("file: ");
            if (checkchar == -1)
            {
                MessageBox.Show("The webpage you have input is invalid. It either isn't a rooster teeth page or it is for (first) members only. This doesn't let you bypass those requirements and you should sign up if you REALLY want that content");
                return "";
            }
            checkchar = checkchar + 64;
            webpage = webpage.Remove(0, checkchar);
            webpage = webpage.Remove(webpage.IndexOf('/'));
            return webpage;
        }

        /// <summary>
        /// Loads FFmpeg or VLC, depending on what button is clicked
        /// </summary>
        /// <param name="Quality"></param>
        /// <param name="VideoID"></param>
        /// <param name="HTMLPage"></param>
        /// <param name="PageURL"></param>
        /// <param name="ffmpeg_bool"></param>
        /// <param name="file_name"></param>
        public static void LoadProgram(string Quality, string VideoID, string HTMLPage, string PageURL, bool ffmpeg_bool, string file_name)
        {
            //Text box 1 filled
            if (HTMLPage == "" && PageURL == "")
            {
                string playfile = OldOrNew(VideoID, Quality);
                if (ffmpeg_bool)
                {
                    Process ffmpeg_start = new Process();
                    ffmpeg_start.StartInfo.FileName = Properties.Settings.Default.FFmpeg;
                    ffmpeg_start.StartInfo.Arguments = "-i " + playfile + " -c:v copy -c:a copy -f mpegts " + file_name;
                    ffmpeg_start.Start();
                    ffmpeg_start.WaitForExit();
                }
                else
                {
                    Process.Start(Properties.Settings.Default.VLC, " -vvv " + playfile + " --play-and-exit");
                }
                return;
            }
            //Text box 2 filled
            else if (VideoID == "" && PageURL == "")
            {
                string webpage = File.ReadAllText(HTMLPage);
                webpage = findid(webpage, null);
                string playfile = OldOrNew(webpage, Quality);
                if (ffmpeg_bool)
                {
                    Process ffmpeg_start = new Process();
                    ffmpeg_start.StartInfo.FileName = Properties.Settings.Default.FFmpeg;
                    ffmpeg_start.StartInfo.Arguments = "-i " + playfile + " -c:v copy -c:a copy -f mpegts " + file_name;
                    ffmpeg_start.Start();
                    ffmpeg_start.WaitForExit();
                }
                else
                {
                    Process.Start(Properties.Settings.Default.VLC, " -vvv " + playfile + " --play-and-exit");
                }
                return;
            }
            //Text box 3 filled
            else if (VideoID == "" && HTMLPage == "")
            {
                string webpage = null;
                using (var wc = new System.Net.WebClient())
                {
                    webpage = wc.DownloadString(PageURL);
                }
                webpage = findid(webpage, PageURL);
                string playfile = OldOrNew(webpage, Quality);

                if (ffmpeg_bool)
                {
                    Process ffmpeg_start = new Process();
                    ffmpeg_start.StartInfo.FileName = Properties.Settings.Default.FFmpeg;
                    ffmpeg_start.StartInfo.Arguments = "-i " + playfile + " -c:v copy -c:a copy -f mpegts " + file_name;
                    ffmpeg_start.Start();
                    ffmpeg_start.WaitForExit();
                }
                else
                {
                    Process.Start(Properties.Settings.Default.VLC, " -vvv " + playfile + " --play-and-exit");
                }

                return;
            }
            else
            {
                MessageBox.Show("Please only enter a value into one textbox");
            }
        }

        /// <summary>
        /// Loads from the browser, defaults loading from a HTML page
        /// Allows loading of FIRST member content though the browser (As long as the user logs into the inbuilt browser)
        /// </summary>
        /// <param name="HTMLPage"></param>
        /// <param name="Quality"></param>
        /// <param name="ffmpeg_bool"></param>
        /// <param name="file_name"></param>
        public static void LoadFromBrowser(string HTMLPage, string Quality, bool ffmpeg_bool, string file_name)
        {
            string webpage = HTMLPage;
            webpage = findid(webpage, null);
            string playfile = OldOrNew(webpage, Quality);

            if (ffmpeg_bool)
            {
                Process ffmpeg_start = new Process();
                ffmpeg_start.StartInfo.FileName = Properties.Settings.Default.FFmpeg;
                ffmpeg_start.StartInfo.Arguments = "-i " + playfile + " -c:v copy -c:a copy -f mpegts " + file_name;
                ffmpeg_start.Start();
                ffmpeg_start.WaitForExit();
            }
            else
            {
                Process.Start(Properties.Settings.Default.VLC, " -vvv " + playfile + " --play-and-exit");
            }

            return;
        }
    }
}