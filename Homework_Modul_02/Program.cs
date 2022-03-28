using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Modul_02
{

    public class Matrix
    {
        double[,] matrix;
        int Row = 0, Col = 0;

        
        public Matrix(int row, int col)
        {
            matrix = new double[row, col];
            Row = row; Col = col;
        }

        
        public Matrix(int N)
        {
            matrix = new double[N, N];
            Row = Col = N;
        }

        
        public double this[int i, int j]
        {
            get { return matrix[i, j]; }
            set { matrix[i, j] = value; }
        }

       
        public static Matrix operator *(Matrix m, int t)
        {
            Matrix mat = new Matrix(m.Row, m.Col);
            for (int i = 0; i < m.Row; i++)
                for (int j = 0; j < m.Col; j++)
                    mat[i, j] = m[i, j] * t;
            return mat;
        }

       
        public void PrintMatrix()
        {
            for (int i = 0; i < this.Row; i++)
            {
                for (int j = 0; j < this.Col; j++)
                    Console.Write("{0}  ", this[i, j]);
                Console.Write("\n");
            }

        }

       
        public static Matrix operator *(Matrix first, Matrix second)
        {
            Matrix matr = new Matrix(first.Row, first.Col);
            for (int i = 0; i < first.Row; i++)
            {
                for (int j = 0; j < second.Col; j++)
                {
                    double sum = 0;
                    for (int r = 0; r < first.Col; r++)
                        sum += first[i, r] * second[r, j];
                    matr[i, j] = sum;
                }
            }
            return matr;
        }

      
    }

    public class CaesarCipher
    {
        const string alfabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        private string CodeEncode(string text, int k)
        {
            var fullAlfabet = alfabet + alfabet.ToLower();
            var letterQty = fullAlfabet.Length;
            var retVal = "";
            for (int i = 0; i < text.Length; i++)
            {
                var c = text[i];
                var index = fullAlfabet.IndexOf(c);
                if (index < 0)
                {
                    retVal += c.ToString();
                }
                else
                {
                    var codeIndex = (letterQty + index + k) % letterQty;
                    retVal += fullAlfabet[codeIndex];
                }
            }

            return retVal;
        }

        //шифрование текста
        public string Encrypt(string plainMessage, int key)
            => CodeEncode(plainMessage, key);

        //дешифрование текста
        public string Decrypt(string encryptedMessage, int key)
            => CodeEncode(encryptedMessage, -key);
    }



    internal class Program
    {
        delegate void method();
        static void Main(string[] args)
        {

            string[] items = { "Задание 1", "Задание 2", "Задание 3", "Задание 4", "Задание 5", "Задание 6", "Задание 7", "Выход" };
            method[] methods = new method[] { Method1, Method2, Method3, Method4, Method5, Method6, Method7, Exit };
            ConsoleMenu menu = new ConsoleMenu(items);
            int menuResult;
            do
            {
                menuResult = menu.PrintMenu();
                methods[menuResult]();
                Console.WriteLine("Для продолжения нажмите любую клавишу");
                Console.ReadKey();
            } while (menuResult != items.Length - 1);
        }
        static void Method1()
        {
            Console.Clear();
            Random random = new Random();
            int[] arr = new int[5];
            double[,] arr2 = new double[3, 4];

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Clear();
                Console.Write($"Введите {i + 1} элемент масива: ");
                arr[i] = Int32.Parse(Console.ReadLine());
                Console.Clear();
            }

            Console.Write("Массив введенный пользователем: ");
            foreach (int i in arr)
                Console.Write($"{i} ");
            Console.WriteLine();

            for (int i = 0; i < arr2.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < arr2.Length / (arr2.GetUpperBound(0) + 1); j++)
                {
                    arr2[i, j] = (float)random.Next(0, 500) / 100;
                }
            }

            for (int i = 0; i < arr2.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < arr2.Length / (arr2.GetUpperBound(0) + 1); j++)
                {
                    Console.Write($"{arr2[i, j]} ");
                }
                Console.WriteLine();
            }

            int min1 = arr[0];
            int max1 = arr[0];
            double min2 = arr2[0, 0];
            double max2 = arr2[0, 0];
            double sum = 0;
            int sum4et = 0;
            double sumne4et = 0;
            double proz = 1;

            foreach (int i in arr)
            {
                if (i < min1) min1 = i;
                if (i > max1) max1 = i;
                sum += i;
                proz *= i;
                if (i % 2 == 0) sum4et += i;
            }
            for (int i = 0; i < arr2.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < arr2.Length / (arr2.GetUpperBound(0) + 1); j++)
                {
                    if ((j + 1) % 2 != 0) sumne4et += arr2[i, j];
                    if (arr2[i, j] > max2) max2 = arr2[i, j];
                    if (arr2[i, j] < min2) min2 = arr2[i, j];
                    sum += arr2[i, j];
                    proz *= arr2[i, j];
                }
            }
            Console.WriteLine(min1 == min2 ? $"Общий минимальный элемент: {min1}" : $"Общего минимального элемента нет");
            Console.WriteLine(max1 == max2 ? $"Общий максимальный элемент: {min1}" : $"Общего максимального элемента нет");
            Console.WriteLine($"Общая сумма элементов:{sum}\nОбщее произведение элементов:{proz}\nСумма четных элементов массива А:{sum4et}\nСумма нечетных столбцов массива В:{sumne4et}");

        }

        static void Method2()
        {
            Console.Clear();
            Random rand = new Random();
            int[,] arr = new int[5, 5];
            for (int i = 0; i < arr.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < arr.Length / (arr.GetUpperBound(0) + 1); j++)
                {
                    arr[i, j] = rand.Next(-100, 100);
                }
            }

            for (int i = 0; i < arr.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < arr.Length / (arr.GetUpperBound(0) + 1); j++)
                {
                    Console.Write($"{arr[i, j]} ");
                }
                Console.WriteLine();
            }

            int indexmini = 0;
            int indexminj = 0;
            int indexmaxi = 0;
            int indexmaxj = 0;
            int min = 0;
            int max = 0;
            int sum = 0;

            for (int i = 0; i < arr.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < arr.Length / (arr.GetUpperBound(0) + 1); j++)
                {
                    if (arr[i, j] < min)
                    {
                        min = arr[i, j];
                        indexmini = i;
                        indexminj = j;
                    }
                    if (arr[i, j] > max)
                    {
                        max = arr[i, j];
                        indexmaxi = i;
                        indexmaxj = j;
                    }
                }
            }

            if (indexmini > indexmaxi)
            {
                int buffer = indexmini;
                indexmini = indexmaxi;
                indexmaxi = buffer;
                buffer = indexmaxj;
                indexmaxj = indexminj;
                indexminj = buffer;
            }

            if ((indexmini == indexmaxi) && (indexminj > indexmaxj))
            {
                int buffer = indexmini;
                indexmini = indexmaxi;
                indexmaxi = buffer;
                buffer = indexmaxj;
                indexmaxj = indexminj;
                indexminj = buffer;
            }

            for (int i = indexmini; i <= indexmaxi; i++)
            {
                if (indexmini == indexmaxi)
                {
                    for (int j = indexminj + 1; j < indexmaxj; j++) sum += arr[i, j];
                }
                else if (i == indexmini)
                {
                    for (int j = indexminj + 1; j < arr.Length / (arr.GetUpperBound(0) + 1); j++) sum += arr[i, j];
                }
                else if (indexmaxi != i)
                {
                    for (int j = 0; j < arr.Length / (arr.GetUpperBound(0) + 1); j++) sum += arr[i, j];
                }
                else if (indexmaxi == i)
                {
                    for (int j = 0; j < indexmaxj; j++) sum += arr[i, j];
                }

            }
            Console.WriteLine($"Сумма элементов массива, расположенных между минимальным({min}) и максимальным({max}) элементами: {sum}");
        }

        static void Method3()
        {
            Console.Clear();
            var cipher = new CaesarCipher();
            Console.Write("Введите текст: ");
            var message = Console.ReadLine();
            Console.Write("Введите ключ: ");
            var secretKey = Convert.ToInt32(Console.ReadLine());
            var encryptedText = cipher.Encrypt(message, secretKey);
            Console.WriteLine($"Зашифрованное сообщение: {encryptedText}");
            Console.WriteLine($"Расшифрованное сообщение: {cipher.Decrypt(encryptedText, secretKey)}");
            Console.ReadLine();
        }

        static void Method4()
        {

            //размерность
            int N = 3;
            //степень
            int pow = 3;

            Random rand = new Random();
            Matrix first = new Matrix(N);
            Matrix second = new Matrix(N);

            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                {
                    first[i, j] = rand.Next(1, 4);
                    second[i, j] = rand.Next(1, 4);
                }

            Console.WriteLine("Первая матрица:\n\n");
            first.PrintMatrix();
            Console.WriteLine("\n\nВторая матрица:\n\n");
            second.PrintMatrix();
            Console.WriteLine("\n\nУмножение на число:\n\n");
            (first * 3).PrintMatrix();
            Console.WriteLine("\n\nПроизведение матриц:\n\n");
            (first * second).PrintMatrix();

            Console.ReadKey(); 
        }

        static void Method5()
        {
            Console.Clear();
            string text;
            text = Console.ReadLine();

            DataTable table = new DataTable();
            table.Columns.Add("text", typeof(string), text);
            DataRow row = table.NewRow();
            table.Rows.Add(row);
            Console.WriteLine(double.Parse((string)row["text"]));
        }

        static void Method6()
        {
            Console.Clear();
            Console.WriteLine("Введите строку:");
            string s = Console.ReadLine();
            s = s.ToLower();
            string res = "";
            string[] res1 = s.Split(new char[] { '.', '!', '?' });
            foreach (string d in res1)
            {
                char[] a = d.ToCharArray();
                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] != ' ')
                    {
                        a[i] = char.ToUpper(a[i]);
                        break;
                    }
                }
                res = string.Concat(res, new string(a));
                res = string.Concat(res, ".");
            }
            Console.WriteLine(res);
        }
        static void Method7()
        {
            Console.Clear();
            string str = $"To be, or not to be, that is the question,\n" +
                $"Whether 'tis nobler in the mind to suffer\n" +
                $"The slings and arrows of outrageous fortune,\n" +
                $"Or to take arms against a sea of troubles,\n" +
                $"And by opposing end them? To die: to sleep;\n" +
                $"No more; and by a sleep to say we end\n" +
                $"The heart-ache and the thousand natural shocks\n" +
                $"That flesh is heir to, 'tis a consummation\n" +
                $"Devoutly to be wish'd. To die, to sleep.";
            Console.WriteLine($"Текст:\n{str}");
            Console.Write("Введите слово которое убрать: ");
            string clear = Console.ReadLine();
            Console.Write("Введите на что будет заменено: ");
            string zamena = Console.ReadLine();
            str = str.Replace(clear, zamena);
            Console.WriteLine();
            Console.WriteLine("Итог: ");
            Console.WriteLine(str);
        }
        static void Exit()
        {
            Console.WriteLine("Приложение заканчивает работу!");
        }
    }

    class ConsoleMenu
    {
        string[] menuItems;
        int counter = 0;
        public ConsoleMenu(string[] menuItems)
        {
            this.menuItems = menuItems;
        }

        public int PrintMenu()
        {
            ConsoleKeyInfo key;
            do
            {
                Console.Clear();
                for (int i = 0; i < menuItems.Length; i++)
                {
                    if (counter == i)
                    {
                        Console.BackgroundColor = ConsoleColor.Cyan;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine(menuItems[i]);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                        Console.WriteLine(menuItems[i]);

                }
                key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow)
                {
                    counter--;
                    if (counter == -1) counter = menuItems.Length - 1;
                }
                if (key.Key == ConsoleKey.DownArrow)
                {
                    counter++;
                    if (counter == menuItems.Length) counter = 0;
                }
            }
            while (key.Key != ConsoleKey.Enter);
            return counter;
        }
    }
}
