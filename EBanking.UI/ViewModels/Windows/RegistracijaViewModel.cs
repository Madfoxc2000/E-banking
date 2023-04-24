using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EBanking.Services;
using EBanking.UI.Common.Validacija;
using EBanking.UI.Models;
using EBanking.UI.Views;
using System;
using System.Windows;

namespace EBanking.UI.ViewModels.Windows
{
    public class RegistracijaViewModel : BaseViewModel<RegistracijaModel>
    {
        private readonly IKorisnikService _korisnikService;

        public RegistracijaViewModel(IKorisnikService korisnikService)
        {
           Validator = new RegistracijaViewValidator<RegistracijaModel>();
            Model.Title = "Registracija";
            _korisnikService = korisnikService;
            RegistracijaCommand = new RelayCommand(AktivirajKorisnika);
        }

        public RelayCommand RegistracijaCommand { get; set; }

        public void ShowLoginWindow()
        {
            LoginView loginView = new LoginView();
            loginView.Show();
        }

        public void AktivirajKorisnika()
        {
            if (Validator.ValidateModel(Model))
            {
                if (_korisnikService.ProveraKorisnika(Model.Email, Model.KorisnickiPin))
                {
                    if (Model.Lozinka.Equals(Model.PonoviLozinku))
                    {
                        _korisnikService.UpdateLozinkeKorisnika(Model.Email, Model.KorisnickiPin, Model.Lozinka);

                        ShowLoginWindow();

                        Close();
                    }
                    else
                    {
                        Model.Label = "Lozinke se  ne podudaraju";
                    }
                }
                else
                {
                    MessageBox.Show("Korisnicki pin i email se ne podudaraju.", "Greska");
                }
            } 
        }
    }
}

