using System;
using System.Drawing;

namespace Les_0210
{
    
    class Program
    {
        static void Main(string[] args)
        {
            double a, b, c, number;
            int n, num1, num2, num;
            int[] numbers;
            string[] str;
            double[] numbers_double;
            string messageForInvalidInput = "Неверный ввод";
            char[] messageError = { 'e', 'r', 'r', 'o', 'r' };
            Random rnd = new Random();
            Bitmap[] images = 
            {
                new Bitmap(@"Img\0.png"),

                new Bitmap(@"Img\1.png"),
                new Bitmap(@"Img\2.png"),
                new Bitmap(@"Img\3.png"),
                new Bitmap(@"Img\4.png"),
                new Bitmap(@"Img\5.png"),
                new Bitmap(@"Img\6.png"),
                new Bitmap(@"Img\7.png"),
                new Bitmap(@"Img\8.png"),
                new Bitmap(@"Img\9.png")
            };
            
            int[] u = { 1, 2, 3, 4 };

            try
            {                
                Console.WriteLine("1.");
            Start1:
                try
                {
                    Console.Write("a: ");
                    a = Convert.ToDouble(Console.ReadLine());
                    Console.Write("b: ");
                    b = Convert.ToDouble(Console.ReadLine());
                    Console.Write("c: ");
                    c = Convert.ToDouble(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine(messageForInvalidInput);
                    goto Start1;
                }
                int k = 0;
                foreach(Complex x in SolveQuadraticEquation(a, b, c))
                {
                    if (Double.IsNaN(x.Real))
                    {
                        Console.WriteLine("x = C (вся коплескная плоскость)");
                        break;
                    }
                    Console.WriteLine($"x{++k} = {x}");
                }
                if (SolveQuadraticEquation(a, b, c).Length == 0)
                {
                    Console.WriteLine("Нет комплексных корней");
                }
                
                Console.WriteLine("\n2.");
                n = 20;
                numbers = new int[n];
                for (int i = 0; i < n; i++)
                {
                Start:
                    numbers[i] = rnd.Next(20);
                    if (Array.IndexOf(numbers, numbers[i]) != i)
                    {
                        goto Start;
                    }
                }
                Console.WriteLine(String.Join(" ", numbers));
            Start2:
                try
                {
                    num1 = Convert.ToInt32(Console.ReadLine());
                    num2 = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine(messageForInvalidInput);
                    goto Start2;
                }                
                int index1 = Array.IndexOf(numbers, num1);
                int index2 = Array.IndexOf(numbers, num2);
                if (index1 < 0 || index2 < 0)
                {
                    Console.WriteLine(messageForInvalidInput);
                    goto Start2;
                }
                num = numbers[index1];
                numbers[index1] = numbers[index2];
                numbers[index2] = num;
                Console.WriteLine(String.Join(" ", numbers));
                
                Console.WriteLine("\n3.\nВведите целые числа через пробел:");
            Start3:
                try
                {
                    str = Console.ReadLine().Split();
                    numbers = new int[str.Length];
                    for(int i = 0; i < str.Length; i++)
                    {
                        numbers[i] = Convert.ToInt32(str[i]);
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine(messageForInvalidInput);
                    goto Start3;
                }
                for(int i = 0; i < numbers.Length; i++)
                {
                    for(int j = i + 1; j < numbers.Length; j++)
                    {
                        if(numbers[i] > numbers[j])
                        {
                            num = numbers[i];
                            numbers[i] = numbers[j];
                            numbers[j] = num;
                        }
                    }
                }
                Console.WriteLine(String.Join(" ", numbers));
                
                Console.WriteLine("\n4.\nВведите любые числа через пробел:");
            Start4:
                try
                {
                    str = Console.ReadLine().Split();
                    numbers_double = new double[str.Length];
                    for (int i = 0; i < str.Length; i++)
                    {
                        numbers_double[i] = Convert.ToDouble(str[i]);
                    }                    
                }
                catch (FormatException)
                {
                    Console.WriteLine(messageForInvalidInput);
                    goto Start4;
                }
                double product = 1, mean;
                Console.WriteLine($"Сумма = {SumProductMean(ref product, out mean, numbers_double)}");
                Console.WriteLine($"Произведение = {product}");
                Console.WriteLine($"Среднее арифметическое = {mean}");
                
                Console.WriteLine("\n5.");
            Start5:
                try
                {
                    Console.Write("Число: ");
                    string input = Console.ReadLine();
                    if (Equals(input.ToLower(), "exit") || Equals(input.ToLower(), "закрыть"))
                    {
                        Console.WriteLine("Вы вышли");
                    }
                    else {
                        number = Convert.ToDouble(input);
                        if (number >= 0 && number <= 9)
                        {
                            n = Convert.ToInt32(input);
                            for (int i = 0; i < images[n].Height; i++)
                            {
                                for (int j = 0; j < images[n].Width; j++)
                                {
                                    if (images[n].GetPixel(j, i) == Color.FromArgb(255, 255, 255, 255))
                                    {
                                        Console.Write(" ");
                                    }
                                    else
                                    {
                                        Console.Write("#");
                                    }
                                }
                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            char[] message = new char[5];
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Clear();
                            int secondsStartPosition = DateTime.Now.Second;
                            if (secondsStartPosition >= 57)
                            {
                                secondsStartPosition = secondsStartPosition - 60;
                            }
                            while (DateTime.Now.Second != secondsStartPosition + 3)
                            {
                                for (int i = 0; i < messageError.Length; i++)
                                {
                                    if (rnd.Next(0, 2) == 0)
                                    {
                                        message[i] = Char.ToUpper(messageError[i]);
                                    }
                                    else
                                    {
                                        message[i] = messageError[i];
                                    }
                                }
                                Console.Write(String.Join("", message) + " ");
                            }                           
                            Console.ResetColor();
                            Console.Clear();
                            throw new FormatException();
                        }
                        goto Start5;
                    }                    
                }
                catch (FormatException)
                {
                    Console.WriteLine(messageForInvalidInput);
                    goto Start5;
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
            }

            Console.ReadLine();
        }        

        class Complex
        {
            public double Real;
            public double Imaginary;

            public override string ToString()
            {
                double x = Real, y = Imaginary;
                if (y == 0) return $"{x}";
                else if (y > 0) return $"{x} + {y}i";
                else return $"{x} - {-y}i";
            }
        }

        static Complex[] SolveQuadraticEquation(double a, double b, double c)
        {
            Complex x1 = new Complex();
            Complex x2 = new Complex();
            if (a == 0)
            {
                if (b != 0 || c == 0)
                {
                    x1.Real = -c / b;
                    return new Complex[1] { x1 };
                }
                else
                {
                    return new Complex[0];
                }
            }
            else
            {
                double D = b * b - 4 * a * c;
                if (D > 0)
                {
                    x1.Real = (-b - Math.Sqrt(D)) / 2 / a;
                    x2.Real = (-b + Math.Sqrt(D)) / 2 / a;
                    return new Complex[2] { x1, x2 };
                }
                else if (D == 0)
                {
                    x1.Real = -b / 2 / a;
                    return new Complex[2] { x1, x1 };
                }
                else
                {
                    x1.Real = -b / 2 / a;
                    x1.Imaginary = -Math.Sqrt(-D) / 2 / a;
                    x2.Real = -b / 2 / a;
                    x2.Imaginary = Math.Sqrt(-D) / 2 / a;
                    return new Complex[2] { x1, x2 };
                }
            }
        }

        static double SumProductMean(ref double product, out double mean, params double[] numbers)
        {
            double sum = 0;            
            foreach (double num in numbers)
            {
                sum += num;
                product *= num;
            }
            mean = sum / numbers.Length;
            return sum;
        }
    }    
}
