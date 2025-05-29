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

        static void Sort(int[] array)
        {
            int n = array.Length;

            int maxDepth = (int)Math.Log2(n);
            for (int depth = maxDepth; depth >= 0; depth--)
            {
                int start = (1 << depth) - 1;
                int end = Math.Min((1 << (depth + 1)) - 2, n - 1);

                System.Threading.Tasks.Parallel.For(start, end + 1, i => Heapify(array, n, i));
            }

            for (int i = n - 1; i >= 1; i--)
            {
                (array[0], array[i]) = (array[i], array[0]); // Swap
                Heapify(array, i, 0); // Restore heap
            }
        }

        public async void RunFromFile(string filePath)
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

            sortHelper.AppendSortResult("HeapSort Parallel", arr, executionTime, constants.outputHeapSort);
        }
    }
}
