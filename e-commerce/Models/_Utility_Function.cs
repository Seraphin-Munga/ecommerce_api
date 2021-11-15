using System;
using System.Security.Cryptography;
using System.Text;

namespace e_commerce.Models
{
    public class _Utility_Function
    {

        public static string EncryptPassword(string password)
        {
            string encryptedPassword = "";
            encryptedPassword = HashPassWord(password);
            return encryptedPassword;
        }

        public static string DecryptPassword(string password)
        {
            string dencryptedPassword = "";

            return dencryptedPassword;
        }

        private static String HashPassWord(string password)
        {
            SHA256 HashAlgorithm = SHA256.Create(); // Hash algorith declaration.
            Byte[] c = null;
            c = HashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(password));
            string hashPassword = null;

            for (int i = 0; i < c.Length; i++)
            {
                hashPassword += c[i].ToString("x2");
            }
            return hashPassword;
        }

        public static String GeneratePassword()
        {

            string PasswordLength = "12";
            string NewPassword = "";

            string allowedChars = "";
            allowedChars = "1,2,3,4,5,6,7,8,9,0";
            allowedChars += "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,";
            allowedChars += "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,";

            char[] sep = { ',' };
            string[] arr = allowedChars.Split(sep);

            string IDString = "";
            string temp = "";

            Random rand = new Random();

            //and lastly - loop through the generation process...
            for (int i = 0; i < Convert.ToInt32(PasswordLength); i++)
            {
                temp = arr[rand.Next(0, arr.Length)];
                IDString += temp;
                NewPassword = IDString;

                //For Testing purposes, I used a label on the front end to show me the generated password.
                //lblProduct.Text = IDString; from webform just for testing purposes 

            }

            return NewPassword;
        }

        public static string Token()
        {
            string token = "";
            token = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
            string tk = token.Replace(@"\", "").Replace("/", "");
            return tk;
        }
    }
}
