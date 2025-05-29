using SortingPerformanceSimulator.Interfaces;
using SortingPerformanceSimulator.Utils;
using System.Diagnostics;

namespace SortingPerformanceSimulator.Algortihms.Seqential
{
    public class QuickSortSequential : ISortAlgorithm
    {
        private readonly ISortHelper sortHelper;
        public QuickSortSequential(ISortHelper sortHelper)
        {
            this.sortHelper = sortHelper;
        }

        public void Sort(int[] array)
        {
            QuickSort(array, 0, array.Length - 1);
        }

        private void QuickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                int pi = Partition(arr, low, high);
                QuickSort(arr, low, pi - 1);
                QuickSort(arr, pi + 1, high);
            }
        }

        private int Partition(int[] arr, int low, int high)
        {
            int pivot = arr[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    (arr[i], arr[j]) = (arr[j], arr[i]);
                }
            }

            (arr[i + 1], arr[high]) = (arr[high], arr[i + 1]);
            return i + 1;
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

            sortHelper.AppendSortResult("QuickSort Sequential", arr, executionTime, constants.outputQuickSort);
        }
    }

}
