# RT-Streamer-WPF
The RT streamer updated to WPF

This is a program, designed to play and download videos from the Rooster Teeth website, it is built in C# and uses an MIT license

This program has been updated to run on WPF (From Winforms) as well as have a clean up of the code, reducing redundency of code by 3x in some cases!

NOTE: This program requires VLC and FFmpeg to work unless you really like to watch RT videos in a small web browser window. VLC is used to stream videos and FFmpeg is used to download videos, I would like to change this in the future to just run off of one program (Probably VLC) but for now it is how it is. Before you do anything, you will need to link to them though the options menu  because the program cannot magically find them (Unless they are in a spersific folder but that is more for a bundle if anyone wants to make something like that)

While I consider this 'complete' there is still one major issue, there is no way to load FIRST or member only videos from a url (with a working username and password) and if anyone knows how to fix this, make a pull request or contact me because this is the only real problem I have to fix (As far as I know this is the only real problem with the program functionally, doing it though the web browser (as long as you log in) does work fine)

#Instructions of use

After linking to the VLC and FFmpeg executable, you can use the Stream button (Only reccomended if the other method doesn't work) to download or stream a video though 3 methods.
1) Get the video id (Explained in the program) by looking at the video page source
2) Save the HTML page and load it in the program, this is what I think of as the best method, it's the easist way that allows for any restricted videos to be viewed currently
3) Use the page URL, this is the easiest method but ant restricted videos will not currently work as I cannot find any way to get logging in working (And I have spent plenty of time on it)

Alternatively, you can use the web browser (Highly reccomended by me), while this is very easy to use, it may have slowdown issues on weaker hardware and will not work quickly however, it will be able to stream any video you have access to as long as you login (The program does not keep login details, it is done though the web browser control which is just an Internet Explorer window (And you can see for yourself if you're really worried))

After this, you can pick the quality (Note that on older videos, 360p videos will go to 480p because there is no 360p) and where to download to if you are going to download and after a few moments (Dependent on the system and sometimes the internet connection) either VLC or FFmpeg will load and you should be able to get the RT content

TODO:
Make an icon for the program
Allow FIRST videos to be played though the stream menu
Port to GTK# for Linux users
