using EBanking.DataAccess.Modeli;
using EBanking.Services.Modeli;

namespace EBanking.Services
{
    public interface ITransakcijaService
    {
        void CreateTransakcija(TransakcijaModel transakcijaModel);
        List<TransakcijaModel> GetTransakcijeByBrojRacuna(string brojRacuna);
    }
}
