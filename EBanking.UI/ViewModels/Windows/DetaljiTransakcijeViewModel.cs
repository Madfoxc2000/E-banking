using EBanking.Services.Modeli;
using EBanking.UI.Models;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBanking.UI.ViewModels.Windows
{
    public class DetaljiTransakcijeViewModel : BaseViewModel<DetaljiTransakcijeModel>
    {
        [PreferredConstructor]
        public DetaljiTransakcijeViewModel()
        {
            Model.Title = "Detalji Transakcije";
        }
        public DetaljiTransakcijeViewModel(TransakcijaModel transakcijaModel)
        {
            Model.Title = "Detalji Transakcije";
            Model.Transakcija = transakcijaModel;
            Model.BrojRacuna = transakcijaModel.BrojRacuna;
        }
    }
}
