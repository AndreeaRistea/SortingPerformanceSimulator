using SortingPerformanceSimulator.Interfaces;
using SortingPerformanceSimulator.Utils;
using System.Diagnostics;

namespace SortingPerformanceSimulator.Algortihms.Seqential
{
    public class MergeSortSequential : ISortAlgorithm
    {
        private readonly ISortHelper sortHelper;
        public MergeSortSequential(ISortHelper sortHelper)
        {
            this.sortHelper = sortHelper;
        }

        public void Sort(int[] array)
        {
            MergeSort(array, 0, array.Length - 1);
        }

        private void MergeSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;
                MergeSort(array, left, mid);
                MergeSort(array, mid + 1, right);
                Merge(array, left, mid, right);
            }
        }

        private void Merge(int[] array, int left, int mid, int right)
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

            while (i <= mid) temp[k++] = array[i++];
            while (j <= right) temp[k++] = array[j++];

            for (i = left; i <= right; i++)
                array[i] = temp[i - left];
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

            sortHelper.AppendSortResult("MergeSort Sequential", arr, executionTime, constants.outputMergeSort);
        }
    }

}
