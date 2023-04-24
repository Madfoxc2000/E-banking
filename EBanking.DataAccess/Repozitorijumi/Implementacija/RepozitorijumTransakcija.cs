using EBanking.DataAccess.Modeli;
using System.Data.SqlClient;

namespace EBanking.DataAccess.Repozitorijumi.Implementacija
{
    public class RepozitorijumTransakcija : IRepozitorijumTransakcija
    {
        private const string _konekcioniString = @"Data Source = .\SQLEXPRESS01;Initial Catalog=eBanking;Integrated Security=True";

        public int CreateTransakcija(Transakcija transakcija)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_konekcioniString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = "INSERT INTO Transakcija(brojRacuna, brojKartice, kolicinaNovca, balansNakonTransakcije, datum, nazivSekundarnogAktera, brojRacunaSekundarnogAktera)" +
                        " VALUES (@brojRacuna, @brojKartice, @kolicinaNovca, @balansNakonTransakcije, @datum, @nazivSekundarnogAktera, @brojRacunaSekundarnogAktera)";
                    sqlCommand.Parameters.AddWithValue("@brojRacuna", transakcija.BrojRacuna);
                    sqlCommand.Parameters.AddWithValue("@brojKartice", transakcija.BrojKartice);
                    sqlCommand.Parameters.AddWithValue("@kolicinaNovca", transakcija.KolicinaNovca);
                    sqlCommand.Parameters.AddWithValue("@balansNakonTransakcije", transakcija.BalansNakonTransakcije);
                    sqlCommand.Parameters.AddWithValue("@datum", transakcija.Datum);
                    sqlCommand.Parameters.AddWithValue("@nazivSekundarnogAktera", transakcija.NazivSekundarnogAktera);
                    sqlCommand.Parameters.AddWithValue("@brojRacunaSekundarnogAktera", transakcija.BrojRacunaSekundarnogAktera);

                    return sqlCommand.ExecuteNonQuery();
                }
            }
        }

        public List<Transakcija> GetTransakcijeByBrojRacuna(string brojRacuna)
        {
            List<Transakcija> listaTransakcija = new List<Transakcija>();

            using (SqlConnection sqlConnection = new SqlConnection(_konekcioniString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = "SELECT * FROM Transakcija WHERE brojRacuna = @brojRacuna";
                    sqlCommand.Parameters.AddWithValue("@brojRacuna",brojRacuna);
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listaTransakcija.Add(new Transakcija
                            {
                                IdTransakcije = (int)reader["idTransakcije"],
                                BrojKartice = reader["brojKartice"] as string,
                                BrojRacuna = reader["brojRacuna"] as string,
                                KolicinaNovca = decimal.ToDouble((decimal)reader["kolicinaNovca"]),
                                BalansNakonTransakcije = decimal.ToDouble((decimal)reader["balansNakonTransakcije"]),
                                Datum = (DateTime)reader["datum"],
                                NazivSekundarnogAktera = reader["nazivSekundarnogAktera"] as string,
                                BrojRacunaSekundarnogAktera = reader["brojRacunaSekundarnogAktera"] as string
                            });
                        }
                    }
                }
            }
            return listaTransakcija;
        }
    }
}
