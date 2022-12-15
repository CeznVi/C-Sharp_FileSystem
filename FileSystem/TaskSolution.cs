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
            list.Add("Рішення Завдання №5");
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
                        tS.Task5();
                        break;
                    case 5:
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
            text = text.ReadFileTxt("../../../../InputFile/inputTask2.txt");

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

        public void Task5()
        {
            Console.Clear();
            int[] arr = new int[100000];
            arr.GenerateArray(-99999, 99999);
            arr.SaveArrayInTxt("../../../../InputFile", "/task5.txt");

            //Делегати
            Func<int, bool> equalsMore0 = x => x > 0;
            Func<int, bool> equalsLess0 = x => x < 0;
            Func<int, bool> equalsTwoDigit = x => (-x > 9 && -x < 100) || (x > 9 && x < 100);
            Func<int, bool> equalsfiveDigit = x => (-x > 9999 && -x < 100000) || (x > 9999 && x < 100000);

            //////Додатні числа
            int[] positiveIntArr = null;
            positiveIntArr = (positiveIntArr.ReadFileInt("../../../../InputFile/task5.txt")).GetArrFromDelegate(equalsMore0);
            positiveIntArr.SaveArrayInTxt("../../../../ResultTask5", "/PositiveInt.txt");
            //////Від'ємні числа
            int[] negativeIntArr = null;
            negativeIntArr = (negativeIntArr.ReadFileInt("../../../../InputFile/task5.txt")).GetArrFromDelegate(equalsLess0);
            negativeIntArr.SaveArrayInTxt("../../../../ResultTask5", "/NegativeInt.txt");
            //////Двозначні числа
            int[] twoDigitIntArr = null;
            twoDigitIntArr = (twoDigitIntArr.ReadFileInt("../../../../InputFile/task5.txt")).GetArrFromDelegate(equalsTwoDigit);
            twoDigitIntArr.SaveArrayInTxt("../../../../ResultTask5", "/twoDigitInt.txt");
            //////П'ятизначні числа
            int[] fiveDigitIntArr = null;
            fiveDigitIntArr = (fiveDigitIntArr.ReadFileInt("../../../../InputFile/task5.txt")).GetArrFromDelegate(equalsfiveDigit);
            fiveDigitIntArr.SaveArrayInTxt("../../../../ResultTask5", "/fiveDigitInt.txt");

            //Друк статистики
            Console.WriteLine("Cтатистика:".PadCenter(110));
            Console.WriteLine($"\nОтриминий початковий масив має розмір = {arr.Length}");
            Console.WriteLine($"Кількість додатніх чисел у масиві = {positiveIntArr.Length}");
            Console.WriteLine($"Кількість від'ємних чисел у масиві = {negativeIntArr.Length}");
            Console.WriteLine($"Кількість двозначиних чисел у масиві = {twoDigitIntArr.Length}");
            Console.WriteLine($"Кількість п'ятизначних чисел у масиві = {fiveDigitIntArr.Length}");

            DirectoryInfo d = new DirectoryInfo(Directory.GetCurrentDirectory());
            string path = d.Parent.ToString();
            path = path.Remove(path.Length - 10) + @"\ResultTask5";

            Console.WriteLine("\nФайли з результатами збережено у теці ResultTask5 яка знаходиться:");
            Console.WriteLine(path);
            Console.ReadKey();

            Console.ReadKey();
        }
    }
}
