using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Hasing
{
    public class HashingHelper
    {
        //verdiğimiz passwordun hashini oluşturmayı sağlıyor
        //out boşsa da doldurur içini bir password vereceğiz geriye kalan ikisini yazacak
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512()) //HMACSHA512 algoritmasından yararlanarak oluşturacağız
            {
                passwordSalt = hmac.Key; //her kullanıcı içi 1 key oluşturulur
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)); //passwordun byte değerini verir

            }
        }
        //sonradan sisteme girmek isteyen kişinin verdiği passwordun bizim veritabanındaki hash ile ilgili salta göre eşleşip eşleşmediği yerdir
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)//veritabanındakilerle karşılaştırma yapılır passwordHash ve salt için
        {//password kullanıcının girdiği parola
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));//salt kullanılarak hash hesaplanıyor
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }

        }

    }
}
