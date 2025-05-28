using Org.BouncyCastle.Crypto.Generators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones2025.Windows.Helpers
{
    public static class SeguridadHelper
    {
        public static string GenerarHash(string clave)
        {
            return BCrypt.Net.BCrypt.HashPassword(clave);
        }

        public static bool VerificarHash(string claveIngresada, string hashAlmacenado)
        {
            return BCrypt.Net.BCrypt.Verify(claveIngresada, hashAlmacenado);
        }
    }
}
