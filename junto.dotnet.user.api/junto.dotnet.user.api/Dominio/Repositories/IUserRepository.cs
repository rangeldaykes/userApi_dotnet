using junto.dotnet.user.api.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace junto.dotnet.user.api.Dominio.Repositories
{
    public interface IUserRepository
    {
        Task<UserEntity> Save(UserEntity customer);
        Task<int> UpdateFields(UserEntity customer);
        Task<int> Delete(int id);
        Task<UserEntity> GetById(int id);
        Task<UserEntity> GetByEmail(string email);
        Task<IEnumerable<UserEntity>> GetAll();
        Task<int> ChangePassword(int id, string newPassword);
    }
}
