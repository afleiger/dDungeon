using System;
using System.Data.SQLite;

namespace Chrisistheon
{
    public class Database
    {
        private int heroId;
        private int monsterId;

        public Database()
        {
            heroId = 1;
            monsterId = 1;
        }

        public virtual void connect()
        {
                SQLiteConnection.CreateFile("stats.db");
                SQLiteConnection con = new SQLiteConnection("Data Source=stats.db;Version=3;");
                con.Open();

                SQLiteCommand comm = new SQLiteCommand("CREATE TABLE IF NOT EXISTS HeroStats (id INTEGER, class TEXT, hp INTEGER, power INTEGER, defense INTEGER, speed INTEGER)");
                comm.Connection = con;
                comm.ExecuteNonQuery();
                comm.CommandText = "CREATE TABLE IF NOT EXISTS MonsterStats (id INTEGER, class TEXT, hp INTEGER, power INTEGER, defense INTEGER, speed INTEGER)";
                comm.ExecuteNonQuery();
                con.Close();
        }
        
        public virtual void addHeroTouple(string name, int hp, int pwr, int def, int spd)
        {
            SQLiteConnection con = new SQLiteConnection("Data Source=stats.db;Version=3;");
            con.Open();
            SQLiteCommand comm = new SQLiteCommand("INSERT INTO HeroStats values(" + heroId + ", '" + name + "', " + hp + ", " + pwr + ", " + def + ", " + spd + ")");
            comm.Connection = con;
            comm.ExecuteNonQuery();
            con.Close();
            heroId++;
        }
        
        public virtual void addMonsterTouple(string name, int hp, int pwr, int def, int spd)
        {
            SQLiteConnection con = new SQLiteConnection("Data Source=stats.db;Version=3;");
            con.Open();
            SQLiteCommand comm = new SQLiteCommand("INSERT INTO MonsterStats values(" + monsterId + ", '" + name + "', " + hp + ", " + pwr + ", " + def + ", " + spd + ")");
            comm.Connection = con;
            comm.ExecuteNonQuery();
            con.Close();
            monsterId++;
        }
        
        public virtual void updateHeroTouple(string name, int hp, int pwr, int def, int spd)
        {
            SQLiteConnection con = new SQLiteConnection("Data Source=stats.db;Version=3;");
            con.Open();
            SQLiteCommand comm = new SQLiteCommand("UPDATE HeroStats SET hp = " + hp + " ,power = " + pwr + " ,defense = " + def + " ,speed = " + spd + " WHERE class = '" + name + "'");
            comm.Connection = con;
            comm.ExecuteNonQuery();
            con.Close();
        }
        
        public virtual void updateMonsterTouple(string name, int hp, int pwr, int def, int spd)
        {
            SQLiteConnection con = new SQLiteConnection("Data Source=stats.db;Version=3;");
            con.Open();
            SQLiteCommand comm = new SQLiteCommand("UPDATE MonsterStats SET hp = " + hp + " ,power = " + pwr + " ,defense = " + def + " ,speed = " + spd + " WHERE class = '" + name + "'");
            comm.Connection = con;
            comm.ExecuteNonQuery();
            con.Close();
        }
       
        public virtual string getHeroName(int index)
        {
            SQLiteConnection con = new SQLiteConnection("Data Source=stats.db;Version=3;");
            con.Open();
            SQLiteCommand comm = new SQLiteCommand("SELECT class FROM HeroStats WHERE id = " + index);
            comm.Connection = con;
            SQLiteDataReader read = comm.ExecuteReader();
            if(read.Read())
                return read.GetString(0);
            return "";
        }
        
        public virtual int[] getClassStats(string className)
        {
            SQLiteConnection con = new SQLiteConnection("Data Source=stats.db;Version=3;");
            con.Open();
            SQLiteCommand comm = new SQLiteCommand("SELECT hp, power, defense, speed FROM HeroStats WHERE class = '" + className + "'");
            comm.Connection = con;
            SQLiteDataReader r = comm.ExecuteReader();
            int[] result = new int[4];
            if (r.Read())
            {
                result[0] = r.GetInt32(0);
                result[1] = r.GetInt32(1);
                result[2] = r.GetInt32(2);
                result[3] = r.GetInt32(3);
            }
            return result;
        }
    }
}