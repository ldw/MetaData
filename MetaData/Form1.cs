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

namespace MetaData
{
    public partial class Form1 : Form
    {
        FileSystemWatcher _fileWatcher = new FileSystemWatcher();
        DAL myDAL = new DAL();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dateTimeStart.Value = DateTime.Today.AddDays(-1);
        }

        private void watchFile()
        {
            _fileWatcher.Path = Path.GetDirectoryName(@txtZaraPath.Text);
            _fileWatcher.NotifyFilter = NotifyFilters.LastWrite;
            _fileWatcher.Filter = Path.GetFileName(@txtZaraPath.Text);
            _fileWatcher.Changed += new FileSystemEventHandler(OnChanged);
            _fileWatcher.EnableRaisingEvents = true;
        }
        private void OnChanged(object source, FileSystemEventArgs e)
        {
            string song = "";
            try
            {
                _fileWatcher.EnableRaisingEvents = false;
                song = Helper.GetSongFromZaraTxt(@txtZaraPath.Text);
            }
            catch (Exception ex)
            {
                ShowInfoOnForm(ex.Message);
                ErrorHandler.HandleTheErrorIfTimeInterval(ex.ToString());
            }
            finally
            {
                _fileWatcher.EnableRaisingEvents = true;
            }
            if (!Helper.IsJingle(song, txtJingles.Text)) {
                myDAL.InsertSong(song);
                updateMetadata((song));
            }
            else{
                updateMetadata("Radio Scorpio - 106 FM");
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

        private void updateMetadata(string song)
        {
            try {
                ShowInfoOnForm("Communicating with shoutcast...");

                Helper.UpdateIcecast(txtAdres.Text, txtStream.Text, song, txtUser.Text, txtPass.Text);
                ShowInfoOnForm(song);
            }
            catch(Exception e) {
                ShowInfoOnForm(e.Message);
                ErrorHandler.HandleTheErrorIfTimeInterval(e.Message);
            }
            
        }

        private void checkConfigOk()
        {
            if (txtAdres.Text.Trim().Equals("") || txtStream.Text.Trim().Equals("") || txtUser.Text.Trim().Equals("") || txtPass.Text.Trim().Equals(""))
            {
                lblDateTime.Text = "Can not start. Configuration missing...";
                ckSongFromZaraToIcecast.Checked = false;
            }
            else
                lblDateTime.Text = "";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            checkConfigOk();
            if (ckSongFromZaraToIcecast.Checked)
            {
                if(File.Exists(txtZaraPath.Text))
                    watchFile();
                else{
                    ckSongFromZaraToIcecast.Checked = false;
                    tabControl1.SelectedTab = tabConfig;
                    txtZaraPath.Focus();
                }
            }
            else
                _fileWatcher.EnableRaisingEvents = false;

            timer1.Enabled = ckSongFromZaraToIcecast.Checked;

        }

        private void testUpdateMetaData()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Uri uri = Helper.CreateUri(txtAdres.Text, txtStream.Text, "Radio Scorpio - 106FM");
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri) as HttpWebRequest;
                request.Accept = "application/xml";

                // authentication
                var cache = new CredentialCache();
                cache.Add(uri, "Basic", new NetworkCredential(txtUser.Text, txtPass.Text));
                request.Credentials = cache;

                ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(Helper.AcceptAllCertifications);

                // response.
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    StreamReader sr = new StreamReader(response.GetResponseStream());
                    string str = sr.ReadToEnd();

                    MessageBox.Show("Succeed! Icecast response: " + str,"Succes");
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

        private void btnTest_Click(object sender, EventArgs e)
        {
            testUpdateMetaData();
        }

        private void btnShowPlayList_Click(object sender, EventArgs e)
        {
            DataTable playlist = myDAL.GetPlayList(dateTimeStart.Value, dateTimeEnd.Value);
            dataGridView1.DataSource = playlist;
            enableSendMailButton();
        }

        private void enableSendMailButton() {
            btnSendMail.Enabled = (dataGridView1.Rows.Count > 0) && Helper.IsValidEmail(txtMailDestination.Text);
        }

        private void txtMailDestination_TextChanged(object sender, EventArgs e)
        {
            enableSendMailButton();
        }

        private void btnSendMail_Click(object sender, EventArgs e)
        {
            try
            {
                string message = Helper.DGVtoString(dataGridView1, " - ");
                SendMail.SendEmail("Playlist from " + dateTimeStart.Value.ToString() + " till " + dateTimeEnd.Value.ToString(), message, txtMailDestination.Text);
                txtMailDestination.Text = "";
                MessageBox.Show("Sent!");
            }
            catch (Exception xe)
            {

                ErrorHandler.LogErrorInTXT(xe.Message);
                MessageBox.Show(xe.Message);
            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!File.Exists(txtZaraPath.Text))
                ErrorHandler.HandleTheError("File not found: " + txtZaraPath.Text);
        }
    }
}
