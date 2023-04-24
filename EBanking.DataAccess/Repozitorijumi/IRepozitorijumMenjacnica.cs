using EBanking.DataAccess.Modeli;

namespace EBanking.DataAccess.Repozitorijumi
{
    public interface IRepozitorijumMenjacnica
    {
        List<Menjacnica> GetMenjacnicaByValuta(string valuta);
    }
}
