using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Configuration;
using System.Windows.Forms;
using MetaData.Properties;

namespace MetaData
{
    public static class Helper
    {
        public static string DgVtoString(DataGridView dgv, string delimiter)
        {
            StringBuilder sb = new StringBuilder();
            foreach (DataGridViewRow row in dgv.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    sb.Append(cell.Value);
                    sb.Append(delimiter);
                }
                sb.Remove(sb.Length - delimiter.Length, delimiter.Length); // Removes the last delimiter 
                sb.AppendLine();
            }
            return sb.ToString();
        }

        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool UpdateIcecast(string song)
        {
#if(DEBUG)
            return true;
#endif
            bool icecastCommunicationSucceeded = false;

            Uri uri = new Uri(@Settings.Default.IcecastUri + song + "&charset=utf8");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri) as HttpWebRequest;
            request.Accept = "application/xml";

            // authentication
            var cache = new CredentialCache();
            cache.Add(uri, "Basic", new NetworkCredential(Settings.Default.IcecastUser, Settings.Default.IcecastPass));
            request.Credentials = cache;

            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);

            // response.
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                icecastCommunicationSucceeded = true;
            }
            
            response.Close();
            return icecastCommunicationSucceeded;
        }

        public static bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        public static string GetSongFromZaraTxt(string @zarapath)
        {
            try
            {
                string musicfile = File.ReadAllText(@zarapath, Encoding.Default);

                return PrettyUpSongName(musicfile);
            }
            catch (Exception)
            {
                return "";
            }
        }

        private static string PrettyUpSongName(string song)
        {
            song = song.Replace("\n", "").Replace("\r", "");
            if(song.Contains("&"))
            {
                song = song.Replace("&", "and");
            }
            if (song.Contains("~"))
            {
                song = song.Remove(song.IndexOf("~"));
            }
            if (song.Contains("-"))
            {
                string artist = song.Split('-')[0];
                if (artist.Contains(", The"))
                {
                    song = "The " + song.Replace(", The", "");
                }
            }
            return song;
        }

        public static bool IsJingle(string song, string jingles)
        {
            if (song.Length < 8)
                return true;

            string[] splitString = jingles.Split(',');
            foreach (string s in splitString)
            {
                if (song.Contains(s))
                    return true;
            }
            return false;
        }

        public  static  bool IsIpOrNumber(string song)
        {
            int number;
            return Int32.TryParse(song.Replace(".", ""), out number);
        }
    }
}
