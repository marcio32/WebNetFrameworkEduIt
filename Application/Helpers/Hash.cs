using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Application.Helpers
{
    public class Hash
    {
        public static string Hashing(string clave)
        {
            byte[] salt;
            byte[] buffer;
            
            if(clave == null)
            {
                throw new ArgumentNullException();
            }
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(clave, 16, 1000))
            {
                salt = bytes.Salt;
                buffer = bytes.GetBytes(32);
            }
            byte[] dst = new byte[49];
            Buffer.BlockCopy(salt, 0, dst, 1, 16);
            Buffer.BlockCopy(buffer, 0, dst, 17, 32);
            return Convert.ToBase64String(dst);
        }

        public static bool VerifyHashedPassword(string hashedPassword, string clave)
        {
            byte[] buffer4;

            if (hashedPassword == null)
            {
                return false;
            }
            if(clave == null)
            {
                throw new ArgumentNullException();
            }

            byte[] src = Convert.FromBase64String(hashedPassword);
            if ((src.Length != 49) || src[0] != 0)
            {
                return false;
            }

            byte[] dst = new byte[16];
            Buffer.BlockCopy(src, 1, dst, 0, 16);

            byte[] buffer3 = new byte[32];
            Buffer.BlockCopy(src, 17, buffer3, 0, 32);


            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(clave, dst, 1000))
            {
                buffer4 = bytes.GetBytes(32);
            }

            return buffer3.SequenceEqual(buffer4);
           
        }
    }
}
