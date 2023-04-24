using EBanking.DataAccess.Modeli;
using System.Data.SqlClient;

namespace EBanking.DataAccess.Repozitorijumi.Implementacija
{
    public class RepozitorijumTekucegRacuna : IRepozitorijumTekucegRacuna
    {
        private const string _konekcioniString = @"Data Source = .\SQLEXPRESS01;Initial Catalog=eBanking;Integrated Security=True";

        public void CreateRacun(TekuciRacun model)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_konekcioniString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = "INSERT INTO TekuciRacun(brojRacuna, idKorisnika, balans, valuta, tip, datumKreiranja)" +
                        "VALUES(@brojRacuna, @idKorisnika, @balans, @valuta, @tip, @datumKreiranja)";
                    sqlCommand.Parameters.AddWithValue("@brojRacuna", model.BrojRacuna);
                    sqlCommand.Parameters.AddWithValue("@idKorisnika", model.IdKorisnika);
                    sqlCommand.Parameters.AddWithValue("@balans", model.Balans);
                    sqlCommand.Parameters.AddWithValue("@valuta", model.Valuta);
                    sqlCommand.Parameters.AddWithValue("@tip", model.Tip);
                    sqlCommand.Parameters.AddWithValue("@datumKreiranja", model.DatumKreiranja);

                    sqlCommand.ExecuteScalar();
                }
            }

        }

        public async Task<TekuciRacun> GetRacunByBrojRacuna(string brojRacuna)
        {
            TekuciRacun racun = new TekuciRacun();

            using (SqlConnection sqlConnection = new SqlConnection(_konekcioniString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = "SELECT * FROM TekuciRacun WHERE brojRacuna = @brojRacuna";
                    sqlCommand.Parameters.AddWithValue("@brojRacuna", brojRacuna);

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            racun.IdKorisnika = (int)reader["idKorisnika"];
                            racun.BrojRacuna = reader["brojRacuna"] as string;
                            racun.Balans = decimal.ToDouble((decimal)reader["balans"]);
                            racun.DatumKreiranja = (DateTime)reader["datumKreiranja"];
                            racun.Tip = reader["tip"] as string;
                            racun.Valuta = reader["valuta"] as string;
                        }
                    }
                }

            }

            return racun;
        }

        //Vraca listu racuna za korisnika, svaki racun u sebi ima informacije o korinsiku
        public List<TekuciRacun> GetRacuniByKorsnikId(int idKorisnika)
        {
            List<TekuciRacun> racuni = new List<TekuciRacun>();

            using (SqlConnection sqlConnection = new SqlConnection(_konekcioniString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = "SELECT * FROM TekuciRacun INNER JOIN Korisnik ON TekuciRacun.idKorisnika = Korisnik.idKorisnika WHERE Korisnik.idKorisnika = @idKorisnika";
                    sqlCommand.Parameters.AddWithValue("@idKorisnika", idKorisnika);

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            racuni.Add(new TekuciRacun
                            {
                                IdKorisnika = (int)reader["idKorisnika"],
                                BrojRacuna = reader["brojRacuna"] as string,
                                Balans = decimal.ToDouble((decimal)reader["balans"]),
                                DatumKreiranja = (DateTime)reader["datumKreiranja"],
                                Tip = reader["tip"] as string,
                                Valuta = reader["valuta"] as string,
                                Korisnik = new Korisnik
                                {
                                    Ime = reader["ime"] as string,
                                    Prezime = reader["prezime"] as string,
                                    DatumRodjenja = (DateTime)reader["datumRodjenja"],
                                    Email = reader["email"] as string,
                                    Lozinka = reader["lozinka"] as string
                                }
                            });
                        }
                    }
                }

            }
            return racuni;
        }

        public bool IsValidRacun(string brojRacuna)
        {
            object idRacuna;

            using (SqlConnection sqlConnection = new SqlConnection(_konekcioniString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = "SELECT * FROM TekuciRacun WHERE brojRacuna = @brojRacuna";
                    sqlCommand.Parameters.AddWithValue("@brojRacuna", brojRacuna);

                    idRacuna = sqlCommand.ExecuteScalar();
                }
            }

            return idRacuna as string is not null;
        }

        public void UpdateBalance(double balans, string brojRacuna)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_konekcioniString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = "UPDATE TekuciRacun SET balans = @balans WHERE brojRacuna = @brojRacuna";
                    sqlCommand.Parameters.AddWithValue("@balans", balans);
                    sqlCommand.Parameters.AddWithValue("@brojRacuna", brojRacuna);

                    sqlCommand.ExecuteScalar();
                }
            }
        }
    }
}
