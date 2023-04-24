using EBanking.Services.Modeli;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace EBanking.UI.Models
{
    public class MenjacnicaModel : BaseModel
    {
        public double Iznos { get; set; }
        public double KonvertovanaVrednost { get; set; }
        public RacunModel Racun { get; set; }
        public RacunModel IzabranRacun { get; set; }
        public List<RacunModel> RacuniKorisnika { get; set; }
        public ObservableCollection<RacunModel> Racuni { get; set; }
    }
}
