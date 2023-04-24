namespace EBanking.Services.Modeli
{
    public class TransakcijaModel
    {
        public int IdTransakcije { get; set; }
        public string BrojRacuna { get; set; }
        public string BrojKartice { get; set; }
        public double KolicinaNovca { get; set; }
        public double BalansNakonTransakcije { get; set; }
        public DateTime Datum { get; set; }
        public string NazivSekundarnogAktera { get; set; }
        public string BrojRacunaSekundarnogAktera { get; set; }
    }
}
