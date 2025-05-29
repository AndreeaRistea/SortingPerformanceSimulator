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

        public async Task SortAsync(int[] array)
        {
            int n = array.Length;

            for (int pass = 0; pass < n; pass++)
            {
                int start = pass % 2; // Even-odd pass alternation
                var tasks = new List<Task>();

                for (int i = start; i < n - 1; i += 2)
                {
                    int idx = i; // Capture loop variable for closure
                    tasks.Add(Task.Run(() =>
                    {
                        if (array[idx] > array[idx + 1])
                        {
                            // Swap
                            int temp = array[idx];
                            array[idx] = array[idx + 1];
                            array[idx + 1] = temp;
                        }
                    }));
                }
                await Task.WhenAll(tasks);
            }
        }

        public async Task RunFromFileAsync(string filePath)
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
            await SortAsync(arr);
            stopwatch.Stop();
            double executionTime = stopwatch.Elapsed.TotalSeconds;

            var constants = new Constants();

            sortHelper.AppendSortResult("BubbleSort Parallel", arr, executionTime, constants.outputBubbleSort);
        }
    }
}
