using EBanking.UI.Models;

namespace EBanking.UI.Common.Validacija
{
    public class PlacanjeViewValidator<TModel> : IValidator<TModel> where TModel : PlacanjeModel
    {
        public bool ValidateModel(TModel model)
        {
            int errors = 0;

            if (model.BrojRacunaPrimaoca == null || model.BrojRacunaPrimaoca == "")
            {
                model.BrojRacunaPrimaocaError = "Niste uneli broj racuna primaoca";
                errors++;
            }
            else
            {
                model.BrojRacunaPrimaocaError = null;
            }

            if (model.NazivPrimaoca == null || model.NazivPrimaoca == "")
            {
                model.NazivPrimaocaError = "Niste uneli naziv primaoca";
                errors++;
            }
            else
            {
                model.NazivPrimaocaError = null;
            }

            if (model.KolicinaNovca == null || model.KolicinaNovca <= 0)
            {
                model.KolicinaNovcaError = "Niste uneli iznos novca";
                errors++;
            }
            else
            {
                model.KolicinaNovcaError = null;
            }

            if (model.SvrhaPlacanja == null || model.SvrhaPlacanja == "")
            {
                model.SvrhaPlacanjaError = "Niste uneli svrhu placanja";
                errors++;
            }
            else
            {
                model.SvrhaPlacanjaError = null;
            }

            return errors == 0;
        }
    }
}
