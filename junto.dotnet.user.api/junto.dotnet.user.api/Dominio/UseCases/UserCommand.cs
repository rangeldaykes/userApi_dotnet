using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace junto.dotnet.user.api.Dominio.UseCases
{
    public abstract class UserCommand : Command
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string PassWord { get; set; }
    }
}
