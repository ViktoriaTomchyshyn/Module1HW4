/*
Створити масив на N елементів, де N вказується з консольного рядка.
Заповнити його випадковими числами від 1 до 26 включно.
Створити 2 масива, де в 1 масиві будуть значення лише парних значень,
а в другому непарних.
Замінити числа в 1 і 2 масиві  на букви англійського алфавіту.
Значення клітинок цих масивів дорівнюють порядковому номеру кожної букви в алфавіті.
Якщо ж буква є одній із списку  (a, e, i, d, h, j) то вона має бути у верхньому
регістрі. Вивести на екран результат того, в якому з масивів буде більше букв
у верхньому регістрі.  Вивести обидва масиви на екран. Кожен з масивів має бути
виведений 1 рядком, де його значення будуть розділені пропуском.
*/
using System;

namespace Hw_4
{
    public class Program
    {
        private static char[] _letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToLower().ToCharArray();
        public static void Main()
        {
            bool check;
            int n = 0;
            do
            {
                try
                {
                    System.Console.WriteLine("Enter N:");
                    string input = System.Console.ReadLine();
                    bool isNumber = int.TryParse(input, out n);
                    if (!isNumber)
                    {
                        System.Console.WriteLine("Write number (integer)\n");
                        check = false;
                    }
                    else if (n < 1 || n > 30)
                    {
                        System.Console.WriteLine("\nWrite number > 1 AND < 30\n");
                        check = false;
                    }
                    else
                    {
                        check = true;
                    }
                }
                catch (Exception e)
                {
                    System.Console.WriteLine(e.Data);
                    check = false;
                }
            }
            while (!check);

            Task(n);
        }

        public static void Task(int n)
        {
            if (n == 0)
            {
                return;
            }

            int[] array = new int[n];
            int oddCounter = 0;
            int evenCounter = 0;
            Console.WriteLine("\nYour array:");

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = new Random().Next(1, 26);
                Console.Write(array[i] + " ");
                if (array[i] % 2 == 0)
                {
                    evenCounter++;
                }
                else
                {
                    oddCounter++;
                }
            }

            int[] evenArray = new int[evenCounter];
            int tempIterator = 0;
            Console.WriteLine("\n\nEven array:");

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    evenArray[tempIterator] = array[i];
                    Console.Write(evenArray[tempIterator] + " ");
                    tempIterator++;
                }
            }

            char[] checkList = "aeidhj".ToCharArray();

            char[] evenLetters = new char[evenCounter];
            int evenUpperCounter = 0;
            Console.WriteLine("\nLetters:");

            for (int i = 0; i < evenArray.Length; i++)
            {
                evenLetters[i] = _letters[evenArray[i] - 1];
                for (int j = 0; j < checkList.Length; j++)
                {
                    if (checkList[j] == evenLetters[i])
                    {
                        evenLetters[i] = char.ToUpper(evenLetters[i]);
                        evenUpperCounter++;
                    }
                }

                Console.Write(evenLetters[i] + " ");
            }

            int[] oddArray = new int[oddCounter];
            tempIterator = 0;
            Console.WriteLine("\n\nOdd array:");

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 != 0)
                {
                    oddArray[tempIterator] = array[i];
                    Console.Write(oddArray[tempIterator] + " ");
                    tempIterator++;
                }
            }

            char[] oddLetters = new char[oddCounter];
            int oddUpperCounter = 0;
            Console.WriteLine("\nLetters:");

            for (int i = 0; i < oddArray.Length; i++)
            {
                oddLetters[i] = _letters[oddArray[i] - 1];
                for (int j = 0; j < checkList.Length; j++)
                {
                    if (checkList[j] == oddLetters[i])
                    {
                        oddLetters[i] = char.ToUpper(oddLetters[i]);
                        oddUpperCounter++;
                    }
                }

                Console.Write(oddLetters[i] + " ");
            }

            if (oddUpperCounter > evenUpperCounter)
            {
                Console.WriteLine("\n\nThere are more upper letters in ODD array.");
            }
            else if (oddUpperCounter < evenUpperCounter)
            {
                Console.WriteLine("\n\nThere are more upper letters in EVEN array.");
            }
            else if (oddUpperCounter == evenUpperCounter)
            {
                Console.WriteLine("\n\nQuantities of upper letters in both arrays are the same.");
            }
        }
    }
}