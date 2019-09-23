using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace Users
{
    public struct User
    {
        public User(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }
        public readonly string Username;
        public readonly string Password;
    }

    public class UserList
    {
        List<User> userList = new List<User>();

        public string this[string username]
        {
            get
            {
                for (int i = 0; i < userList.Count; i++)
                {
                    if (userList[i].Username == username)
                        return userList[i].Password;
                }
                return "Username / Password invalid.";
            }
            set
            {
                for (int i = 0; i < userList.Count; i++)
                {
                    if (userList[i].Username == username)
                    {
                        userList.RemoveAt(i);
                    }
                }
                userList.Add(new User(username, Encrypt(value)));
            }
        }

        public static string Encrypt(string password)
        {
            MD5 md5hash = MD5.Create();
            string encrypted = GetMd5Hash(md5hash, password);
            return encrypted;
        }

        //Got this from https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.md5?view=netframework-4.8
        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        //got this from https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.md5?view=netframework-4.8
        // Verify a hash against a string.
        public static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            // Hash the input.
            string hashOfInput = GetMd5Hash(md5Hash, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
