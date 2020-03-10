using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace junto.dotnet.user.api.Dominio
{
    public class FriendlyMessages
    {
        public const string EMAIL_EMPTY = "O campo email deve ser preenchido'";
        public const string EMAIL_VALID = "O campo email deve ser válido";

        public const string NAME_EMPTY = "O campo Nome deve ser preenchido'";

        public const string ALTERPASSWORD_NOT_EQUAL = "A nova senha deve ser diferente da senha anterior";
        public const string ALTERPASSWORD_PASS_GREATER = "A senha deve contem pelo menos {0} caracteres";
    }
}
