using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common1.Model;

namespace Baza
{
    public class BazaImpl:IBaza
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
        /*public void DeleteDevice(int id)
        {

            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "Delete from Device where DeviceId=@DeviceId";


                command.Parameters.AddWithValue("@DeviceId", id);

                command.ExecuteNonQuery();
            }

        }
        public void UpdateDevice(DeviceClass d, int id)
        {
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "Update device set VremeMerenja=@VremeMerenja,TemperaturaMerenja=@TemperaturaMerenja where DeviceId=@DeviceId";

                command.Parameters.AddWithValue("@VremeMerenja", d.Vreme_merenja);
                command.Parameters.AddWithValue("@TemperaturaMerenja", d.Temperatura_merenja);
                command.Parameters.AddWithValue("@DeviceId", id);

                command.ExecuteNonQuery();
            }
        }*/

       

        


        public void InsertDevice(DeviceClass d)
        {
            using (SqlCommand command = new SqlCommand())
            {

                command.Connection = connection;
                command.CommandText = "INSERT INTO Device (VremeMerenja,TemperaturaMerenja) VALUES (@VremeMerenja,@TemperaturaMerenja)";


                command.Parameters.AddWithValue("@VremeMerenja", d.Vreme_merenja);
                command.Parameters.AddWithValue("@TemperaturaMerenja", d.Temperatura_merenja);


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

        public void DeleteAllDevice() {
            using (SqlCommand command = new SqlCommand())
            {

                command.Connection = connection;
                command.CommandText = "Delete from Device";


                


                int result = command.ExecuteNonQuery();

                if (result != 0)
                {
                    Console.WriteLine("Uspesno izbrisano iz baze");
                }
                else
                {
                    Console.WriteLine("Nismo uspeli da izbrisemo");
                }
            }

        }

        public void DeleteAllRegulator()
        {
            using (SqlCommand command = new SqlCommand())
            {

                command.Connection = connection;
                command.CommandText = "Delete from Regulator";





                int result = command.ExecuteNonQuery();

                if (result != 0)
                {
                    Console.WriteLine("Uspesno izbrisano iz baze");
                }
                else
                {
                    Console.WriteLine("Nismo uspeli da izbrisemo");
                }
            }

        }

        public void DeleteAllHeater()
        {
            using (SqlCommand command = new SqlCommand())
            {

                command.Connection = connection;
                command.CommandText = "Delete from Heater";





                int result = command.ExecuteNonQuery();

                if (result != 0)
                {
                    Console.WriteLine("Uspesno izbrisano iz baze");
                }
                else
                {
                    Console.WriteLine("Nismo uspeli da izbrisemo");
                }
            }

        }
        public List<DeviceClass> GetDevices()
        {
            List<DeviceClass> devices = new List<DeviceClass>();

            using (SqlCommand command = new SqlCommand())
            {

                command.Connection = connection;
                command.CommandText = "select DeviceId,VremeMerEnja,TemperaturaMerenja from Device";

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        DateTime dt = reader.GetDateTime(1);
                        float temp=(float)reader.GetDouble(2);
                        DeviceClass d = new DeviceClass(id,dt,temp);
                        devices.Add(d);
                    }
                }




            }

            return devices;
        }



        public List<RegulatorClass> GetRegulator()
        {
            List<RegulatorClass> regulatori = new List<RegulatorClass>();

            using (SqlCommand command = new SqlCommand())
            {

                command.Connection = connection;
                command.CommandText = "select IdT,PocetakDnevnog,KrajDnevnog,PocetakNocnog,KrajNocnog,DnevnaTemperatura,NocnaTemperatura from Regulator";

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        RegulatorClass r = new RegulatorClass(reader.GetInt32(0), reader.GetDateTime(1), reader.GetDateTime(2), reader.GetDateTime(3)
                            , reader.GetDateTime(4),(float)reader.GetDouble(5), (float)reader.GetDouble(6));
                        regulatori.Add(r);
                    }
                }




            }

            return regulatori;
        }



        public void InsertRegulator(RegulatorClass r)
        {
            using (SqlCommand command = new SqlCommand())
            {

                command.Connection = connection;
                command.CommandText = "INSERT INTO Regulator (IdT,PocetakDnevnog,KrajDnevnog,PocetakNocnog,KrajNocnog" +
                    " ,DnevnaTemperatura,NocnaTemperatura) VALUES (@IdT,@PocetakDnevnog,@KrajDnevnog,@PocetakNocnog,@KrajNocnog" +
                    ", @DnevnaTemperatura,@NocnaTemperatura)";

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

        public void InsertHeater(HeaterClass h)
        {
            using (SqlCommand command = new SqlCommand())
            {

                command.Connection = connection;
                command.CommandText = "INSERT INTO Heater (PocetakRada,VremeRada,Resursi) VALUES (@PocetakRada,@VremeRada,@Resursi)";

                command.Parameters.AddWithValue("@PocetakRada", h.Pocetak);
                command.Parameters.AddWithValue("@VremeRada", h.Trajanje);
                command.Parameters.AddWithValue("@Resursi", h.PotroseniResursi);
                


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


        public List<HeaterClass> GetHeater()
        {
            List<HeaterClass> heaters = new List<HeaterClass>();

            using (SqlCommand command = new SqlCommand())
            {

                command.Connection = connection;
                command.CommandText = "select PocetakRada,VremeRada,Resursi from Heater";

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                       HeaterClass h = new HeaterClass();
                        heaters.Add(h);
                    }
                }




            }

            return heaters;
        }

        public float ProsjekTemperaturaDeviceBaza() {
            float prosjek = 0;
            using (SqlCommand command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "SELECT AVG(TemperaturaMerenja) FROM Device";
                using (SqlDataReader reader = command.ExecuteReader()) {
                    while (reader.Read())
                    {
                        prosjek = (float)reader.GetDouble(0);

                    }
                    
                }
            }
            return prosjek;
        }
        /*public float ProsjekTemperaturaDeviceBaza()
        {
            float prosjek = 0;
            using (SqlCommand command = new SqlCommand())
            {
                command.CommandText = "SELECT AVG(TemperaturaMerenja) FROM Device";
                prosjek = (float)command.ExecuteScalar();
            }
            return prosjek;
        }*/
    }
}
