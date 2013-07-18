using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Configuration;
using System.Windows.Forms;

namespace MetaData
{
    public static class Helper
    {
        public const string STANDARD_MSG = "Klik hier om te luisteren.";
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

        public static Uri CreateUri(string adres, string stream, string s)
        {
            return new Uri("http://" + adres + @"/admin/metadata?mount=" + stream + "&mode=updinfo&song=" + s);
        }
        public static void UpdateIcecast(string adres, string stream, string song, string user, string pass)
        {
            Uri uri = CreateUri(adres, stream, song);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri) as HttpWebRequest;
            request.Accept = "application/xml";

            // authentication
            var cache = new CredentialCache();
            cache.Add(uri, "Basic", new NetworkCredential(user, pass));
            request.Credentials = cache;

            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);

            // response.
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            response.Close();
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
                musicfile = musicfile.Replace("\n", "").Replace("\r", "");
                if (musicfile.Contains("~"))
                {
                    musicfile = musicfile.Remove(musicfile.IndexOf("~"));
                }

                return musicfile;
            }
            catch (Exception)
            {
                return "";
            }
            
        }
/*
        private static string PrettyUpSongName(string song)
        { 
            
            return song;
        }
*/
        /// <summary>
        /// Check if jingle or live show
        /// </summary>
        /// <param name="song"></param>
        /// <returns></returns>
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
