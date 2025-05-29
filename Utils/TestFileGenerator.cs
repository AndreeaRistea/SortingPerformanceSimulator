using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingPerformanceSimulator.Utils
{
    public class TestFileGenerator
    {
        private readonly string _outputDirectory;

        public TestFileGenerator(string outputDirectory = "TestFiles")
        {
            _outputDirectory = outputDirectory;

            // Creează directorul dacă nu există
            if (!Directory.Exists(_outputDirectory))
            {
                Directory.CreateDirectory(_outputDirectory);
            }
        }

        public string GenerateTestFile(int size, int minValue = 0, int maxValue = 100000)
        {
            Random random = new Random();
            int[] numbers = new int[size];
            for (int i = 0; i < size; i++)
            {
                numbers[i] = random.Next(minValue, maxValue);
            }

            string fileName = $"Test_{size}_elements.txt";
            string filePath = Path.Combine(_outputDirectory, fileName);

            // Salvează numerele separate prin spațiu
            File.WriteAllText(filePath, string.Join(" ", numbers));

            return filePath;
        }
    }
}
