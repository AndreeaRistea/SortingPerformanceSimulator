using SortingPerformanceSimulator.Interfaces;
using SortingPerformanceSimulator.Utils;
using System.Diagnostics;

namespace SortingPerformanceSimulator.Algortihms.Parallel
{
    public class MergeSortParallel
    {
        private readonly ISortHelper sortHelper;
        public MergeSortParallel(ISortHelper sortHelper)
        {
            this.sortHelper = sortHelper;
        }

        public static async Task SortAsync(int[] array, int left, int right)
        {
            if (left >= right)
                return;

            int mid = (left + right) / 2;

            // Sort left and right halves in parallel
            Task leftTask = SortAsync(array, left, mid);
            Task rightTask = SortAsync(array, mid + 1, right);

            await Task.WhenAll(leftTask, rightTask);

            // Merge the sorted halves
            Merge(array, left, mid, right);
        }

        public static void Merge(int[] array, int left, int mid, int right)
        {
            int[] temp = new int[right - left + 1];
            int i = left, j = mid + 1, k = 0;

            while (i <= mid && j <= right)
            {
                if (array[i] <= array[j])
                    temp[k++] = array[i++];
                else
                    temp[k++] = array[j++];
            }

            while (i <= mid)
                temp[k++] = array[i++];
            while (j <= right)
                temp[k++] = array[j++];

            // Copy back to original array
            for (int t = 0; t < temp.Length; t++)
                array[left + t] = temp[t];
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
            await SortAsync(arr, 0, arr.Length-1);
            stopwatch.Stop();

            double executionTime = stopwatch.Elapsed.TotalSeconds;

            var constants = new Constants();

            sortHelper.AppendSortResult("MergeSort Parallel", arr, executionTime, constants.outputMergeSort);
        }
    }
}
