using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Iris_Uploader_v2
{
    public partial class Main : Form
    {
        private void Output(string str)
        {
            vRichTextBox1.BindText(Color.FromArgb(0, 255, 255), "[");
            vRichTextBox1.BindText(Color.FromArgb(0, 255, 255), "SYSTEM");
            vRichTextBox1.BindText(Color.FromArgb(0,255,255), "]");
            vRichTextBox1.BindText(Color.FromArgb(143, 144, 145), " " + str + "\n");
        }

        private void Outputty(string str)
        {
            vRichTextBox2.BindText(Color.FromArgb(0, 255, 255), str + "\n");
        }

        static string BytesToString(long byteCount)
        {
            string[] suf = { "B", "KB", "MB", "GB", "TB", "PB", "EB" };
            if (byteCount == 0)
                return "0" + suf[0];
            long bytes = Math.Abs(byteCount);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            double num = Math.Round(bytes / Math.Pow(1024, place), 1);
            return (Math.Sign(byteCount) * num).ToString() + suf[place];
        }

        string FTPUser;
        string FTPPass;
        string DownLink;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            vRichTextBox1.Text = "";
            velocityTabControl1.Visible = false;

            includeLoadstringToolStripMenuItem.Text = "Include Loadstring - " + includeLoadstringToolStripMenuItem.Checked;
            discordToolStripMenuItem.Text = "Discord - " + discordToolStripMenuItem.Checked;
            bBCodeWorkInProgressToolStripMenuItem.Text = "BBCode - " + bBCodeWorkInProgressToolStripMenuItem.Checked;

            Output("System Log Started.");
            Loginpanel.Dock = DockStyle.Fill;
            if (Properties.Settings.Default.LoggedIn)
            {
                GetFTP();
                Loginpanel.Visible = false;
                velocityTabControl1.Visible = true;
                Text = "Iris Uploader - Current User: " + Properties.Settings.Default.Username;
            }
        }

        private void includeLoadstringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            includeLoadstringToolStripMenuItem.Checked = !includeLoadstringToolStripMenuItem.Checked;
            includeLoadstringToolStripMenuItem.Text = "Include Loadstring - " + includeLoadstringToolStripMenuItem.Checked;
        }

        private void discordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            discordToolStripMenuItem.Checked = !discordToolStripMenuItem.Checked;
            discordToolStripMenuItem.Text = "Discord - " + discordToolStripMenuItem.Checked;
            if (bBCodeWorkInProgressToolStripMenuItem.Checked) bBCodeWorkInProgressToolStripMenuItem.Checked = false; bBCodeWorkInProgressToolStripMenuItem.Text = "BBCode - " + bBCodeWorkInProgressToolStripMenuItem.Checked;

        }

        private void bBCodeWorkInProgressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bBCodeWorkInProgressToolStripMenuItem.Checked = !bBCodeWorkInProgressToolStripMenuItem.Checked;
            bBCodeWorkInProgressToolStripMenuItem.Text = "BBCode - " + bBCodeWorkInProgressToolStripMenuItem.Checked;
            if (discordToolStripMenuItem.Checked) discordToolStripMenuItem.Checked = false; discordToolStripMenuItem.Text = "Discord - " + discordToolStripMenuItem.Checked;
        }

        private void GetFTP()
        {
            if (Properties.Settings.Default.Username == "Iris")
            {
                FTPUser = "";
                FTPPass = "";
            }
        }

        public string InfinitySiggy = @"
+----------------------------------------------------------------------------+
|  _________ _        _______ _________ _       __________________           |
|  \__   __/( (    /|(  ____ \\__   __/( (    /|\__   __/\__   __/|\     /|  |
|     ) (   |  \  ( +| (    \/   ) (   |  \  ( |   ) (      ) (   ( \   / )  |
|     | |   |   \ | || (__       | |   |   \ | |   | |      | |    \ (_) /   |
|     | |   | (\ \) ||  __)      | |   | (\ \) |   | |      | |     \   /    |
|     | |   | | \   || (         | |   | | \   |   | |      | |      ) (     |
|  ___) (___| )  \  |+ )      ___) (___| )  \  |___) (___   | |      | |     |
|  \_______/|/    )_)|/       \_______/|/    )_)\_______/   )_(      \_/     |
|                                                                            |
+----------------------------------------------------------------------------+

         ";

        public string BBCodeSiggy = @"
[code]+----------------------------------------------------------------------------+
|  _________ _        _______ _________ _       __________________           |
|  \__   __/( (    /|(  ____ \\__   __/( (    /|\__   __/\__   __/|\     /|  |
|     ) (   |  \  ( +| (    \/   ) (   |  \  ( |   ) (      ) (   ( \   / )  |
|     | |   |   \ | || (__       | |   |   \ | |   | |      | |    \ (_) /   |
|     | |   | (\ \) ||  __)      | |   | (\ \) |   | |      | |     \   /    |
|     | |   | | \   || (         | |   | | \   |   | |      | |      ) (     |
|  ___) (___| )  \  |+ )      ___) (___| )  \  |___) (___   | |      | |     |
|  \_______/|/    )_)|/       \_______/|/    )_)\_______/   )_(      \_/     |
|                                                                            |
+----------------------------------------------------------------------------+
[/code]


";

        
        private string GetSiggy()
        {
            if (toolStripTextBox1.Text == "Using Default")
            {
                return InfinitySiggy;
            }
            else
            {
                return "\n" + toolStripTextBox1.Text;
            }
        }

        private void UploadFile()
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.Credentials = new NetworkCredential(FTPUser, FTPPass);
                    client.UploadFileAsync(new Uri("FTPSERVER" + filename.Text), WebRequestMethods.Ftp.UploadFile, @LocationLabel.Text);
                    client.UploadFileCompleted += Client_UploadFileCompleted;
                }
            }
            catch (Exception er)
            {
                
            }
        }

        private void Client_UploadFileCompleted(object sender, UploadFileCompletedEventArgs e)
        {
            DownLink = "https://irishost.xyz/FileUploader/" + Properties.Settings.Default.Username + "/" + filename.Text;
        }

        private void DiscordOutput(string Siggy, string URL, string loadstring)
        {
            Clipboard.SetText("```" + Siggy + "\n\n" + URL + "\n" + loadstring + "```");
            DownLink = null;
            Output("Finished, it has been set to your clipbard - 3/3");
        }

        private void BBCodeOutput(string Siggy, string URL, string loadstring)
        {
            Clipboard.SetText(BBCodeSiggy + "\n\n" + "[size=x-large][color=#66cc33]URL:[/color] [/size] " + URL + "\n" + "[size=x-large][color=#cccc33]loadstring:[/color] [/size] [code]" + loadstring + "[/code]");
            DownLink = null;
            Output("Finished, it has been set to your clipbard - 3/3");
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string urlAddress = "Look_For_Login_Php_in_my_git";

            using (WebClient client = new WebClient())
            {
                NameValueCollection postData = new NameValueCollection()
                {
                    { "Username", UsernameBox.Text },
                    { "Password", PasswordBox.Text }
                };
                string pagesource = Encoding.UTF8.GetString(client.UploadValues(urlAddress, postData));
                Console.WriteLine(client.UploadValues(urlAddress, postData));
                if (pagesource == "1")
                {
                    MessageBox.Show("Valid login, you may contiune.", "Yeet :)", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    if (RememberMe.Checked)
                    {
                        Properties.Settings.Default.Username = UsernameBox.Text;
                        Properties.Settings.Default.Password = PasswordBox.Text;
                        Properties.Settings.Default.LoggedIn = true;

                        Text = "Iris Uploader - Current User: " + Properties.Settings.Default.Username;
                    }
                    else
                    {
                        Text = "Iris Uploader - Current User: " + UsernameBox.Text;
                    }
                    GetFTP();
                    Loginpanel.Visible = false;
                }
                else
                {
                    MessageBox.Show("Invalid login, please contact Iris", "Yoinks :(", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    Environment.Exit(0);
                }
            }
        }

        private void PasswordBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                string urlAddress = "Look_For_Login_Php_in_my_git";

                using (WebClient client = new WebClient())
                {
                    NameValueCollection postData = new NameValueCollection()
                {
                    { "Username", UsernameBox.Text },
                    { "Password", PasswordBox.Text }
                };
                    string pagesource = Encoding.UTF8.GetString(client.UploadValues(urlAddress, postData));
                    if (pagesource == "1")
                    {
                        MessageBox.Show("Valid login, you may contiune.", "Yeet :)", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        if (RememberMe.Checked)
                        {
                            Properties.Settings.Default.Username = UsernameBox.Text;
                            Properties.Settings.Default.Password = PasswordBox.Text;
                            Properties.Settings.Default.LoggedIn = true;
                            Text = "Iris Uploader - Current User: " + Properties.Settings.Default.Username;
                            GetFTP();
                            Loginpanel.Visible = false;
                            velocityTabControl1.Visible = true;
                        }
                        else
                        {
                            Text = "Iris Uploader - Current User: " + UsernameBox.Text;
                        }
                        GetFTP();
                        Loginpanel.Visible = false;
                        velocityTabControl1.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("Invalid login, please contact Iris", "Yoinks :(", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        Environment.Exit(0);
                    }
                }
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FTPUser = null;
            FTPPass = null;
            Properties.Settings.Default.Username = null;
            Properties.Settings.Default.Password = null;
            Properties.Settings.Default.LoggedIn = false;
            Text = "Iris Uploader - Current User: Signed out";
            velocityTabControl1.Visible = false;
            Loginpanel.Visible = true;
        }

        private void tabPage3_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                filename.Text = Path.GetFileName(file);

                LocationLabel.Text = Path.GetFullPath(file);

                long length = new FileInfo(Path.GetFullPath(file)).Length;

                FileSizeLabel.Text = BytesToString(length);

                FileTypeLabel.Text = Path.GetExtension(Path.GetFullPath(file));

                panel1.BackgroundImage = Icon.ExtractAssociatedIcon(Path.GetFullPath(file)).ToBitmap();
                
                //Output("File Registered: " + filename.Text);
            }
        }

        private void tabPage3_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private async void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Text.Contains("Signed"))
            {
                if (velocityTabControl1.Visible == true)
                {
                    Output("ERROR - NOT SIGNED IN");
                    return;
                }
                else
                {
                    MessageBox.Show("ERROR - NOT SIGNED IN", "Bad Boy", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
            }
            Output("Started upload/generation - 1/3");
            if (discordToolStripMenuItem.Checked)
            {
                var Watch = new Stopwatch();
                Watch.Start();
                UploadFile();
                while (DownLink == null)
                {
                    await Task.Delay(50);
                }
                Watch.Stop();
                Output("Upload finished took: " + Watch.Elapsed.TotalSeconds + " - 2/3");
                if (includeLoadstringToolStripMenuItem.Checked)
                {
                    DiscordOutput(GetSiggy(), DownLink, "\nloadstring(game:HttpGet('" + DownLink + "'))()");
                }
                else
                {
                    DiscordOutput(GetSiggy(), DownLink, "");
                }
            }
            else if (bBCodeWorkInProgressToolStripMenuItem.Checked)
            {
                var Watch = new Stopwatch();
                Watch.Start();
                UploadFile();
                while (DownLink == null)
                {
                    await Task.Delay(50);
                }
                Watch.Stop();
                Output("Upload finished took: " + Watch.Elapsed.TotalSeconds + " - 2/3");
                if (includeLoadstringToolStripMenuItem.Checked)
                {
                    BBCodeOutput("", DownLink, "loadstring(game:HttpGet('" + DownLink + "'))()");
                }
                else
                {
                    BBCodeOutput("", DownLink, "");
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Open File";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog.FileName != null || !string.IsNullOrWhiteSpace(openFileDialog.FileName))
                {
                    filename.Text = Path.GetFileName(openFileDialog.FileName);
                    LocationLabel.Text = Path.GetFullPath(openFileDialog.FileName);
                    long length = new FileInfo(Path.GetFullPath(openFileDialog.FileName)).Length;
                    FileSizeLabel.Text = BytesToString(length);
                    FileTypeLabel.Text = Path.GetExtension(Path.GetFullPath(openFileDialog.FileName));
                    panel1.BackgroundImage = Icon.ExtractAssociatedIcon(Path.GetFullPath(openFileDialog.FileName)).ToBitmap();
                    Output("File Registered: " + filename.Text);
                }
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vRichTextBox1.Text = "";
            filename.Text = "";
            LocationLabel.Text = "";
            FileSizeLabel.Text = "";
            FileTypeLabel.Text = "";
            DownLink = null;
            Clipboard.SetText("");
            Output("File closed.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create("FTP SERVER" + textBox1.Text);

                request.Credentials = new NetworkCredential(FTPUser, FTPPass);

                request.Method = WebRequestMethods.Ftp.DeleteFile;
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                Outputty("Delete status: " + response.StatusDescription);
                if (response.StatusDescription.Contains("250"))
                {
                    Outputty(textBox1.Text + " deleted!");
                }
                response.Close();
            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            vRichTextBox2.Text = "";
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("FTP SERVER");
            request.Credentials = new NetworkCredential(FTPUser, FTPPass);
            request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();

            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);

            Outputty(reader.ReadToEnd());

            reader.Close();
            response.Close();
        }
    }
}
