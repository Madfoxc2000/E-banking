namespace EBanking.DataAccess.Modeli
{
    public class Kartica
    {
        public string BrojKartice { get; set; }
        public string BrojRacuna { get; set; }
        public string PinKod { get; set; }
        public DateTime DatumIsteka { get; set; }
        public DateTime DatumKreiranja { get; set; }
        public string CVC { get; set; }
        public bool IsValidna { get; set; }
    }
}
