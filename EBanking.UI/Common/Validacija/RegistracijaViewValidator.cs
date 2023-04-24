using EBanking.UI.Models;

namespace EBanking.UI.Common.Validacija
{
    public class RegistracijaViewValidator<TModel> : IValidator<TModel> where TModel : RegistracijaModel
    {
        public bool ValidateModel(TModel model)
        {
            var errors = 0;
            if (model.Email == null || model.Email == "")
            {
                model.EmailError = "Niste uneli E-mail";
                errors++;
            }
            else
            {
                model.EmailError = null;
            }

            if (model.KorisnickiPin == null || model.KorisnickiPin == "")
            {
                model.KorisnickiPinError = "Niste uneli korisnicki pin";
                errors++;
            }
            else
            {
                model.KorisnickiPinError = null;
            }

            if (model.Lozinka == null || model.Lozinka == "")
            {
                model.LozinkaError = "Niste uneli lozinku";
                errors++;
            }
            else
            {
                model.LozinkaError = null;
            }

            if (model.PonoviLozinku == null || model.PonoviLozinku == "")
            {
                model.PonoviLozinkuError = "Niste uneli ponovo lozinku";
                errors++;
            }
            else
            {
                model.PonoviLozinkuError = null;
            }

            return errors == 0;
        }
    }
}
