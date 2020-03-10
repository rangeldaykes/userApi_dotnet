using junto.dotnet.user.api.Dominio.Entities;
using junto.dotnet.user.api.Dominio.UseCases.GetUserById;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using userapi.Test.Common;
using Xunit;

namespace userapi.Test
{
    public class GetUserById : RepositoryMock
    {
        [Fact]
        public async void SouldReturnSuccess_WhenListUser()
        {
            // arrange
            var (repo, context) = GetRepository();

            var entity = new UserEntity { Email = "test1@test1.com", Name = "test1", Password = "testpass" };
            _ = await repo.Save(entity);

            var comando = new GetUserByIdCommand { Id = 1 };
            var handler = new GetUserByIdHandler(repo);

            // act            
            var ret = await handler.Handle(comando, CancellationToken.None);

            // assert
            var result = context.UserEntityDb.Find(comando.Id);
            Assert.True(ret.Data.Email == result.Email);
        }
    }
}
