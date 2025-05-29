using SortingPerformanceSimulator.Interfaces;
using SortingPerformanceSimulator.Utils;
using System.Diagnostics;

namespace SortingPerformanceSimulator.Algortihms.Seqential
{
    public class BubbleSortSequential : ISortAlgorithm
    {
        private readonly ISortHelper sortHelper;
        public BubbleSortSequential(ISortHelper sortHelper)
        {
            this.sortHelper = sortHelper;
        }
        public void Sort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                    }
                }
            }
        }

        public void RunFromFile(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentNullException(nameof(filePath));

            int[] arr = sortHelper.ReadDataFromFile(filePath);

            if (arr is null || arr.Length == 0)
            {
                Console.WriteLine("Input file is empty or contains invalid data.");
                return;
            }

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Sort(arr);
            stopwatch.Stop();
            double executionTime = stopwatch.Elapsed.TotalSeconds;

            var constants = new Constants();
           
            sortHelper.AppendSortResult("BubbleSort Sequential", arr, executionTime, constants.outputBubbleSort);
        }
    }

}
