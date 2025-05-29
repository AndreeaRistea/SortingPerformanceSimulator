using SortingPerformanceSimulator.Interfaces;
using SortingPerformanceSimulator.Utils;
using System.Diagnostics;

namespace SortingPerformanceSimulator.Algortihms.Parallel
{
    public class HeapSortParallel
    {
        private readonly ISortHelper sortHelper;
        public HeapSortParallel(ISortHelper sortHelper)
        {
            this.sortHelper = sortHelper;
        }

        static void Heapify(int[] array, int n, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            if (left < n && array[left] > array[largest])
                largest = left;
            if (right < n && array[right] > array[largest])
                largest = right;

            if (largest != i)
            {
                // Swap and continue heapifying
                int temp = array[i];
                array[i] = array[largest];
                array[largest] = temp;

                Heapify(array, n, largest);
            }
        }

        static async Task SortAsync(int[] array)
        {
            int n = array.Length;

            // Build heap in parallel (bottom-up heapify)
            var tasks = new Task[n / 2];
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                int idx = i;
                tasks[i] = Task.Run(() => Heapify(array, n, idx));
            }

            await Task.WhenAll(tasks);

            // One by one extract elements (this part is inherently sequential)
            for (int i = n - 1; i > 0; i--)
            {
                // Swap
                int temp = array[0];
                array[0] = array[i];
                array[i] = temp;

                // Heapify root
                Heapify(array, i, 0);
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

            sortHelper.AppendSortResult("HeapSort Parallel", arr, executionTime, constants.outputHeapSort);
        }
    }
}
