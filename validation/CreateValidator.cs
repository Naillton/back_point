namespace back_point.Validation
{
    using back_point.Interfaces;
    using System;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    public class CreateValidator : IValidator
    {
        private readonly IEnterpriseRepository _enterpriseRepository;
        public CreateValidator(IEnterpriseRepository enterpriseRepository)
        {
            _enterpriseRepository = enterpriseRepository;
        }
        public void ValidateCnpj(string cnpj)
        {
            var regex = new Regex(@"^\d{14}$");
            
            if (!regex.IsMatch(cnpj))
            {
                throw new Exception("CNPJ inválido.");
            }
        }

        public void ValidateEmail(string email)
        {
            var regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            
            if (!regex.IsMatch(email))
            {
                throw new Exception("E-mail inválido.");
            }
        }

        public async Task IsEnterpriseExistsByCnpj(string cnpj)
        {
            if (await _enterpriseRepository.GetEnterpriseByCnpj(cnpj) != null)
            {
                throw new Exception("Empresa com este CNPJ já existe.");
            }
        }

        public async Task IsEnterpriseExistsByEmail(string email)
        {
            if (await _enterpriseRepository.GetEnterpriseByEmail(email) != null)
            {
                throw new Exception("Empresa com este e-mail já existe.");
            }
        }

        public async Task IsUserExistsByEmail(string email)
        {
            if (await _enterpriseRepository.GetUserByEmail(email) != null)
            {
                throw new Exception("Usuário com este e-mail já existe.");
            }
        }
    }
}