using System.Security.Cryptography;
using System.Text;
using ITExpertTest.Models.Entities;

namespace ITExpertTest.Extensions;

public static class TodoExtensions
{
    public static string GetMd5HashFromTitle(this Todo? input)
    {
        using (var md5 = MD5.Create())
        {
            if (input?.Title == null) 
                return string.Empty;
            
            var inputBytes = Encoding.ASCII.GetBytes(input.Title);
            var hashBytes = md5.ComputeHash(inputBytes);

            var sb = new StringBuilder();
            foreach (var t in hashBytes) 
                sb.Append(t.ToString("X2"));

            return sb.ToString();
        }
    }
}