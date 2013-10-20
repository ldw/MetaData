using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using MetaData.Properties;

namespace MetaData
{
    public partial class Form1 : Form
    {
        private IDAL myDAL = new OnlineDAL();
        FileSystemWatcher myFileWatcher;
        private string ReadSong = "";
        private DateTime LastUpdate = DateTime.Now;

        public Form1()
        {
            InitializeComponent();
        }

        private void WatchFile()
        {
            if (File.Exists(@Settings.Default.ZaraPath))
            {
                myFileWatcher = new FileSystemWatcher();
                ConfigWatcher();
                this.Text = "Scorpio's Icecast Tool";
                ckSongFromZaraToIcecast.Checked = true;
                tmrPoll.Interval = Settings.Default.TimerCheckZaraFileExistsInMS;
                if (!tmrPoll.Enabled)
                    tmrPoll.Start();
            }
            else
            {
                System.Threading.Thread.Sleep(Settings.Default.TimerCheckZaraFileExistsInMS); //Wait for retry x sec.
                WatchFile();
            }

        }

        private void ConfigWatcher()
        {
            myFileWatcher.Path = Path.GetDirectoryName(@Settings.Default.ZaraPath);
            myFileWatcher.NotifyFilter = NotifyFilters.LastWrite;
            myFileWatcher.Filter = Path.GetFileName(@Settings.Default.ZaraPath);
            myFileWatcher.Changed += new FileSystemEventHandler(OnSongChanged);
            myFileWatcher.EnableRaisingEvents = true;
        }

        private void OnSongChanged(object source, FileSystemEventArgs e)
        {
            string song = Helper.GetSongFromZaraTxt(@Settings.Default.ZaraPath);
            if(song!=ReadSong)
            {
                ReadSong = song;
                LastUpdate = DateTime.Now;
                if (!Helper.IsJingle(song, Settings.Default.WordsToFilterOut) && !Helper.IsIpOrNumber(song))
                {
                    myDAL.InsertSong(song);
                    UpdateMetadata((song));
                }
                else
                {
                    UpdateMetadata(Settings.Default.IcecastDefaultText);
                }
            }
        }

        private delegate void stringDelegate(string s);

        private void ShowInfoOnForm(string s)
        {
            if (txtSongSendFromZara.InvokeRequired)
            {
                stringDelegate sd = new stringDelegate(ShowInfoOnForm);
                this.Invoke(sd, new object[] { s });
            }
            else
            {
                txtSongSendFromZara.Text = s;
                lblDateTime.Text = DateTime.Now.ToShortDateString() + " - " +DateTime.Now.ToLongTimeString();
            }
        }

        private void UpdateMetadata(string song)
        {
            try {
                ShowInfoOnForm("Communicating with shoutcast...");

                bool resultOk = Helper.UpdateIcecast(song);
                if (resultOk)
                {
                    ShowInfoOnForm(song);
                }
                else
                {
                    ErrorHandler.HandleTheErrorIfTimeIntervalLongEnough("Error updating Icecast. The HttpWebResponse.StatusCode is not ok");
                    ShowInfoOnForm("Error updating Icecast. The HttpWebResponse.StatusCode is not ok");
                }
            }
            catch(Exception e) {
                ShowInfoOnForm(e.Message);
                ErrorHandler.HandleTheErrorIfTimeIntervalLongEnough(e.Message);
            }
            
        }

        private void TestUpdateMetaData()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Uri uri = new Uri(@Settings.Default.IcecastUri + Settings.Default.IcecastDefaultText);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri) as HttpWebRequest;
                request.Accept = "application/xml";

                // authentication
                var cache = new CredentialCache();
                cache.Add(uri, "Basic", new NetworkCredential(Settings.Default.IcecastUser, Settings.Default.IcecastPass));
                request.Credentials = cache;

                ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(Helper.AcceptAllCertifications);

                // response.
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    StreamReader sr = new StreamReader(response.GetResponseStream());
                    string str = sr.ReadToEnd();

                    MessageBox.Show("Succeed! Icecast response: " + str, "Succes");
                }
                else
                {
                    MessageBox.Show("Failed with HttpStatusCode: " + response.StatusCode, "Failed");
                }
                response.Close();
            }
            catch (Exception e)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Failed: " + e.Message, "Failed");
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }


        private void button1_Click(object sender, EventArgs e) //testbutton
        {
            string input = "";
            if (InputBox("Warning", "By testing the Icecast communication, the current song info will reset to '" + Settings.Default.IcecastDefaultText + "'. Type 'yes' to continue." , ref input) == DialogResult.OK)
            {
                if (input == "yes")
                {
                    TestUpdateMetaData();
                }
            }
        }

        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }


        private void Form1_Shown(object sender, EventArgs e)
        {
            WatchFile();
        }

        private void tmrPoll_Tick(object sender, EventArgs e)
        {
            if (!File.Exists(@Settings.Default.ZaraPath))
            {
                setIcecastDefaultText();

                ErrorLog.LogError("CurrentSong.Txt not available " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                ckSongFromZaraToIcecast.Enabled = false;
                this.Text = "Waiting for CurrentSong.txt to become available";
                WatchFile();
            }
            else
            {
                if(ReadSong != Settings.Default.IcecastDefaultText)
                {
                    //als meer dan 10? minuten, zet icecast default tekst
                    TimeSpan interval = DateTime.Now - LastUpdate;
                    if(interval.TotalMinutes > 10)
                    {
                        setIcecastDefaultText();
                    }
                }
            }
        }
        private  void setIcecastDefaultText()
        {
            ReadSong = Settings.Default.IcecastDefaultText;
            LastUpdate = DateTime.Now;
            UpdateMetadata(Settings.Default.IcecastDefaultText);
        }
    }
}
