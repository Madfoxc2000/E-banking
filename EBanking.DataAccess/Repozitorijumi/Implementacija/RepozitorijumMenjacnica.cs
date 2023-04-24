using EBanking.DataAccess.Modeli;
using System.Data.SqlClient;

namespace EBanking.DataAccess.Repozitorijumi.Implementacija
{
    public class RepozitorijumMenjacnica : IRepozitorijumMenjacnica
    {
        private const string _konekcioniString = @"Data Source = .\SQLEXPRESS01;Initial Catalog=eBanking;Integrated Security=True";

        public List<Menjacnica> GetMenjacnicaByValuta(string valuta)
        {
            List<Menjacnica> menjacnice = new List<Menjacnica>();


            using (SqlConnection sqlConnection = new SqlConnection(_konekcioniString))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = "SELECT * FROM Menjacnica WHERE valutaRacuna = @valuta";
                    sqlCommand.Parameters.AddWithValue("@valuta", valuta);

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            menjacnice.Add(new Menjacnica
                            {
                                Valuta = reader["valuta"] as string,
                                Vrednost = decimal.ToDouble((decimal)reader["vrednost"]),
                            });
                        }
                    }
                }

            }
            return menjacnice;
        }
    }
}
