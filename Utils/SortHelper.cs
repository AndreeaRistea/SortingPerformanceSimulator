using SortingPerformanceSimulator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingPerformanceSimulator.Utils
{
    public class SortHelper : ISortHelper
    {
        public int[] ReadDataFromFile(string filePath)
        {
            if (!File.Exists(filePath))
                return null;

            string content = File.ReadAllText(filePath);
            if (string.IsNullOrWhiteSpace(content))
                return null;

            try
            {
                return content
                    .Split(new[] { ' ', '\n', '\r', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }
            catch
            {
                return null;
            }
        }

        //public void PrintArray(int[] array, string title)
        //{
        //    Console.WriteLine(title);
        //    Console.WriteLine(string.Join(", ", array.Take(100)) + (array.Length > 100 ? " ..." : ""));
        //}

        public void PrintArray(int[] array, string title, string outputDirectory)
        {
            // Creează folderul dacă nu există
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Nume fișier generat automat
            string fileName = $"{title.Replace(" ", "_")}_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
            string filePath = Path.Combine(outputDirectory, fileName);

            // Pregătirea conținutului
            var content = string.Join(", ", array.Take(100)) + (array.Length > 100 ? " ..." : "");

            try
            {
                File.WriteAllText(filePath, content);
                Console.WriteLine($"Rezultatul a fost salvat în: {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Eroare la scrierea fișierului: {ex.Message}");
            }
        }

        public void AppendSortResult(string algorithmName, int[] array, double executionTime, string outputFilePath)
        {
            var preview = string.Join(", ", array.Take(100)) + (array.Length > 100 ? " ..." : "");
            var content =
        $@"----------------------------------------
        {DateTime.Now:yyyy-MM-dd HH:mm:ss}
        Algorithm: {algorithmName}
        Array Size: {array.Length}
        Execution Time: {executionTime:F4} seconds
        First 100 elements: 
        {preview}
        ";

            File.AppendAllText(outputFilePath, content);
        }
    }
}
