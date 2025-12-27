namespace back_point.Interfaces
{
    using back_point.DTO;
    using back_point.Models;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IEnterpriseRepository
    {
        Task<Enterprise> CreateEnterprise(Enterprise enterprise);
        Task<Enterprise?> GetEnterpriseById(Guid id);
        Task<Enterprise> UpdateEnterprise(Enterprise enterprise);
        Task<bool> DeleteEnterprise(Guid id);
        Task<Enterprise?> AuthenticateEnterprise(string email, string password);
        Task<User> CreateUser(Guid enterpriseId, User user);
        Task<List<User>> GetUsersByEnterpriseId(Guid enterpriseId);
        Task<Enterprise?> GetEnterpriseByCnpj(string cnpj);
        Task<Enterprise?> GetEnterpriseByEmail(string email);
        Task<User?> GetUserByEmail(string email);
    }
}