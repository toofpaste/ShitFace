using System.Collections.Generic;
using System;
using MySql.Data.MySqlClient;

namespace ShitBook.Models
{
    public class User
    {
        private static List<User> _instances = new List<User> { };
        private string _name;
        private int _id;
        private List<About> _Abouts;

        public User(string UserName, int id = 0)
        {
            _name = UserName;
            _id = id;
            _Abouts = new List<About> { };
        }

        public override int GetHashCode()
        {
            return this.GetId().GetHashCode();
        }

        public string GetName()
        {
            return _name;
        }

        public int GetId()
        {
            return _id;
        }

        public static void ClearAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM user;";
            cmd.ExecuteNonQuery();
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static List<User> GetAll()
        {
            List<User> allCategories = new List<User> { };
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM user;";
            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                int UserId = rdr.GetInt32(0);
                string UserName = rdr.GetString(1);
                User newUser = new User(UserName, UserId);
                allCategories.Add(newUser);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allCategories;
        }

        public static User Find(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM user WHERE id = (@searchId);";
            MySqlParameter searchId = new MySqlParameter();
            searchId.ParameterName = "@searchId";
            searchId.Value = id;
            cmd.Parameters.Add(searchId);
            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            int UserId = 0;
            string UserName = "";
            while (rdr.Read())
            {
                UserId = rdr.GetInt32(0);
                UserName = rdr.GetString(1);
            }
            User newUser = new User(UserName, UserId);
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return newUser;
        }
        public List<About> GetAbouts()
        {
            List<About> allUserAbouts = new List<About> { };
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM about WHERE id = @User_id;";
            MySqlParameter UserId = new MySqlParameter();
            UserId.ParameterName = "@User_id";
            UserId.Value = this._id;
            cmd.Parameters.Add(UserId);
            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                int AboutId = rdr.GetInt32(0);
                string AboutDescription = rdr.GetString(1);
                DateTime dd = rdr.GetDateTime(2);
                int AboutUserId = rdr.GetInt32(3);
                DateTime endShift = rdr.GetDateTime(4);
                string cutInfo = rdr.GetString(5);
                string imgUrl = rdr.GetString(6);
                int price = rdr.GetInt32(7);
                About newAbout = new About(AboutDescription, dd, AboutUserId, endShift, cutInfo, imgUrl, price,  AboutId);
                allUserAbouts.Add(newAbout);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allUserAbouts;
        }



        public void AddAbout(About About)
        {
            _Abouts.Add(About);
        }


        public override bool Equals(System.Object otherUser)
        {
            if (!(otherUser is User))
            {
                return false;
            }
            else
            {
                User newUser = (User)otherUser;
                bool idEquality = this.GetId().Equals(newUser.GetId());
                bool nameEquality = this.GetName().Equals(newUser.GetName());
                return (idEquality && nameEquality);
            }
        }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO user (name) VALUES (@name);";
            MySqlParameter name = new MySqlParameter();
            name.ParameterName = "@name";
            name.Value = this._name;
            cmd.Parameters.Add(name);
            cmd.ExecuteNonQuery();
            _id = (int)cmd.LastInsertedId;
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

    }
}
