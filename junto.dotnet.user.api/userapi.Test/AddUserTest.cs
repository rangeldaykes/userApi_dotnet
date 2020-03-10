using Xunit;
using Moq;
using Microsoft.EntityFrameworkCore;
using junto.dotnet.user.api.InfraStructure.Persistence.DataContexts;
using junto.dotnet.user.api.InfraStructure.Options;
using Microsoft.Extensions.Options;
using junto.dotnet.user.api.InfraStructure.Persistence.Repositories;
using junto.dotnet.user.api.Dominio.UseCases.AddUser;
using System.Threading;
using userapi.Test.Common;

namespace userapi.Test
{
    public class AddUserTest : RepositoryMock
    {
        [Fact]
        public async void SouldReturnSuccess_WhenCommandAddUserIsInvalid()
        {
            // arrange
            var (repo, _) = GetRepository();

            var comando = new AddUserCommand { Email = "test1@test1.com", Nome = "test1", PassWord = "test1pass" };
            var handler = new AddUserHandler(repo);

            // act
            var ret = await handler.Handle(comando, CancellationToken.None);

            // assert
            Assert.True(ret.Data.Id > 0);
        }
    }
}
