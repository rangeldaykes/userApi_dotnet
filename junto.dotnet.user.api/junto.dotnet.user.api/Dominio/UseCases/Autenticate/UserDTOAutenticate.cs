using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace junto.dotnet.user.api.Dominio.UseCases.Autenticate
{
    public class UserDTOAutenticate
    {
        public UserDTOAutenticate(string token)
        {
            Token = token;
        }

        public string Token { get; set; }
    }
}
