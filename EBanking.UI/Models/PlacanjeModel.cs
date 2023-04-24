namespace EBanking.UI.Models
{
    public class PlacanjeModel : BaseModel
    {
        public string BrojRacunaPlatioca { get; set; }
        public double TrenutnoStanje { get; set; }
        public string NazivPrimaoca { get; set; }
        public string BrojRacunaPrimaoca { get; set; }
        public string PozivNaBroj { get; set; }
        public string SvrhaPlacanja { get; set; }
        public double KolicinaNovca { get; set; }

        #region Validacija
        public string BrojRacunaPlatiocaError { get; set; }
        public string NazivPrimaocaError { get; set; }
        public string BrojRacunaPrimaocaError { get; set; }
        public string PozivNaBrojError { get; set; }
        public string SvrhaPlacanjaError { get; set; }
        public string KolicinaNovcaError { get; set; }
        #endregion
    }
}
