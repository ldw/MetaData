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
        public void CreateDBFile()
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
            if (!File.Exists("playlist.db"))
            {
                CreateDBFile();
            }
            DataTable dt = new DataTable();
            try
            {
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
            if (!File.Exists("playlist.db"))
            {
                CreateDBFile();
            }
            DataTable dt = new DataTable();
            try
            {
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
            if (!File.Exists("playlist.db"))
            {
                CreateDBFile();
            }
            try
            {
                SQLiteConnection cnn = new SQLiteConnection("Data Source=playlist.db");
                cnn.Open();
                SQLiteCommand mycommand = new SQLiteCommand(cnn);
                mycommand.CommandText = String.Format("insert into playlist(datetime, song) values('{0}','{1}');", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), song);
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
