using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace StringGenerator
{
    internal class Program
    {
        static string GenerateStringConcat(int count)
        {
            string result = "";
            for (int i = 0; i < count; i++)
            {
                result += $"Итерация: {i} ";
            }
            return result;
        }

        static string GenerateStringSB(int count)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                sb.Append($"Итерация: {i} ");
            }
            return sb.ToString();
        }
        static void Main(string[] args)
        {
            int[] counts = { 1000, 10000, 100000 };

         string resultsFile = "results.txt";

            File.WriteAllText(resultsFile, "Count\tConcat Time (ms)\tStringBuilder Time (ms)\n");

            foreach (int count in counts)
            {
                Stopwatch swConcat = Stopwatch.StartNew();
                string resultConcat = GenerateStringConcat(count);
                swConcat.Stop();

                Stopwatch swSB = Stopwatch.StartNew();
                string resultSB = GenerateStringSB(count);
                swSB.Stop();

                string resultLine = $"{count}\t{swConcat.ElapsedMilliseconds}\t{swSB.ElapsedMilliseconds}\n";
                File.AppendAllText(resultsFile, resultLine);

                Console.WriteLine($"Количество итераций: {count}");
                Console.WriteLine($"Время конкатенации: {swConcat.ElapsedMilliseconds} мс");
                Console.WriteLine($"Время StringBuilder: {swSB.ElapsedMilliseconds} мс");
                Console.WriteLine();
            }

            Console.WriteLine($"Результаты записаны в файл: {resultsFile}");
        }

       
      

      
    }
}

