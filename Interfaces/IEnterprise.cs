namespace back_point.Interfaces
{
    using back_point.DTO;
    using back_point.Models;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IEnterprise
    {
        Task<Enterprise> CreateEnterprise(CreateEnterpriseDTO dto);
        Task<Enterprise?> GetEnterpriseById(Guid id);
        Task<Enterprise> UpdateEnterprise(CreateEnterpriseDTO enterpriseDTO, Guid enterpriseId);
        Task<User> UpdateUser(CreateUserDTO userDTO, string code);
        Task<bool> DeleteEnterprise(Guid id);
        Task<Enterprise?> AuthenticateEnterprise(EnterpriseLoginDTO dto);
        Task<User> CreateUser(Guid enterpriseId, CreateUserDTO dto);
        Task<List<UserResponseDTO>> GetUsersByEnterpriseId(Guid enterpriseId);
    }
}