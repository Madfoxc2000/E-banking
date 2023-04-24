using System.Collections.Generic;

namespace EBanking.UI.Models
{
    public class TekuciRacunModel : BaseModel
    {
        public string BrojRacuna { get; set; }
        public double Balans { get; set; }
        public string ImeKorsnika { get; set; }
        public Services.Modeli.RacunModel IzabranRacun { get; set; }
        public List<Services.Modeli.RacunModel> Racuni { get; set; }
        public List<Services.Modeli.TransakcijaModel> Transakcije { get; set; }
        public Services.Modeli.TransakcijaModel IzabranaTransakcija { get; set; }
    }
}
