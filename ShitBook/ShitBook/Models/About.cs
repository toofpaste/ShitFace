using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace ShitBook.Models
{
  public class About
  {
    public int Id{get; set;}
    // public Date _joinDate{get, set;};
    public DateTime BirthDate{get; set;}
    public string HomeCity{get; set;}
    public string Name{get; set;}
    public int Age{get; set;}
     public About(DateTime birthDate, string homeCity, string name, int age, int id = 0)
     {
       BirthDate = birthDate;
       HomeCity = homeCity;
       Name = name;
       Age = age;
       Id = id;
     }
     public static List<About> GetAll()
     {
       List<About> allItems = new List<About>{};
       MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM about;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        int itemId = rdr.GetInt32(0);
        DateTime newBirth = rdr.GetDateTime(1);
        string newHome = rdr.GetString(2);
        string newName = rdr.GetString(3);
        int newAge = rdr.GetInt32(4);
        About newAbout = new About(newBirth, newHome, newName, newAge, itemId);
        allItems.Add(newAbout);
      }
        conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allItems;
     }
   public static About Find(int id)
   {
    MySqlConnection conn = DB.Connection();
    conn.Open();
    var cmd = conn.CreateCommand() as MySqlCommand;
    cmd.CommandText = @"SELECT * FROM about WHERE id = @thisId;";
    MySqlParameter thisId = new MySqlParameter();
    thisId.ParameterName = "@thisId";
    thisId.Value = id;
    cmd.Parameters.Add(thisId);
    var rdr = cmd.ExecuteReader() as MySqlDataReader;
    DateTime newBirth = new DateTime(2011, 6, 10);
    int itemId = 0;
    string newHome = "";
    string newName = "";
    int newAge = 0;
    while(rdr.Read())
    {
    itemId = rdr.GetInt32(0);
    newBirth = rdr.GetDateTime(1);
    newHome = rdr.GetString(2);
    newName = rdr.GetString(3);
    newAge = rdr.GetInt32(4);
  }
    About foundAbout = new About(newBirth, newHome, newName, newAge, itemId);
    conn.Close();
    if (conn != null)
    {
      conn.Dispose();
    }
    return foundAbout;
   }

     public void Edit(DateTime newBirthDate, string newHomeCity, string newName, int newAge)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      var cmd1 = conn.CreateCommand() as MySqlCommand;
      var cmd2 = conn.CreateCommand() as MySqlCommand;
      var cmd3= conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"UPDATE about SET birthDate = @newBirthDate WHERE id = @searchId;";
      cmd1.CommandText = @"UPDATE about SET homeCity = @newHomeCity WHERE id = @searchId;";
      cmd2.CommandText = @"UPDATE about SET name= @newName WHERE id = @searchId;";
      cmd3.CommandText = @"UPDATE about SET age = @newAge WHERE id = @searchId;";
      MySqlParameter searchId = new MySqlParameter();
      searchId.ParameterName = "@searchId";
      searchId.Value = Id;
      cmd.Parameters.Add(searchId);
      MySqlParameter birthDate = new MySqlParameter();
      birthDate.ParameterName = "@newBirthDate";
      birthDate.Value = newBirthDate;
      cmd.Parameters.Add(birthDate);

      cmd1.Parameters.Add(searchId);
      MySqlParameter homeCity = new MySqlParameter();
      homeCity.ParameterName = "@newHomeCity";
      homeCity.Value = newHomeCity;
      cmd1.Parameters.Add(homeCity);

      cmd2.Parameters.Add(searchId);
      MySqlParameter name = new MySqlParameter();
      name.ParameterName = "@newName";
      name.Value = newName;
      cmd2.Parameters.Add(name);

      cmd3.Parameters.Add(searchId);
      MySqlParameter age = new MySqlParameter();
      age.ParameterName = "@newAge";
      age.Value = newAge;
      cmd3.Parameters.Add(age);
      cmd.ExecuteNonQuery();
      cmd1.ExecuteNonQuery();
      cmd2.ExecuteNonQuery();
      cmd3.ExecuteNonQuery();
      BirthDate = newBirthDate;
      HomeCity = newHomeCity;
      Name = newName;
      Age = newAge;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

   public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO about (birthDate, homeCity, name, age) VALUES (@AboutBirthDate, @AboutHomeCity, @AboutName, @AboutAge);";


      MySqlParameter birthDate = new MySqlParameter();
      birthDate.ParameterName = "@AboutBirthDate";
      birthDate.Value = this.BirthDate;
      cmd.Parameters.Add(birthDate);

      MySqlParameter homeCity = new MySqlParameter();
      homeCity.ParameterName = "@AboutHomeCity";
      homeCity.Value = this.HomeCity;
      cmd.Parameters.Add(homeCity);

      MySqlParameter name = new MySqlParameter();
      name.ParameterName = "@AboutName";
      name.Value = this.Name;
      cmd.Parameters.Add(name);

      MySqlParameter age = new MySqlParameter();
      age.ParameterName = "@AboutAge";
      age.Value = this.Age;
      cmd.Parameters.Add(age);

      cmd.ExecuteNonQuery();
      Id = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
  }

}
