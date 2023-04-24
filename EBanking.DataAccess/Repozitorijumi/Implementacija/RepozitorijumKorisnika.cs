using EBanking.DataAccess.Modeli;
using System.Data.SqlClient;

namespace EBanking.DataAccess.Repozitorijumi.Implementacija
{
    public class RepozitorijumKorisnika : IRepozitorijumKorisnika
    {
        private const string _konekcioniString = @"Data Source = .\SQLEXPRESS01;Initial Catalog=eBanking;Integrated Security=True";

        public Korisnik GetKorisnikById(int id)
        {
            Korisnik korisnik = new Korisnik();


            using (SqlConnection sqlConnection = new SqlConnection(_konekcioniString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = "SELECT * FROM Korisnik WHERE idKorisnika = @id";
                    sqlCommand.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            korisnik.IdKorisnika = (int)reader["idKorisnika"];
                            korisnik.Ime = reader["ime"] as string;
                            korisnik.Prezime = reader["prezime"] as string;
                            korisnik.DatumRodjenja = (DateTime)reader["datumRodjenja"];
                            korisnik.BrojLicneKarte = reader["brojLicneKarte"] as string;
                            korisnik.Telefon = reader["telefon"] as string;
                            korisnik.Email = reader["email"] as string;
                            korisnik.KorisnickiPin = reader["korisnickiPin"] as string;
                            korisnik.Lozinka = reader["lozinka"] as string;
                        }
                    }
                }

            }
            return korisnik;
        }

        public int IsValidKorisnik(string email, string password)
        {
            object idKorisnika;

            using (SqlConnection sqlConnection = new SqlConnection(_konekcioniString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = "SELECT * FROM Korisnik WHERE email = @email AND lozinka = @lozinka";
                    sqlCommand.Parameters.AddWithValue("@email", email);
                    sqlCommand.Parameters.AddWithValue("@lozinka", password);

                    idKorisnika = sqlCommand.ExecuteScalar();
                }

            }
            var id = idKorisnika == null ? 0 : (int)idKorisnika;
            return id ;
        }

        public List<Korisnik> GetAllKorisnici()
        {
            List<Korisnik> listaKorisnika = new List<Korisnik>();

            using (SqlConnection sqlConnection = new SqlConnection(_konekcioniString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = "SELECT * FROM Korisnik";

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listaKorisnika.Add(new Korisnik
                            {
                                IdKorisnika = (int)reader["idKorisnika"],
                                Ime = reader["ime"] as string,
                                Prezime = reader["prezime"] as string,
                                DatumRodjenja = (DateTime)reader["datumRodjenja"],
                                BrojLicneKarte = reader["brojLicneKarte"] as string,
                                Telefon = reader["telefon"] as string,
                                Email = reader["email"] as string,
                                KorisnickiPin = reader["korisnickiPin"] as string,
                                Lozinka = reader["lozinka"] as string
                            });
                        }
                    }
                }
            }
            return listaKorisnika;
        }

        public int AddKorisnik(Korisnik korisnik)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_konekcioniString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = "INSERT INTO Korisnik(idKorisnika, ime, prezime, datumRodjenja, brojLicneKarte, telefon, email, korisnickiPin, lozinka" +
                        "VALUES (@idKorisnika, @ime, @prezime, @datumRodjenja, @brojLicneKarte, @telefon, @email, @korisnickiPin, @lozinka)";
                    sqlCommand.Parameters.AddWithValue("@idKorisnika", korisnik.IdKorisnika);
                    sqlCommand.Parameters.AddWithValue("@ime", korisnik.Ime);
                    sqlCommand.Parameters.AddWithValue("@prezime", korisnik.Prezime);
                    sqlCommand.Parameters.AddWithValue("@datumRodjenja", korisnik.DatumRodjenja);
                    sqlCommand.Parameters.AddWithValue("@brojLicneKarte", korisnik.BrojLicneKarte);
                    sqlCommand.Parameters.AddWithValue("@telefon", korisnik.Telefon);
                    sqlCommand.Parameters.AddWithValue("@korisnickiPin", korisnik.KorisnickiPin);
                    sqlCommand.Parameters.AddWithValue("@lozinka", korisnik.Lozinka);

                    return sqlCommand.ExecuteNonQuery();
                }
            }

        }

        public void UpdateLozinkeKorisnika(string email, string korisnickiPin, string lozinka)
        {


            using (SqlConnection sqlConnection = new SqlConnection(_konekcioniString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = "UPDATE Korisnik SET lozinka = @lozinka WHERE email = @email AND korisnickiPin = @korisnickiPin";
                    sqlCommand.Parameters.AddWithValue("@lozinka", lozinka);
                    sqlCommand.Parameters.AddWithValue("@email", email);
                    sqlCommand.Parameters.AddWithValue("@korisnickiPin", korisnickiPin);

                    sqlCommand.ExecuteScalar();

                }
            }
        }

        public bool ProveraKorisnika(string email, string korisnickiPin)
        {
            object idKorisnika;

            using (SqlConnection sqlConnection = new SqlConnection(_konekcioniString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = "SELECT * FROM Korisnik WHERE email = @email AND korisnickiPin = @korisnickiPin";
                    sqlCommand.Parameters.AddWithValue("@email", email);
                    sqlCommand.Parameters.AddWithValue("@korisnickiPin", korisnickiPin);

                    idKorisnika = sqlCommand.ExecuteScalar();
                }

            }

            return idKorisnika != null;
        }
    }
}
