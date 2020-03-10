using junto.dotnet.user.api.Dominio.Entities;
using junto.dotnet.user.api.Dominio.Repositories;
using junto.dotnet.user.api.InfraStructure.Persistence.DataContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace junto.dotnet.user.api.InfraStructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDataContext _context;
        public UserRepository(UserDataContext context)
        {
            _context = context;
        }

        public async Task<int> Delete(int id)
        {
            //_context.UserEntityDb.Remove(user);
            var user = await _context.UserEntityDb.FindAsync(id);
            if(user != null)
                _context.UserEntityDb.Remove(user);

            var ret = await _context.SaveChangesAsync();

            return ret;
        }

        public async Task<IEnumerable<UserEntity>> GetAll()
        {
            var ret = await _context.UserEntityDb.ToListAsync();
            return ret;
        }

        public async Task<UserEntity> GetById(int id)
        {
            var ret = await _context.UserEntityDb.FindAsync(id);
            return ret;
        }

        public async Task<UserEntity> GetByEmail(string email)
        {
            var ret = await _context.UserEntityDb.Where(u => u.Email == email).FirstOrDefaultAsync();
            return ret;
        }

        public async Task<UserEntity> Save(UserEntity customer)
        {
            var ret = await _context.AddAsync(customer);
            await _context.SaveChangesAsync();
            return ret.Entity;
        }

        public async Task<int> UpdateFields(UserEntity customer)
        {
            //_context.UserEntityDb.Update(customer);
            //var ret = await _context.SaveChangesAsync();

            //_context.UserEntityDb.Attach(customer);
            //_context.Entry(customer).State = EntityState.Modified;
            //var ret = await _context.SaveChangesAsync();

            _context.Entry(customer).State = EntityState.Detached;
            _context.UserEntityDb.Attach(customer);

            _context.Entry(customer).Property(e => e.Name).IsModified = true;
            _context.Entry(customer).Property(e => e.Email).IsModified = true;

            var ret = await _context.SaveChangesAsync();

            return ret;
        }

        public async Task<int> ChangePassword(int id, string newPassword)
        {
            var user = new UserEntity { Id = id, Password = newPassword };
            _context.Entry(user).State = EntityState.Detached;
            _context.UserEntityDb.Attach(user);

            _context.Entry(user).Property(e => e.Password).IsModified = true;

            var ret = await _context.SaveChangesAsync();

            return ret;
        }
    }
}
