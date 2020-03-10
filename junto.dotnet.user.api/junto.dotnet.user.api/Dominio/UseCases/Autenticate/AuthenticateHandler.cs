using junto.dotnet.user.api.Dominio.Repositories;
using junto.dotnet.user.api.InfraStructure.Options;
using MediatR;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace junto.dotnet.user.api.Dominio.UseCases.Autenticate
{
    public class AuthenticateHandler : IRequestHandler<AuthenticateCommand, Result<UserDTOAutenticate>>
    {
        private readonly IUserRepository _repositoryUser;
        private readonly SecretOptions _options;

        public AuthenticateHandler(IUserRepository repositoryUser, IOptions<SecretOptions> options)
        {
            _repositoryUser = repositoryUser;
            _options = options.Value;
        }
        public async Task<Result<UserDTOAutenticate>> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
        {
            request.Email ??= string.Empty;

            var user  = await _repositoryUser.GetByEmail(request.Email);

            if (user == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_options.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(securityToken);
            var userAuthenticate = new UserDTOAutenticate(token);

            return await Task.Run(() => new Result<UserDTOAutenticate>(userAuthenticate));
        }
    }
}
