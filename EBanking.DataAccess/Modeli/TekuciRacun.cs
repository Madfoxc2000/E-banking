namespace EBanking.DataAccess.Modeli
{
    public class TekuciRacun
    {
        public string BrojRacuna { get; set; }
        public int IdKorisnika { get; set; }
        public double Balans { get; set; }
        public string Tip { get; set; }
        public string Valuta { get; set; }
        public DateTime DatumKreiranja { get; set; }
        public Korisnik Korisnik { get; set; }

        public List<Transakcija> Transakcije { get; set; }
    }
}