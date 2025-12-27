namespace back_point.Services
{
    using back_point.Interfaces;
    using back_point.Models;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using back_point.DTO;

    public class EnterpriseService : IEnterprise
    {
        private readonly IEnterpriseRepository _enterpriseRepository;
        private readonly IValidator _validator;
        private readonly IPasswordHash _passwordHash;

        public EnterpriseService(IEnterpriseRepository enterpriseRepository, IValidator validator, IPasswordHash passwordHash)
        {
            _enterpriseRepository = enterpriseRepository;
            _validator = validator;
            _passwordHash = passwordHash;
        }

        public async Task<Enterprise?> AuthenticateEnterprise(EnterpriseLoginDTO dto)
        {
            _validator.ValidateEmail(dto.Email);

            var enterprise = await _enterpriseRepository.GetEnterpriseByEmail(dto.Email);

            if (enterprise == null)
                throw new UnauthorizedAccessException("Credenciais inválidas");

            var isValidPassword = _passwordHash.VerifyPassword(
                enterprise.EnterprisePassword,
                dto.EnterprisePassword
            );

            if (!isValidPassword)
                throw new UnauthorizedAccessException("Credenciais inválidas");

            return enterprise;
        }


        public async Task<Enterprise> CreateEnterprise(CreateEnterpriseDTO dto)
        {
            _validator.ValidateCnpj(dto.Cnpj);
            _validator.ValidateEmail(dto.Email);
            await _validator.IsEnterpriseExistsByCnpj(dto.Cnpj);
            await _validator.IsEnterpriseExistsByEmail(dto.Email);
            var hashedPassword = _passwordHash.HashPassword(dto.EnterprisePassword);

            Enterprise newEnterprise = new Enterprise
            {
                Name = dto.Name,
                Address = dto.Address,
                PhoneNumber = dto.PhoneNumber,
                Email = dto.Email,
                EnterprisePassword = hashedPassword,
                Cnpj = dto.Cnpj
            };

            return await _enterpriseRepository.CreateEnterprise(newEnterprise);
        }

        public Task<User> CreateUser(Guid enterpriseId, CreateUserDTO dto)
        {
            _validator.ValidateEmail(dto.Email);
            string username = dto.Username;
            string email = dto.Email;
            string fullName = dto.FullName;
            string role = dto.Role;

            User newUser = new User
            {
                Username = username,
                Email = email,
                FullName = fullName,
                Role = role,
                EnterpriseId = enterpriseId
            };

            return _enterpriseRepository.CreateUser(enterpriseId, newUser);
        }

        public async Task<bool> DeleteEnterprise(Guid id)
        {
            var isDeleted = await _enterpriseRepository.DeleteEnterprise(id);
            if (!isDeleted)
            {
                throw new Exception("Error deleting enterprise.");
            }
            return true;
        }

        public Task<Enterprise?> GetEnterpriseById(Guid id)
        {
            var enterprise = _enterpriseRepository.GetEnterpriseById(id);
            if (enterprise == null)
            {
                throw new Exception("Enterprise not found.");
            }
            return enterprise;
        }

        public Task<List<User>> GetUsersByEnterpriseId(Guid enterpriseId)
        {
            var userList = _enterpriseRepository.GetUsersByEnterpriseId(enterpriseId);
            if (userList == null)
            {
                throw new Exception("No users found for this enterprise.");
            }
            return userList;
        }

        public async Task<Enterprise> UpdateEnterprise(CreateEnterpriseDTO enterpriseDTO, Guid enterpriseId)
        {
            Enterprise? entp = await _enterpriseRepository.GetEnterpriseById(enterpriseId);
            if (entp == null)
            {
                throw new Exception("Enterprise not found.");
            }

            entp.Name = enterpriseDTO.Name;
            entp.Address = enterpriseDTO.Address;
            entp.PhoneNumber = enterpriseDTO.PhoneNumber;
            entp.Email = enterpriseDTO.Email;
            entp.Cnpj = enterpriseDTO.Cnpj;
            var hashedPassword = _passwordHash.HashPassword(enterpriseDTO.EnterprisePassword);
            entp.EnterprisePassword = hashedPassword;
            return await _enterpriseRepository.UpdateEnterprise(entp);
        }
    }
}