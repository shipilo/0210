using System;

namespace Met_0210
{
    class Program
    {
        static void Main(string[] args)
        {
            string str1, str2;
            decimal factorial;
            int n;
            try
            {            
                Console.WriteLine("Упаражненеие 5.1\nДва целых числа:");
            Start1:
                try
                {
                    Console.WriteLine("Максимальное из них: " +
                        $"{MaxValueOfTwoNumbers(Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()))}");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ещё раз");
                    goto Start1;
                }
                
                Console.WriteLine("\nУпаражненеие 5.2\nДва любых значения:");
                str1 = Console.ReadLine();
                str2 = Console.ReadLine();
                ChangeStringPlaces(ref str1, ref str2);
                Console.WriteLine($"{str1} {str2}");
                
                Console.WriteLine("\nУпаражненеие 5.3");
            Start3:
                try
                {
                    Console.Write("Целое число: ");
                    factorial = Convert.ToDecimal(Console.ReadLine());
                    if (factorial > 0)
                    {
                        if (Factorial(ref factorial))
                        {
                            Console.WriteLine(factorial);
                        }
                        else
                        {
                            Console.WriteLine("Ошибка");
                        }
                    }
                    else throw new FormatException();
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ещё раз");
                    goto Start3;
                }
                
                Console.WriteLine("\nУпаражненеие 5.4");
            Start4:
                try
                {
                    Console.Write("Целое число: ");
                    n = Convert.ToInt32(Console.ReadLine());
                    if (n > 0)
                    {
                        factorial = 1;
                        if (FactorialWithlRecursion(ref factorial, 1, n))
                        {
                            Console.WriteLine(factorial);
                        }
                        else
                        {
                            Console.WriteLine("Ошибка");
                        }
                    }
                    else throw new FormatException();
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ещё раз");
                    goto Start4;
                }
                
                Console.WriteLine("\nДомашнее задание 5.1");
            Start5:
                try
                {
                    Console.WriteLine("2 целых числа:");
                    Console.WriteLine("НОД = " + GreatestCommonFactor(Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine())));

                }
                catch (FormatException)
                {
                    Console.WriteLine("Ещё раз");
                    goto Start5;
                }    
            Start6:
                try
                {
                    Console.WriteLine("3 целых числа:");
                    Console.WriteLine("НОД = " + GreatestCommonFactor(Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine()), Convert.ToInt32(Console.ReadLine())));
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ещё раз");
                    goto Start6;
                }
                
                Console.WriteLine("\nДомашнее задание 5.2\n(-1 означает переполнение)");
            Start7:
                try
                {
                    n = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(Fibonacci(1, 1, 2, n));
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ещё раз");
                    goto Start7;
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
            }


            Console.ReadLine();
        }

        static int MaxValueOfTwoNumbers(int value1, int value2)
        {
            if (value1 > value2)
            {
                return value1;
            }
            else
            {
                return value2;
            }
        }

        static void ChangeStringPlaces(ref string value1, ref string value2)
        {
            string value = value1;
            value1 = value2;
            value2 = value;
        }

        static bool Factorial(ref decimal factorial)
        {
            int n = (int)factorial;
            factorial = 1;
            try
            {
                for (int i = 1; i <= n; i++)
                {
                    factorial *= i;
                }
                return true;
            }
            catch (OverflowException)
            {
                return false;
            }            
        }

        static bool FactorialWithlRecursion(ref decimal factorial, int k, int n)
        {
            try
            {
                if (k <= n)
                {
                    factorial *= k++;
                    if (!FactorialWithlRecursion(ref factorial, k, n))
                    {
                        throw new OverflowException();
                    }
                }
                return true;
            }
            catch (OverflowException)
            {
                return false;
            }
        }
        static int GreatestCommonFactor(int num1, int num2)
        {
            if (num1 < num2)
            {
                int num = num1;
                num1 = num2;
                num2 = num;
            }
            if (num1 % num2 == 0)
            {
                return num2;
            }
            else
            {
                return GreatestCommonFactor(num2, num1 % num2);
            }
        }
        static int GreatestCommonFactor(int num1, int num2, int num3)
        {
            return GreatestCommonFactor(GreatestCommonFactor(num1, num2), num3);
        }
        static int Fibonacci(int n1, int n2, int k, int n)
        {
            try
            {
                if (n == 1)
                {
                    return n1;
                }
                else if (n == k)
                {
                    return n2;
                }
                else
                {
                    return Fibonacci(n2, n1 + n2, ++k, n);
                }
            }
            catch (OverflowException)
            {
                return -1;
            }
        }
    }
}