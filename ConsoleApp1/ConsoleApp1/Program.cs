using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
  

namespace ConsoleApp1
    {
        internal class Program
        {
            private static string connectionString = "Server=localhost\\MSSQLSERVER01;Database=primer;Trusted_Connection=True;";

            static void Main(string[] args)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        Console.WriteLine("Connection opened successfully");
                        Insert(connection, new User(1, "Marko", "Markovic", "hgasdjkg@gmail.com"));
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.Read();
            }

            public static void Insert(SqlConnection connection, User user)
            {
                using (SqlCommand command = new SqlCommand("INSERT INTO KOR (FirstName, LastName, Email) VALUES (@FirstName, @LastName, @Email)", connection))
                {
                    command.Parameters.AddWithValue("@FirstName", user.FirstName);
                    command.Parameters.AddWithValue("@LastName", user.LastName);
                    command.Parameters.AddWithValue("@Email", user.Email);

                    int result = command.ExecuteNonQuery();

                    if (result != 0)
                    {
                        Console.WriteLine("Successfully inserted into the database");
                    }
                    else
                    {
                        Console.WriteLine("Failed to insert into the database");
                    }
                }
            }
        }
    }


}

