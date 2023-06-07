using Microsoft.Data.SqlClient;

namespace Deneme1
{
    public interface futbol
    {
        List<Deneme> GetAllData();
        Deneme GetFutbolID(int id);
        void Create(Deneme futbol);
        void Update(Deneme futbol);
        void Delete (int TakımID);
    }

    public class Takımlar1 : futbol
    {

        static SqlConnection GetSqlConnection()
        {
            string connectionString = @"Data Source=DESKTOP-41H4HUT\SQLEXPRESS; Initial Catalog=federasyon; Integrated Security=SSPI;";
            return new SqlConnection(connectionString);
        }
       

        public void Create(Deneme futbol)
        {
            throw new NotImplementedException();
        }

        public void Delete(int TakımID)
        {
            throw new NotImplementedException();
        }

        public List<Deneme> GetAllData()
        {
            List<Deneme> Futbolcular = null;
            using (var connection = GetSqlConnection()) 
            { 
                try
                {
                    connection.Open();
                    string sgl = "select * from Takımlar";
                    SqlCommand command = new SqlCommand(sgl, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    Futbolcular = new List<Deneme>();

                    while (reader.Read())
                    {
                        Futbolcular.Add(new Deneme()
                        {
                            TakımID = int.Parse(reader["TakımID"].ToString()),
                            TakımAdı = reader["TakımAdı"].ToString(),
                            TakRenk = reader["Renk1"].ToString(),
                            Taksampi = int.Parse(reader["SampiyonlukSayısı"].ToString()),
                          }

                          );
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                }

            }
            return Futbolcular;
        }

        public Deneme GetFutbolID(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Deneme futbol)
        {
            throw new NotImplementedException();
        }
    }

    public class Takımlar2 : futbol
    {
        futbol _futbolcu;

        public Takımlar2(futbol futbolcu1)
        {
            _futbolcu = futbolcu1;
        }

        public void Create(Deneme futbol)
        {
            throw new NotImplementedException();
        }

        public void Delete(int TakımID)
        {
            throw new NotImplementedException();
        }

        public List<Deneme> GetAllData()
        {
            return _futbolcu.GetAllData();
        }

        public Deneme GetFutbolID(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Deneme futbol)
        {
            throw new NotImplementedException();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var futbolcu1 = new Takımlar2(new Takımlar1());

            var data = futbolcu1.GetAllData();

            foreach (var item in data) 
            {
                Console.WriteLine($"Takım no: {item.TakımID} Takım ad: {item.TakımAdı} TakımRenk: {item.TakRenk} Şampiyonluk: {item.Taksampi}");
            }
        }
    }
}