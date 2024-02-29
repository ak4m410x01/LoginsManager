using System.Text;

namespace LoginsManager
{
    internal class App
    {
        public static void Run()
        {
            // Welcome message
            Console.WriteLine("Welcome to you in LoginsManager app...!!\n");

            Console.WriteLine("Reading Data...");
            ReadLogins();

            string? selectedOption;

            Console.WriteLine("Select what do you want ?\n");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            DisplayOptions();
            Console.ForegroundColor = ConsoleColor.White;


            while (true)
            {
                Console.Write("\nOption Number: ");
                selectedOption = Console.ReadLine() ?? "";

                switch (selectedOption)
                {
                    case "1":
                        ListAllLogins();
                        break;

                    case "2":
                        GetLogin();
                        break;

                    case "3":
                        AddLogin();
                        break;

                    case "4":
                        ChangeLogin();
                        break;

                    case "5":
                        DeleteLogin();
                        break;

                    case "6":
                        DisplayOptions();
                        break;

                    case "7":
                        WriteLogins();
                        break;

                    case "8":
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nGood bye... :)");
                        Console.ForegroundColor = ConsoleColor.White;
                        return;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nInvalid option. please try again...!!\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        DisplayOptions();
                        break;
                }

            }
        }
        private static Dictionary<string, string[]> _logins = new Dictionary<string, string[]>();
        private static void DisplayOptions()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("[1]. List all Logins.");
            Console.WriteLine("[2]. Get Login.");
            Console.WriteLine("[3]. Add Login.");
            Console.WriteLine("[4]. Change Login.");
            Console.WriteLine("[5]. Delete Login.");
            Console.WriteLine("[6]. Display Options.");
            Console.WriteLine("[7]. Write Logins.");
            Console.WriteLine("[8]. Quit.");
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void ListAllLogins()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\nLogins...\n");
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var item in _logins)
            {
                Console.WriteLine($"App Name:{item.Key},Login Url:{item.Value[0]},Email:{item.Value[1]},Password:{item.Value[2]},");
            }
            Console.WriteLine($"\nTotal Logins: {_logins.Count}\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
        private static void GetLogin()
        {
            Console.Write("Application Name:");
            string appName = (Console.ReadLine() ?? "").ToLower();

            if (_logins.ContainsKey(appName))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Login => App Name:{appName},Login Url:{_logins[appName][0]},Email:{_logins[appName][1]},Password:{_logins[appName][2]}");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Login Does not exists.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        private static void AddLogin()
        {
            Console.Write("Application Name:");
            string appName = (Console.ReadLine() ?? "").ToLower();

            Console.Write("Login Url:");
            string loginUrl = Console.ReadLine() ?? "";

            Console.Write("Email:");
            string email = Console.ReadLine() ?? "";

            Console.Write("Password:");
            string password = Console.ReadLine() ?? "";

            if (_logins.ContainsKey(appName))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Login already exists.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                _logins.Add(appName, new string[] { loginUrl, email, password });
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Login added successfully.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        private static void ChangeLogin()
        {
            Console.Write("Application Name:");
            string appName = (Console.ReadLine() ?? "").ToLower();

            Console.Write("Login Url:");
            string loginUrl = Console.ReadLine() ?? "";

            Console.Write("Email:");
            string email = Console.ReadLine() ?? "";

            Console.Write("Password:");
            string password = Console.ReadLine() ?? "";

            if (_logins.ContainsKey(appName))
            {
                _logins[appName] = new string[] { loginUrl, email, password };
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Login changed successfully.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Login does not exists.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        private static void DeleteLogin()
        {

            Console.Write("Email:");
            string appName = (Console.ReadLine() ?? "").ToLower();

            if (_logins.ContainsKey(appName))
            {
                _logins.Remove(appName);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Login removed successfully.");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Login does not exists.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        private static void ReadLogins()
        {
            if (File.Exists("passwords.txt"))
            {
                string[] lines = File.ReadAllLines("passwords.txt");
                for (int i = 0; i < lines.Length; i++)
                {
                    if (!string.IsNullOrEmpty(lines[i]))
                    {
                        string[] login = lines[i].Split(',');
                        _logins.Add(login[0], new string[] { login[1], login[2], login[3] });
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("File: 'passwords.txt' does not exists.");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Creating 'passwords.txt'...\n");
                File.CreateText("passwords.txt");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        private static void WriteLogins()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in _logins)
            {
                sb.AppendLine($"{item.Key},{item.Value[0]},{item.Value[1]},{item.Value[2]}");
            }
            File.WriteAllText("passwords.txt", sb.ToString());
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Logins Saved Successfully.");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
