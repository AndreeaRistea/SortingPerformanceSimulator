using SortingPerformanceSimulator.Interfaces;
using SortingPerformanceSimulator.Utils;
using System.Diagnostics;

namespace SortingPerformanceSimulator.Algortihms.Parallel
{
    public class BubbleSortParallel
    {
        private readonly ISortHelper sortHelper;
        public BubbleSortParallel(ISortHelper sortHelper)
        {
            this.sortHelper = sortHelper;
        }

        public void Sort(int[] array)
        {
            int n = array.Length;
            bool swapped;

            do
            {
                swapped = false;

                System.Threading.Tasks.Parallel.For(1, n / 2 + 1, i =>
                {
                    int j = 2 * i - 1;
                    if (j < n - 1 && array[j] > array[j + 1])
                    {
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                        swapped = true;
                    }
                });

                System.Threading.Tasks.Parallel.For(0, n / 2, i =>
                {
                    int j = 2 * i;
                    if (j < n - 1 && array[j] > array[j + 1])
                    {
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                        swapped = true;
                    }
                });

            } while (swapped);
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

            sortHelper.AppendSortResult("BubbleSort Parallel", arr, executionTime, constants.outputBubbleSort);
        }
    }
}
