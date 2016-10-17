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
        /// </summary>
        public static string OldOrNew(string id, string comboBox1)
        {
            string webpage = id;
            string playfile = "http://wpc.1765A.taucdn.net/801765A/video/uploads/videos/" + webpage + "/NewHLS-" + comboBox1 + "P.m3u8";

            // If someone knows how to try not to force a crash to check the URL, please suggest an improvement
            try
            {
                WebClient downloader = new WebClient();
                downloader.DownloadFile(playfile, "test.m3u8");
            }
            catch (WebException)
            {
                if (comboBox1 == "360")
                {
                    playfile = playfile.Replace("NewHLS-360", "480");
                }
                else
                {
                    playfile = playfile.Replace("NewHLS-" + comboBox1, comboBox1);
                }
            }
            playfile = playfile.Insert(4, "s");
            return playfile;
        }

        /// <summary>
        /// Decide where to load VLC, based on if there is a setting set for VLC or not
        /// </summary>
        /// <returns></returns>
        public static string vlcfile()
        {
            string vlc = null;
            string[] file_lines = File.ReadAllLines("rtStream.conf");
            if (file_lines[0] == "")
            {
                string location = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
                vlc = location + "/vlc/vlc.exe";
            }
            else
            {
                vlc = file_lines[0];
            }
            return vlc;
        }

        /// <summary>
        /// Decide where to load FFmpeg, based on if there is a setting set for FFmpeg or not
        /// </summary>
        /// <returns></returns>
        public static string ffmpegfile()
        {
            string ffmpeg = null;
            string[] file_lines = File.ReadAllLines("rtStream.conf");
            if (file_lines[1] == "")
            {
                string location = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
                ffmpeg = location + "/ffmpeg/ffmpeg.exe";
            }
            else
            {
                ffmpeg = file_lines[1];
            }
            return ffmpeg;
        }

        /// <summary>
        /// Find the video ID within a page if a URL or a HTML file were selected
        /// Logs in if the video is for members or FIRST memebers only
        /// </summary>
        /// <param name="fullpage"></param>
        /// <returns></returns>
        public static string findid(string fullpage, string pageurl)
        {
            string webpage = fullpage;
            int checkchar = 0;
            checkchar = webpage.IndexOf("file: ");
            if (checkchar == -1 /*&& pageurl == null*/)
            {
                MessageBox.Show("The webpage you have input is invalid. It either isn't a rooster teeth page or it is for (first) members only. This doesn't let you bypass those requirements and you should sign up if you REALLY want that content");
                return "";
            }
            else
            {
                /*using (var wc = new WebClient())
                {

                    string loginpage = wc.DownloadString("https://www.roosterteeth.com/login").ToString();
                    int logincheckchar = loginpage.IndexOf("value=") + 7;
                    string tokloginpage = loginpage.Remove(0, logincheckchar);
                    tokloginpage = tokloginpage.Remove(loginpage.IndexOf('"'));
                    string[] logininfo = File.ReadAllLines("rtstream.conf");


                    NameValueCollection values = new NameValueCollection();
                    values["_token"] = tokloginpage;
                    values["username"] = logininfo[2];
                    values["password"] = logininfo[3];

                    byte[] response = wc.UploadValues("http://www.roosterteeth.com/login", "POST", values);

                    string responseString = Encoding.Default.GetString(response);

                    webpage = wc.DownloadString(pageurl);

                    checkchar = webpage.IndexOf("file: ");
                    if (checkchar == -1)
                    {
                        MessageBox.Show("The webpage you have input is invalid. It either isn't a rooster teeth page or it is for (first) members only. This doesn't let you bypass those requirements and you should sign up if you REALLY want that content");
                        return "";
                    }
                }*/
            }
            checkchar = checkchar + 64;
            webpage = webpage.Remove(0, checkchar);
            webpage = webpage.Remove(webpage.IndexOf('/'));
            return webpage;
        }

        /// <summary>
        /// Loads FFmpeg or VLC, depending on what button is clicked
        /// </summary>
        /// <param name="comboBox1"></param>
        /// <param name="textBox1"></param>
        /// <param name="textBox2"></param>
        /// <param name="textBox3"></param>
        /// <param name="ffmpeg_bool"></param>
        /// <param name="file_name"></param>
        public static void LoadProgram(string comboBox1, string textBox1, string textBox2, string textBox3, bool ffmpeg_bool, string file_name)
        {
            string quality = comboBox1;
            //Text box 1 filled
            if (textBox2 == "" && textBox3 == "")
            {
                string playfile = OldOrNew(textBox1, comboBox1);
                if (ffmpeg_bool)
                {
                    string FFmpeg = ffmpegfile();
                    Process ffmpeg_start = new Process();
                    ffmpeg_start.StartInfo.FileName = FFmpeg;
                    ffmpeg_start.StartInfo.Arguments = "-i " + playfile + " -c:v copy -c:a copy -f mpegts " + file_name;
                    ffmpeg_start.Start();
                    ffmpeg_start.WaitForExit();
                }
                else
                {
                    string vlc = vlcfile();
                    Process.Start(vlc, " -vvv " + playfile + " --play-and-exit");
                }
                return;
            }
            //Text box 2 filled
            else if (textBox1 == "" && textBox3 == "")
            {
                string webpage = File.ReadAllText(textBox2);
                webpage = findid(webpage, null);
                string playfile = OldOrNew(webpage, comboBox1);
                if (ffmpeg_bool)
                {
                    string FFmpeg = ffmpegfile();
                    Process ffmpeg_start = new Process();
                    ffmpeg_start.StartInfo.FileName = FFmpeg;
                    ffmpeg_start.StartInfo.Arguments = "-i " + playfile + " -c:v copy -c:a copy -f mpegts " + file_name;
                    ffmpeg_start.Start();
                    ffmpeg_start.WaitForExit();
                }
                else
                {
                    string vlc = vlcfile();
                    Process.Start(vlc, " -vvv " + playfile + " --play-and-exit");
                }
                return;
            }
            //Text box 3 filled
            else if (textBox1 == "" && textBox2 == "")
            {
                string webpage = null;
                using (var wc = new System.Net.WebClient())
                {
                    webpage = wc.DownloadString(textBox3);
                }
                webpage = findid(webpage, textBox3);
                string playfile = OldOrNew(webpage, comboBox1);

                if (ffmpeg_bool)
                {
                    string FFmpeg = ffmpegfile();
                    Process ffmpeg_start = new Process();
                    ffmpeg_start.StartInfo.FileName = FFmpeg;
                    ffmpeg_start.StartInfo.Arguments = "-i " + playfile + " -c:v copy -c:a copy -f mpegts " + file_name;
                    ffmpeg_start.Start();
                    ffmpeg_start.WaitForExit();
                }
                else
                {
                    string vlc = vlcfile();
                    Process.Start(vlc, " -vvv " + playfile + " --play-and-exit");
                }

                return;
            }
            else
            {
                MessageBox.Show("Please only enter a value into one textbox");
            }
        }

        public static void LoadFromBrowser(string textBox3, string comboBox1, bool ffmpeg_bool, string file_name)
        {
            string webpage = textBox3;
            webpage = findid(webpage, null);
            string playfile = OldOrNew(webpage, comboBox1);

            if (ffmpeg_bool)
            {
                string FFmpeg = ffmpegfile();
                Process ffmpeg_start = new Process();
                ffmpeg_start.StartInfo.FileName = FFmpeg;
                ffmpeg_start.StartInfo.Arguments = "-i " + playfile + " -c:v copy -c:a copy -f mpegts " + file_name;
                ffmpeg_start.Start();
                ffmpeg_start.WaitForExit();
            }
            else
            {
                string vlc = vlcfile();
                Process.Start(vlc, " -vvv " + playfile + " --play-and-exit");
            }

            return;
        }
    }
}