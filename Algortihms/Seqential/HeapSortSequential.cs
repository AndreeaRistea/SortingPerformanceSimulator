using SortingPerformanceSimulator.Interfaces;
using SortingPerformanceSimulator.Utils;
using System.Diagnostics;

namespace SortingPerformanceSimulator.Algortihms.Seqential
{
    public class HeapSortSequential : ISortAlgorithm
    {
        private readonly ISortHelper sortHelper;
        public HeapSortSequential(ISortHelper sortHelper)
        {
            this.sortHelper = sortHelper;
        }

        public void Sort(int[] array)
        {
            int n = array.Length;

            for (int i = n / 2 - 1; i >= 0; i--)
                Heapify(array, n, i);

            for (int i = n - 1; i > 0; i--)
            {
                (array[0], array[i]) = (array[i], array[0]);
                Heapify(array, i, 0);
            }
        }

        private void Heapify(int[] arr, int n, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            if (left < n && arr[left] > arr[largest])
                largest = left;

            if (right < n && arr[right] > arr[largest])
                largest = right;

            if (largest != i)
            {
                (arr[i], arr[largest]) = (arr[largest], arr[i]);
                Heapify(arr, n, largest);
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

            sortHelper.AppendSortResult("HeapSort Sequential", arr, executionTime, constants.outputHeapSort);
        }
    }
}
