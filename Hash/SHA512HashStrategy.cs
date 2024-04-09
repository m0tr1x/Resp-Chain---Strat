using System.Security.Cryptography;
using System.Text;
using Interface;

namespace Hash;

public class SHA512HashStrategy : IHashStrategy
{
    public string GetHash(string input)
    {
        using (SHA512 shaM = new SHA512Managed())
        {
            byte[] bytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = shaM.ComputeHash(bytes);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                builder.Append(hashBytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }
}