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
        FileSystemWatcher myFileWatcher = new FileSystemWatcher();
        IDAL myDAL = new SQLiteDAL();
        bool myWatcherEnabled = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //todo: zara path \\studio1\ZaraRadio
            timer1.Interval = Settings.Default.TimerCheckZaraFileExistsInMS;
            timer1.Enabled = true;
            CheckSettingsOK();
        }

        private void WatchFile()
        {
            myFileWatcher.Path = Path.GetDirectoryName(@Settings.Default.ZaraPath);
            myFileWatcher.NotifyFilter = NotifyFilters.LastWrite;
            myFileWatcher.Filter = Path.GetFileName(@Settings.Default.ZaraPath);
            myFileWatcher.Changed += new FileSystemEventHandler(OnSongChanged);
            myFileWatcher.EnableRaisingEvents = true;
        }

        private void OnSongChanged(object source, FileSystemEventArgs e)
        {
            string song = "";
            try
            {
                myFileWatcher.EnableRaisingEvents = false;
                song = Helper.GetSongFromZaraTxt(@Settings.Default.ZaraPath);
            }
            catch (Exception ex)
            {
                ShowInfoOnForm(ex.Message);
                ErrorHandler.HandleTheErrorIfTimeIntervalLongEnough(ex.ToString());
            }
            finally
            {
                myFileWatcher.EnableRaisingEvents = true;
            }
            if (!Helper.IsJingle(song, Settings.Default.WordsToFilterOut) && !Helper.IsIpOrNumber(song)) {
                myDAL.InsertSong(song);
                UpdateMetadata((song));
            }
            else{
                UpdateMetadata(Settings.Default.IcecastDefaultText);
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

        private void EnableSendMailButton() {
            btnSendMail.Enabled = (dataGridView1.Rows.Count > 0) && Helper.IsValidEmail(txtMailDestination.Text);
        }

        private void CheckSettingsOK()
        {
            try
            {
                if (File.Exists(@Settings.Default.ZaraPath))
                {
                    myWatcherEnabled = true;
                    WatchFile();
                }
                else
                {
                    ShowInfoOnForm(@Settings.Default.ZaraPath + " not found! Waiting one minute...");
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleTheErrorIfTimeIntervalLongEnough(ex.Message);
            }
            ckSongFromZaraToIcecast.Checked = myWatcherEnabled;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            CheckZaraFileAccessible();
        }

        private void CheckZaraFileAccessible()
        {
            try
            {
                if (!File.Exists(@Settings.Default.ZaraPath))
                {
                    ckSongFromZaraToIcecast.Checked = false;
                    string error = Settings.Default.ZaraPath + " is not accessible!";
                    ShowInfoOnForm(error);
                    ErrorHandler.HandleTheErrorIfTimeIntervalLongEnough(error);
                }
                else
                {
                    ckSongFromZaraToIcecast.Checked = true;
                    if (!myWatcherEnabled)
                    {
                        myWatcherEnabled = true;
                        ShowInfoOnForm("");
                        WatchFile();
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleTheErrorIfTimeIntervalLongEnough(ex.Message);
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

        private void btnShowPlayList_Click_1(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            DataTable playlist = myDAL.GetPlayList(dateTimeStart.Value, dateTimeEnd.Value);
            dataGridView1.DataSource = playlist;
            EnableSendMailButton();
            this.Cursor = Cursors.Default;
        }

        private void btnSendMail_Click_1(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                string message = Helper.DgVtoString(dataGridView1, " - ");
                SendMail.SendEmail("Playlist from " + dateTimeStart.Value.ToString() + " till " + dateTimeEnd.Value.ToString(), message, txtMailDestination.Text);
                txtMailDestination.Text = "";
                this.Cursor = Cursors.Default;
                MessageBox.Show("Sent!");
            }
            catch (Exception xe)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(xe.Message);
            }
        }

        private void txtMailDestination_TextChanged(object sender, EventArgs e)
        {
            EnableSendMailButton();
        }
    }
}
