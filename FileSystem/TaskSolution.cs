using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem
{
    internal class TaskSolutionMenu
    {
        TaskSolution tS = new TaskSolution();

        public void Menu()
        {
            List<string> list = new List<string>();
            list.Add("Рішення завдання №1");
            list.Add("Рішення Завдання №2");
            list.Add("Рішення Завдання №3 (Додаток Модератор)");
            list.Add("Рішення Завдання №4");
            list.Add("Вихід");

            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                int a = ConsoleMenu.SelectVertical(HPosition.Center,
                                    VPosition.Top,
                                    HorizontalAlignment.Center,
                                    list);

                switch (a)
                {
                    case 0:
                        tS.Task1();
                        break;
                    case 1:
                        tS.Task2();
                        break;
                    case 2:
                        tS.Task3();
                        break;
                    case 3:
                        tS.Task4();
                        break;
                    case 4:
                        exit = true;
                        break;
                }
            }
            Console.Clear();
        }

    }

    internal class TaskSolution
    {
        public void Task1()
        {
            Console.Clear();
            int[] arr = new int[100];
            arr.GenerateArray(0, 100);
            arr.PrintArray();

            Console.WriteLine("\nПрості числа");
            int[] simplyInt = arr.SimplyNum();
            simplyInt.PrintArray();
            simplyInt.SaveArrayInTxt("../../../../ResultTask1", "/SimplyInt.txt");

            Console.WriteLine("\nЧисла Фібоначі");
            int[] fibInt = arr.FibonacciInt();
            fibInt.PrintArray();
            fibInt.SaveArrayInTxt("../../../../ResultTask1", "/FibInt.txt");

            DirectoryInfo d = new DirectoryInfo(Directory.GetCurrentDirectory());
            string path = d.Parent.ToString();
            path = path.Remove(path.Length - 10) + @"\ResultTask1";

            Console.WriteLine("Файли з результатами збережено у теці ResultTask1 яка знаходиться:");
            Console.WriteLine(path);
            Console.ReadKey();
        }

        public void Task2()
        {
            Console.Clear();

            string text = "";
            text = text.ReadFileTxt("../../../../ResultTask2/input.txt");

            Console.WriteLine("Текст:");
            Console.WriteLine(text);

            Console.WriteLine("\nВведіть слово яке потрібно замінити");
            string searchWord = Console.ReadLine();

            Console.WriteLine("Введіть слово на яке потрібно замінити");
            string replasmentWorld = Console.ReadLine();

            text = text.ReplaceWord(searchWord, replasmentWorld);

            Console.WriteLine("Текст після змін:");
            Console.WriteLine(text);

            text.SaveStringInTxt("../../../../ResultTask2/", "output.txt");

            DirectoryInfo d = new DirectoryInfo(Directory.GetCurrentDirectory());
            string path = d.Parent.ToString();

            path = path.Remove(path.Length - 10) + @"\ResultTask2\output.txt";

            Console.WriteLine("\nФайл з результатами збережено за адресою:");
            Console.WriteLine(path);

            Console.ReadKey();
        }

        public void Task3()
        {
            Console.Clear();
            Console.WriteLine("\tВведіть шлях до файлу з текстом");
            Console.WriteLine("(якщо ввести порожній рядок чи не існуючий шлях то вставиться шлях за замовчуванням)");
            string pathTextFile = Console.ReadLine();

            Console.WriteLine("\tВведіть шлях до файлу зі словами які треба відмодерувати");
            Console.WriteLine("(якщо ввести порожній рядок чи не існуючий шлях то вставиться шлях за замовчуванням)");
            string pathModerWordFile = Console.ReadLine();

            if (pathTextFile == "" || !(File.Exists(pathTextFile)))
            {
                pathTextFile = "../../../../InputFile/textfiletask3.txt";
            }

            if (pathModerWordFile == "" || !(File.Exists(pathModerWordFile)))
            {
                pathModerWordFile = "../../../../InputFile/moderationword.txt";
            }

            string text = "";
            text = text.ReadFileTxt(pathTextFile);

            string moderWords = "";
            moderWords = moderWords.ReadFileTxt(pathModerWordFile);

            Console.WriteLine("\tТекст:");
            Console.WriteLine(text);
            Console.WriteLine("\tСлова які буде замінено на *");
            Console.WriteLine(moderWords);


            text = text.ReplaceWords(moderWords, "*");

            Console.WriteLine("Текст після змін:");
            Console.WriteLine(text);


            text.SaveStringInTxt("../../../../ResultTask3/", "output.txt");

            DirectoryInfo d = new DirectoryInfo(Directory.GetCurrentDirectory());
            string path = d.Parent.ToString();

            path = path.Remove(path.Length - 10) + @"\ResultTask3\output.txt";

            Console.WriteLine("\nФайл з результатами збережено за адресою:");
            Console.WriteLine(path);
            Console.WriteLine("За для можливості перевірки роботи додатку умову збереження змінено! Додаток збереже в новий файл");

            Console.ReadKey();
        }

        public void Task4()
        {
            Console.Clear();
            Console.WriteLine("\tВведіть шлях до файлу з текстом");
            Console.WriteLine("(якщо ввести порожній рядок чи не існуючий шлях то вставиться шлях за замовчуванням)");
            string pathTextFile = Console.ReadLine();

            if (pathTextFile == "" || !(File.Exists(pathTextFile)))
            {
                pathTextFile = "../../../../InputFile/textfiletask4.txt";
            }

            string text = "";
            text = text.ReadFileTxt(pathTextFile);

            Console.WriteLine("\tТекст:");
            Console.WriteLine(text);
            text = text.ReverseText();

            Console.WriteLine("\tТекст після обертання:");
            Console.WriteLine(text);

            text.SaveStringInTxt("../../../../ResultTask4/", "output.txt");

            DirectoryInfo d = new DirectoryInfo(Directory.GetCurrentDirectory());
            string path = d.Parent.ToString();

            path = path.Remove(path.Length - 10) + @"\ResultTask4\output.txt";

            Console.WriteLine("\nФайл з результатами збережено за адресою:");
            Console.WriteLine(path);
            Console.WriteLine("За для можливості перевірки роботи додатку умову збереження змінено! Додаток збереже в новий файл");

            Console.ReadKey();
        }
    }
}
