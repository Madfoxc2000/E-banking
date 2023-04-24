using EBanking.DataAccess.Modeli;

namespace EBanking.DataAccess.Repozitorijumi
{
    public interface IRepozitorijumTransakcija
    {
        int CreateTransakcija(Transakcija transakcija);
        List<Transakcija> GetTransakcijeByBrojRacuna(string brojRacuna);
    }
}
