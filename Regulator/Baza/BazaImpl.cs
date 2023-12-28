using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Baza.Model;

namespace Baza
{
    public class BazaImpl : IBaza
    {
        private static SqlConnection connection = null;
        private static string connectionString;
        private static BazaImpl instance = null;

        public BazaImpl()
        {
            GetConnection();

        }

        public static BazaImpl GetBaza()
        {
            if (instance == null)
            {
                instance = new BazaImpl();
            }

            return instance;
        }

        public bool Konektuj()
        {
            try
            {
                connectionString = "Server=localhost\\MSSQLSERVER01;Database=Projekat;Trusted_Connection=True;";
                connection = new SqlConnection(connectionString);
                connection.Open();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public void GetConnection()
        {
            if (connection == null)
            {
                if (Konektuj())
                {
                    Console.WriteLine("Uspesno smo se konektovali");
                }
                else
                {
                    Console.WriteLine("Nismo uspostavili konekciju");
                }
            }

        }
        public void DeleteDevice(int id)
        {

            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "Delete from Device where DeviceId=@DeviceId";

               
                command.Parameters.AddWithValue("@DeviceId", id);

                command.ExecuteNonQuery();
            }

        }
        public void UpdateDevice(Device d,int id)
        {
            using (SqlCommand command = new SqlCommand()) {
                command.Connection = connection;
                command.CommandText = "Update device set VremeMerenja=@VremeMerenja,TemperaturaMerenja=@TemperaturaMerenja where DeviceId=@DeviceId";

                command.Parameters.AddWithValue("@VremeMerenja", d.Vreme_merenja);
                command.Parameters.AddWithValue("@TemperaturaMerenja",d.Temperatura_merenja);
                command.Parameters.AddWithValue("@DeviceId", id);

                command.ExecuteNonQuery();
            }
        }
        public  void InsertDevice(Device d)
        {
            using (SqlCommand command = new SqlCommand())
            {

                command.Connection = connection;
                command.CommandText = "INSERT INTO Device (VremeMerenja,TemperaturaMerenja) VALUES (@VremeMerenja,@TemperaturaMerenja)";

                
                command.Parameters.AddWithValue("@VremeMerenja", d.Vreme_merenja);
                command.Parameters.AddWithValue("@TemperaturaMerenja",d.Temperatura_merenja);


                int result = command.ExecuteNonQuery();

                if (result != 0)
                {
                    Console.WriteLine("Uspesno ubacen u bazu");
                }
                else
                {
                    Console.WriteLine("Nismo uspeli da upisemo u bazu");
                }
            }


        }


        public void InsertRegulator(Regulator r)
        {
            using (SqlCommand command = new SqlCommand())
            {

                command.Connection = connection;
                command.CommandText = "INSERT INTO Regulator (IdT,PocetakDnevnog,KrajDnevnog,PocetakNocnog,KrajNocnog" +
                    " ,DnevnaTemperatura,NocnaTemperatura) VALUES (@IdT,@PocetakDnevnog,@KrajDnevnog,@PocetakNocnog,@KrajNocnog" +
                    " @DnevnaTemperatura,@NocnaTemperatura)";

                command.Parameters.AddWithValue("@IdT", r.TempId);
                command.Parameters.AddWithValue("@PocetakDnevnog", r.Pocetak_dnevnog);
                command.Parameters.AddWithValue("@KrajDnevnog", r.Kraj_dnevnog);
                command.Parameters.AddWithValue("@PocetakNocnog", r.Pocetak_nocnog);
                command.Parameters.AddWithValue("@KrajNocnog", r.Kraj_nocnog);
                command.Parameters.AddWithValue("@DnevnaTemperatura", r.Dnevna_temperatura);
                command.Parameters.AddWithValue("@NocnaTemperatura", r.Nocna_temperatura);


                int result = command.ExecuteNonQuery();

                if (result != 0)
                {
                    Console.WriteLine("Uspesno ubacen u bazu");
                }
                else
                {
                    Console.WriteLine("Nismo uspeli da upisemo u bazu");
                }
            }


        }

    }
}
    



