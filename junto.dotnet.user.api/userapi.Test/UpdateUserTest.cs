using Xunit;
using Moq;
using Microsoft.EntityFrameworkCore;
using junto.dotnet.user.api.InfraStructure.Persistence.DataContexts;
using junto.dotnet.user.api.InfraStructure.Options;
using Microsoft.Extensions.Options;
using junto.dotnet.user.api.InfraStructure.Persistence.Repositories;
using junto.dotnet.user.api.Dominio.UseCases.AddUser;
using System.Threading;
using junto.dotnet.user.api.Dominio.Entities;
using junto.dotnet.user.api.Dominio.UseCases.DeleteUser;
using System.Linq;
using junto.dotnet.user.api.Dominio.UseCases.UpdateUser;
using userapi.Test.Common;

namespace userapi.Test
{
    public class UpdateUserTest : RepositoryMock
    {
        [Fact]
        public async void SouldReturnSuccess_WhenCommandUpdateUserIsInvalid()
        {
            // arrange
            var (repo, context) = GetRepository();

            var entity = new UserEntity { Email = "test1@test1.com", Name = "test1", Password = "testpass" };
            _ = await repo.Save(entity);
            context.Entry(entity).State = EntityState.Detached;

            var comando = new UpdateUserCommand { Id = 1, Email = "test2@test2.com", Nome = "test2" };
            var handler = new UpdateUserHandler(repo);

            // act
            _ = await handler.Handle(comando, CancellationToken.None);

            // assert
            //var result = await repo.GetById(comando.Id);
            var result = context.UserEntityDb.Find(comando.Id);

            Assert.Equal(comando.Email, result.Email);
        }
    }
}
