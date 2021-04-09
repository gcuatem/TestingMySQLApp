using MySql.Data.MySqlClient;
using System;

namespace TestingMySQLApp
{
  class Program
  {
    static void Main(string[] args)
    {
      //Create a connection to your local MySQL Server, for this example, create manually a database named "dbtest", and a user named "test" with password "test"
      using (var connection= new MySqlConnection("server=localhost;user=test;password=test;port=3306;database=dbtest;"))
      {
        connection.Open();
        var cmd = new MySqlCommand("drop table if exists people;", connection);  
        cmd.ExecuteNonQuery();
        cmd = new MySqlCommand("create table people(id int,name varchar(80));", connection); //Create a table
        cmd.ExecuteNonQuery();
        cmd = new MySqlCommand("Insert into people values(1,'Charles');Insert into people values(2,'Benjamin');", connection);//insert some records
        cmd.ExecuteNonQuery();
        cmd = new MySqlCommand("select * from people", connection);
        var result = cmd.ExecuteReader();
        while (result.Read())
        {
          Console.WriteLine("ID = "+ result.GetInt32(0) + ", Name = " + result.GetString(1));
        }
        Console.ReadLine();
      }
    }
  }
}
