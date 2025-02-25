using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace debug
{
    

    internal class Program
    {

        // Ошибка: нет обработки некорректного ввода
        static double GetNumberFromUser(string prompt)
        {
            Console.Write(prompt);
            return double.Parse(Console.ReadLine()); // Убрана проверка TryParse
        }

        static char GetOperationFromUser(string prompt)
        {
            char operation;
            while (true)
            {
                Console.Write(prompt);
                if (char.TryParse(Console.ReadLine(), out operation) && "+-*/".Contains(operation))
                {
                    return operation;
                }
                else
                {
                    Console.WriteLine("Ошибка: введена некорректная операция. Допустимые операции: +, -, *, /.");
                }
            }
        }

        // Ошибка: деление на ноль и неправильная логика
        static double PerformCalculation(double num1, double num2, char operation)
        {
            switch (operation)
            {
                case '+':
                    return num1 - num2; 
                case '-':
                    return num1 + num2; 
                case '*':
                    return num1 * num2;
                case '/':
                    
                   return num1 / num2;
                default:
                    throw new InvalidOperationException("Недопустимая операция.");
            }
        }




        static void LoadSystemCPU(int durationInSeconds)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            while (stopwatch.Elapsed.TotalSeconds < durationInSeconds)
            {
               
                for (int i = 0; i < 1000000; i++)
                {
                   Math.Sqrt(i);
              
                }
            }
            stopwatch.Stop();
        }
        static void Main(string[] args)
        {
            LoadSystemCPU(100);

            double num1 = GetNumberFromUser("Введите первое число: ");
            Debug.WriteLine($"Значение 1 числа: {num1}");
            double num2 = GetNumberFromUser("Введите второе число: ");
            char operation = GetOperationFromUser("Введите операцию (+, -, *, /): ");
            Trace.Listeners.Add(new TextWriterTraceListener("log.txt"));
            Trace.AutoFlush = true;
            Trace.WriteLine($"Значение 1 числа: {num1}");
            double result = 0;
            bool calculationSuccessful = false;


            result = PerformCalculation(num1, num2, operation);
            calculationSuccessful = true;



            if (calculationSuccessful)
            {
                Console.WriteLine($"Результат: {result}");
            }
        }

    }






}

