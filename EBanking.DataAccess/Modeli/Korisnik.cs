namespace EBanking.DataAccess.Modeli
{
    public class Korisnik
    {
        public int IdKorisnika { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string BrojLicneKarte { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string KorisnickiPin { get; set; }
        public string Lozinka { get; set; }
    }
}
