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
using userapi.Test.Common;

namespace userapi.Test
{
    public class DeleteUserTest : RepositoryMock
    {
        [Fact]
        public async void SouldReturnSuccess_WhenCommandDeleteUserIsInvalid()
        {
            // arrange
            var (repo, context) = GetRepository();
            _ = await repo.Save(new UserEntity { Email = "test1@test1.com", Name = "test1", Password = "testpass" });

            var comando = new DeleteUserCommand { Id = 1 };
            var handler = new DeleteUserHandler(repo);

            // act
            _ = await handler.Handle(comando, CancellationToken.None);

            // assert
            var result = await context.UserEntityDb.ToListAsync();            
            var count = result.Count();

            Assert.Equal(0, count);
        }
    }
}
