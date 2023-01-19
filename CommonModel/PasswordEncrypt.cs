using System;
using System.Text;

namespace recruitmentmanagementsystem.CommonMethods
{
    public class PasswordEncrypt
    {
        
       public string Encode(string password)
        {
            try
            {
                if (password == null)
                    return "";
                
                byte[] enccodebyte= new byte[password.Length];
                enccodebyte = System.Text.Encoding.UTF8.GetBytes(password);
                string encrypteddata=Convert.ToBase64String(enccodebyte);

                return encrypteddata;
            }
            catch (Exception ex)
            {
               throw new Exception("error"  +ex.Message);
                return "cannot be empty";
            }
        }

        public string Decode(string password)
        {
            try
            {
                if (password == null)
                    return "";
                var base64encodebytes=Convert.FromBase64String(password);
                var result =Encoding.UTF8.GetString(base64encodebytes);
                result=result.Substring(0, result.Length - 1);
                return result;

            }
            catch (Exception ex)
            {
                throw new Exception("error" + ex.Message);
                return "cannot be empty";
            }
        }
    }
}
