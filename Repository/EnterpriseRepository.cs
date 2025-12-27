namespace back_point.Repository
{
    using back_point.DTO;
    using back_point.Interfaces;
    using back_point.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class EnterpriseRepository : IEnterpriseRepository
    {

        private readonly PointContext _context;
        public EnterpriseRepository(PointContext context)
        {
            _context = context;
        }
        public async Task<Enterprise?> AuthenticateEnterprise(string email, string password)
        {
            return await _context.Enterprises
                .FirstOrDefaultAsync(e => e.Email == email && e.EnterprisePassword == password);
        }

        public async Task<Enterprise> CreateEnterprise(Enterprise enterprise)
        {
            _context.Enterprises.Add(enterprise);
            await _context.SaveChangesAsync();
            return enterprise;
        }

        public async Task<User> CreateUser(Guid enterpriseId, User user)
        {
            user.EnterpriseId = enterpriseId;
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public Task<Enterprise?> GetEnterpriseById(Guid id)
        {
            return _context.Enterprises
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public Task<List<User>> GetUsersByEnterpriseId(Guid enterpriseId)
        {
            return _context.Users
                .Where(u => u.EnterpriseId == enterpriseId)
                .ToListAsync();
        }

        public async Task<Enterprise> UpdateEnterprise(Enterprise enterprise)
        {
            _context.Enterprises.Update(enterprise);
            await _context.SaveChangesAsync();
            return enterprise;
        }

        public async Task<bool> DeleteEnterprise(Guid id)
        {
            var enterprise = await _context.Enterprises.FindAsync(id);
            if (enterprise == null)
            {
                return false;
            }

            _context.Enterprises.Remove(enterprise);
            await _context.SaveChangesAsync();
            return true;
        }

        public Task<Enterprise?> GetEnterpriseByCnpj(string cnpj)
        {
            return _context.Enterprises
                .FirstOrDefaultAsync(e => e.Cnpj == cnpj);
        }

        public Task<Enterprise?> GetEnterpriseByEmail(string email)
        {
            return _context.Enterprises
                .FirstOrDefaultAsync(e => e.Email == email);
        }

        public Task<User?> GetUserByEmail(string email)
        {
            return _context.Users
                .FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}