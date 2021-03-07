using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
    public class SigningCredentialsHelper
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey securtyKey) //bir sistemi kullanmak için giriş b,lgileridir credential için 
        {//hangi anahtar ve hangi algoritma kullanılacak diye belirlyoruz
            return new SigningCredentials(securtyKey, SecurityAlgorithms.HmacSha512Signature);
        }
    }
}
