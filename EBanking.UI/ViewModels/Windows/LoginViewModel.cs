using CommunityToolkit.Mvvm.Input;
using EBanking.Services;
using EBanking.UI.Common.Validacija;
using EBanking.UI.Models;
using EBanking.UI.Views;
using System.Windows;

namespace EBanking.UI.ViewModels.Windows
{
    public class LoginViewModel : BaseViewModel<LoginModel>
    {
        private readonly IKorisnikService _korisnikService;
        private readonly IRacunService _racunService;
        private readonly ITransakcijaService _transakcijaService;
        private readonly IMenjacnicaService _menjacnicaService;

        public LoginViewModel(IKorisnikService korisnikService, IRacunService racunService, ITransakcijaService transakcijaService, IMenjacnicaService menjacnicaService)
        {
            Validator = new LoginViewValidator<LoginModel>();
            _korisnikService = korisnikService;
            _racunService = racunService;
            _transakcijaService = transakcijaService;

            Model.Title = "Login";

            LoginCommand = new RelayCommand(Login);
            OtvoriRegistracijuCommand = new RelayCommand(Registracija);
            _transakcijaService = transakcijaService;
            _menjacnicaService = menjacnicaService;
        }

        public RelayCommand LoginCommand { get; set; }

        public RelayCommand OtvoriRegistracijuCommand { get; set; }

        public void Login()
        {
            var idKorisnika = _korisnikService.Login(Model.Email, Model.Password);
            if (idKorisnika == 0)
            {
                MessageBox.Show("Korisničko ime i lozinka se ne poklapaju.", "Greska");
            }
            if (Validator.ValidateModel(Model) && idKorisnika is not 0)
            {
                RacunView tekuciRacunView = new RacunView
                {
                    DataContext = new TekuciRacunViewModel(_racunService, _transakcijaService, _menjacnicaService, idKorisnika)
                };
                tekuciRacunView.Closing += (s, o) =>
                {
                    LoginView view = new LoginView
                    {
                        DataContext = this
                    };
                    view.Show();
                };
                tekuciRacunView.Show();
                Close();
            }
        }

        public void Registracija()
        {
            RegistracijaView registracijaView = new RegistracijaView();
            registracijaView.Show();
            Close();
        }
    }
}
