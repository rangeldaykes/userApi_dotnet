using junto.dotnet.user.api.InfraStructure.Options;
using junto.dotnet.user.api.InfraStructure.Persistence.DataContexts;
using junto.dotnet.user.api.InfraStructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace userapi.Test.Common
{
    public class RepositoryMock
    {
        public (UserRepository, UserDataContext) GetRepository()
        {
            var options = new DbContextOptionsBuilder<UserDataContext>()
                .UseInMemoryDatabase("UserDataContext")
                .Options;

            var config = new Mock<IOptions<PersistenceOptions>>();
            var contexto = new UserDataContext(options, config.Object);
            var repo = new UserRepository(contexto);

            return (repo, contexto);
        }
    }
}
