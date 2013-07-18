using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.IO;
using System.Data;

namespace MetaData
{
    public class DAL
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

                    ErrorHandler.HandleTheErrorIfTimeInterval(e.Message);
                }
                    
            }
        }

        public DataTable GetPlayList()
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
                mycommand.CommandText = "select datetime, song from playlist";
                SQLiteDataReader reader = mycommand.ExecuteReader();
                dt.Load(reader);
                reader.Close();
                cnn.Close();
            }
            catch (Exception ex)
            {

                ErrorHandler.HandleTheErrorIfTimeInterval(ex.Message);
            }
            

            return dt;
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
                ErrorHandler.HandleTheErrorIfTimeInterval(ex.Message);
            }
                

            return dt;
        }

        public void InsertSong(string song)
        {
            
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
                mycommand.CommandText = String.Format("insert into playlist(datetime, song) values('{0}','{1}')", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), titel);
                //mycommand.CommandText = String.Format("insert into playlist(datetime, song) values(@dateParam,@songParam)");
                //var dateParam = new SQLiteParameter("@dateParam", SqlDbType.DateTime) { Value = DateTime.Now };
                //var songParam = new SQLiteParameter("@songParam", SqlDbType.Text) { Value = song };
                //mycommand.Parameters.Add(dateParam);
                //mycommand.Parameters.Add(songParam);
                mycommand.ExecuteNonQuery();
                cnn.Close();
            }
            catch (Exception e)
            {

                ErrorHandler.HandleTheErrorIfTimeInterval(e.Message);
            }
        }
    }
}
