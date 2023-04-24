using CommunityToolkit.Mvvm.Input;
using EBanking.Services;
using EBanking.Services.Modeli;
using EBanking.UI.Models;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows;

namespace EBanking.UI.ViewModels.Windows
{
    public class MenjacnicaViewModel : BaseViewModel<UI.Models.MenjacnicaModel>
    {
        private readonly ITransakcijaService _transakcijaService;
        private readonly IRacunService _racunService;
        private readonly IMenjacnicaService _menjacnicaService;
      

        [PreferredConstructor]
        public MenjacnicaViewModel()
        {
            Model.Title = "Menjacnica";
        }

        public MenjacnicaViewModel(ITransakcijaService transakcijaService, 
            IRacunService racunService, 
            IMenjacnicaService menjacnicaService,
            RacunModel racun,
            List<RacunModel> racuniKorisnika,
            string imeKorisnika)
        {
            Model.Title = "Menjacnica";
            Model.Racun = racun;
            Model.RacuniKorisnika = racuniKorisnika;
            Model.Racuni = new System.Collections.ObjectModel.ObservableCollection<RacunModel>(Model.RacuniKorisnika);
            _transakcijaService = transakcijaService;
            _racunService = racunService;
            _menjacnicaService = menjacnicaService;
            KonvertujCommand = new RelayCommand(Konvertuj);
            PokreniTransakcijuCommand = new RelayCommand(Transakcija);
            ImeKorisnika = imeKorisnika;
        }

        public RelayCommand KonvertujCommand { get; set; }
        public RelayCommand PokreniTransakcijuCommand { get; set; }
        public string ImeKorisnika { get; set; }

        public void Konvertuj()
        {
            if (Model.IzabranRacun == null)
            {
                MessageBox.Show("Niste odabrali racun");
            }
            else
            {
                var enumToSwitch = (ValutaRacuna)Enum.Parse(typeof(ValutaRacuna), Model.IzabranRacun.Valuta);

                switch (enumToSwitch)
                {
                    case ValutaRacuna.Dinar:
                        Model.KonvertovanaVrednost = Model.Iznos * Model.Racun.Kursevi.FirstOrDefault(x => x.Valuta.Equals(Valute.RSD.ToString())).Vrednost;
                        break;
                    case ValutaRacuna.Euro:
                        Model.KonvertovanaVrednost = Model.Iznos * Model.Racun.Kursevi.FirstOrDefault(x => x.Valuta.Equals(Valute.EUR.ToString())).Vrednost;
                        break;
                }
            }
        }
        public void Transakcija()
        {
            if (Model.Racun.Balans > Model.Iznos)
            {
                _transakcijaService.CreateTransakcija(new TransakcijaModel
                {
                    BrojRacuna = Model.Racun.BrojRacuna,
                    KolicinaNovca = Model.Iznos,
                    BrojRacunaSekundarnogAktera = Model.IzabranRacun.BrojRacuna,
                    NazivSekundarnogAktera = ImeKorisnika,
                    BalansNakonTransakcije = Model.Racun.Balans - Model.Iznos,
                    Datum = DateTime.UtcNow
                });

                _racunService.UpdateBalance(Model.Racun.Balans - Model.Iznos, Model.Racun.BrojRacuna);

                DodajTransakcijuPrimaocu();
                Close();
            }
            else {
                MessageBox.Show("Nemate dovoljno sredstava na racunu");
                 }
        }

        private void DodajTransakcijuPrimaocu()
        {
            _transakcijaService.CreateTransakcija(new TransakcijaModel
            {
                BrojRacuna = Model.IzabranRacun.BrojRacuna,
                KolicinaNovca = Model.KonvertovanaVrednost,
                BrojRacunaSekundarnogAktera = Model.Racun.BrojRacuna,
                NazivSekundarnogAktera = ImeKorisnika,
                BalansNakonTransakcije = Model.IzabranRacun.Balans + Model.KonvertovanaVrednost,
                Datum = DateTime.UtcNow
            });

            _racunService.UpdateBalance(Model.IzabranRacun.Balans + Model.KonvertovanaVrednost, Model.IzabranRacun.BrojRacuna);
        }
    }

    public enum Valute
    {
        EUR,
        RSD
    }

    public enum ValutaRacuna
    {
        Dinar,
        Euro
    }
}
