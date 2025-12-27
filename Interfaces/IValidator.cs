namespace back_point.Interfaces
{
    using System.Threading.Tasks;
    using back_point.Models;

    public interface IValidator
    {
        void ValidateCnpj(string cnpj);
        void ValidateEmail(string email);
        Task IsEnterpriseExistsByCnpj(string cnpj);
        Task IsEnterpriseExistsByEmail(string email);
        Task IsUserExistsByEmail(string email);
    }
}