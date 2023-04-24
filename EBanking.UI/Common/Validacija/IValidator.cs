namespace EBanking.UI.Common.Validacija
{
    public interface IValidator<TModel>
    {

        bool ValidateModel(TModel model);
    }
}
