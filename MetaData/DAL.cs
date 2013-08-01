using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.IO;
using System.Data;

namespace MetaData
{
    public interface IDAL
    {
        DataTable GetPlayList(DateTime start, DateTime end);
        void InsertSong(string song);
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
