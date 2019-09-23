using System;
using System.Collections.Generic;
using Users;

namespace PasswordEncryptionAuthentication
{
    class Program
    {
        static List<string> userList = new List<string>();
        static UserList u = new UserList();
        public static void UserInterface()
        {
            Console.Clear();
            Console.WriteLine("PASSWORD AUTHENTICATION SYSTEM\n");
            Console.WriteLine("Please select one option");
            Console.WriteLine("1. Establish an account");
            Console.WriteLine("2. Authenticate a user");
            Console.WriteLine("3. Exit the system\n");
            Console.Write("Enter Selection:  ");
            string userInput = Console.ReadLine();
            if (userInput == "1")
            {
                //Do establish an account method
                Console.Write("Enter a desired user name: ");
                string userName = Console.ReadLine();
                if (!userList.Contains(userName))
                {
                    userList.Add(userName);
                    Console.Write("Enter a desired password: ");
                    string userPassword = Console.ReadLine();
                    u[userName] = userPassword;
                }
                else
                {
                    Console.WriteLine("This username is unavailable");
                }
            }
            if (userInput == "2")
            {
                Console.Write("Enter your user name: ");
                string userName = Console.ReadLine();
                Console.Write("Enter the password: ");
                string userPassword = Console.ReadLine();

                if (UserList.Encrypt(userPassword) == u[userName])
                {
                    Console.WriteLine($"User name = {userName}");
                    Console.WriteLine($"Password = {userPassword}");
                    Console.WriteLine($"Encrypted Password = {u[userName]}");
                }
                else
                Console.WriteLine("Username / Password invalid.");
            }
            if (userInput == "3")
            {
                //Print all usernames, passwords, and encrypted passwords
                Console.WriteLine("Any saved usernames or passwords will be lost");
                Console.WriteLine("See you later alligator");
                return;
                // Wait some time then close application
            }
            if (userInput != "1" && userInput !="2" && userInput !="3")
            {
                Console.WriteLine("\nOnly 1, 2, and 3 are correct inputs. Please select on of those numbers.\n");
            }

            Console.ReadKey();
            UserInterface();
        }
        static void Main(string[] args)
        {
            UserInterface();
        }
    }
}
