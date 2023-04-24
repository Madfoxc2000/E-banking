using EBanking.UI.Models;

namespace EBanking.UI.Common.Validacija
{
    public class LoginViewValidator<TModel> : IValidator<TModel> where TModel : LoginModel // TModel je tipa LoginModel u ovom valiudatoru
    {
        //Stanje modela, ako je true, sve radi i ne izbacuje greske za validaciju

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

            if (model.Password == null || model.Password == "")
            {
                model.PasswordError = "Niste uneli sifru";
                errors++;
            }
            else
            {
                model.PasswordError = null;
            }

            return errors == 0;
        }
    }
}
