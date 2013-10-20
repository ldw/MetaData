using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Data.SQLite;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.IO;
using System.Data;
using MetaData.Properties;

namespace MetaData
{
    public interface IDAL
    {
        DataTable GetPlayList(DateTime start, DateTime end);
        void InsertSong(string song);
    }

    public class OnlineDAL : IDAL
    {

        public DataTable GetPlayList(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        public void InsertSong(string song)
        {
            try
            {
                Uri uri = new Uri(@Settings.Default.PhpScriptURI + song);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri) as HttpWebRequest;
                request.Accept = "application/xml";

                // response.
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    ErrorHandler.HandleTheErrorIfTimeIntervalLongEnough("Insert song in playlist table failed, HttpWebResponse " + response.StatusCode.ToString() + " " + response.StatusDescription.ToString());
                }

                response.Close();
            }
            catch (Exception e)
            {
                ErrorHandler.HandleTheErrorIfTimeIntervalLongEnough(e.Message);
            }
        }

        public static bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

    }

    public class MySqlDAL : IDAL
    {//MySqlDbConnectionString
        public MySqlConnection connection = new MySqlConnection(Settings.Default.MySqlDbConnectionString);

        public DataTable GetPlayList(DateTime start, DateTime end)
        {
            DataSet ds = new DataSet();
            try
            {
                if (this.OpenConnection() == true)
                {
                    string query = string.Format("SELECT datetime, song FROM playlist WHERE datetime BETWEEN '{0}' AND '{1}'", start.ToString("yyyy-MM-dd HH:mm:ss"), end.ToString("yyyy-MM-dd HH:mm:ss"));
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                    adap.Fill(ds);
                    this.connection.Close();
                    return ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleTheError(ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return null;
        }

        public void InsertSong(string song)
        {

            try
            {
                string query = "INSERT INTO Playlist (time, song) VALUES(@time, @song)";
                if (song.Length > 75)
                    song = song.Substring(0, 75);

                //open connection
                if (this.OpenConnection() == true)
                {
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@time", DateTime.Now);
                    cmd.Parameters.AddWithValue("@song", song);

                    //Execute command
                    cmd.ExecuteNonQuery();

                    //close connection
                    this.CloseConnection();
                }
            }
            catch (Exception e)
            {
                ErrorHandler.HandleTheErrorIfTimeIntervalLongEnough(e.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }

    public class SQLiteDAL : IDAL
    {
        public void CreateDbFile()
        {
            if (!File.Exists("playlist.db"))
            {
                try
                {
                    SQLiteConnection.CreateFile("playlist.db");
                    SQLiteConnection mDBcon = new SQLiteConnection();
                    mDBcon.ConnectionString = "Data Source=playlist.db";
                    mDBcon.Open();
                    SQLiteCommand cmd = new SQLiteCommand(mDBcon);
                    cmd.CommandText = "CREATE TABLE playlist (datetime DATETIME, song VARCHAR(50));";
                    cmd.ExecuteNonQuery();
                    mDBcon.Close();
                }
                catch (Exception e)
                {

                    ErrorHandler.HandleTheError(e.Message);
                }
            }
        }


        public DataTable GetPlayList(DateTime start, DateTime end)
        {
            DataTable dt = new DataTable();
            try
            {
                if (!File.Exists("playlist.db"))
                {
                    CreateDbFile();
                }
                SQLiteConnection cnn = new SQLiteConnection("Data Source=playlist.db");
                cnn.Open();
                SQLiteCommand mycommand = new SQLiteCommand(cnn);
                mycommand.CommandText = string.Format("select datetime, song from playlist where datetime between '{0}' and '{1}'", start.ToString("yyyy-MM-dd HH:mm:ss"), end.ToString("yyyy-MM-dd HH:mm:ss"));
                SQLiteDataReader reader = mycommand.ExecuteReader();
                dt.Load(reader);
                reader.Close();
                cnn.Close();
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleTheError(ex.Message);
            }
                
            return dt;
        }

        public void InsertSong(string song)
        {
#if(DEBUG)
            return;
#endif
            try
            {
                if (!File.Exists("playlist.db"))
                {
                    CreateDbFile();
                }
                string titel = song.Length > 50 ? song.Substring(0, 50) : song;
                SQLiteConnection cnn = new SQLiteConnection("Data Source=playlist.db");
                cnn.Open();
                SQLiteCommand mycommand = new SQLiteCommand(cnn);
                mycommand.CommandText = String.Format("insert into playlist(datetime, song) values(@dateParam,@songParam)");
                mycommand.Parameters.AddWithValue("@dateParam", DateTime.Now);
                mycommand.Parameters.AddWithValue("@songParam", titel);
                mycommand.ExecuteNonQuery();
                cnn.Close();
            }
            catch (Exception e)
            {
                ErrorHandler.HandleTheErrorIfTimeIntervalLongEnough(e.Message);
            }
        }
    }
}
