namespace EBanking.Services.Modeli
{
    public class KorisnikModel
    {
        public int IdKorisnika { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string BrojLicneKarte { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
    }
}
