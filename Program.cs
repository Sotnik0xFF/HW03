using System;
using System.Text;

namespace HW03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            var userInfo = GetUser();
            DisplayUserInfo(userInfo);
        }

        static (string FirstName, string LastName, int Age, string[] Pets, string[] FavoriteColors) GetUser()
        {
            (string FirstName, string LastName, int Age, string[] Pets, string[] FavoriteColors) user;
            user.FirstName = GetString("Ведите ваше имя");
            user.LastName = GetString("Ведите вашу фамилию");
            user.Age = GetInt("Введите ваш возраст");

            user.Pets = null;
            if (GetBool("У вас есть животные?"))
            {
                int petsCount = GetInt("Введите кол-во животных");
                user.Pets = GetStringArray(petsCount, "Кличка питомца");
            }

            int colorsCount = GetInt("Введите ко-во любимых цветов");
            user.FavoriteColors = GetStringArray(colorsCount, "Любимый цвет");

            return user;
        }

        static string GetString(string message)
        {
            while (true)
            {
                Console.Write(message + ": ");
                string value = Console.ReadLine();

                if (IsValidText(value))
                {
                    return value;
                }
            }
        }

        static int GetInt(string message) 
        {
            while (true)
            {
                string value = GetString(message);
                if (IsValidNumber(value, out int result))
                {
                    return result;
                }
            }
        }

        static bool GetBool(string message)
        {
            const string AnswerYes = "yes";
            const string AnswerNo = "no";

            string value = GetString(message + $" [{AnswerYes}/{AnswerNo}]");
            while (true)
            {
                switch (value)
                {
                    case AnswerYes:
                        return true;
                    case AnswerNo:
                        return false;
                    default:
                        value = GetString($"Введите \"{AnswerYes}\" или \"{AnswerNo}\"");
                        break;
                }
            }
        }

        static string[] GetStringArray(int itemsCount, string itemName)
        {
            string[] stringList = new string[itemsCount];
            for (int i = 0; i < stringList.Length; i++)
            {
                stringList[i] = GetString(itemName + $" {i + 1}");
            }
            return stringList;
        }

        static bool IsValidNumber(string number, out int corrnumber) => Int32.TryParse(number, out corrnumber) && corrnumber > 0;

        static bool IsValidText(string text) => !String.IsNullOrWhiteSpace(text);

        static void DisplayUserInfo((string FirstName, string LastName, int Age, string[] Pets, string[] FavoriteColors) user)
        {
            Console.WriteLine(Environment.NewLine + "**************** АНКЕТА ****************");
            Console.WriteLine($"Пользователь: {user.FirstName} {user.LastName}");
            Console.WriteLine($"Возраст: {user.Age}");

            Console.Write("Кол-во животных: ");
            if (user.Pets != null)
            {
                Console.WriteLine(user.Pets.Length);
                foreach (var pet in user.Pets)
                {
                    Console.WriteLine($"\t{pet}");
                }
            }
            else
            {
                Console.WriteLine("отсутсвуют");
            }

            Console.WriteLine("Любимые цвета:");
            foreach (var color in user.FavoriteColors)
            {
                Console.WriteLine($"\t{color}");
            }
            Console.WriteLine("****************************************");
        }
    }
}
