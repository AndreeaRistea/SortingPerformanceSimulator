using SortingPerformanceSimulator.Interfaces;
using SortingPerformanceSimulator.Utils;
using System.Diagnostics;

namespace SortingPerformanceSimulator.Algortihms.Parallel
{
    public class QuickSortParallel
    {
        private readonly ISortHelper sortHelper;

        public QuickSortParallel(ISortHelper sortHelper)
        {
            this.sortHelper = sortHelper;
        }

        public static void Sort(int[] array, int left, int right)
        {
            if (left >= right)
                return;

            int pivotIndex = Partition(array, left, right);

            System.Threading.Tasks.Parallel.Invoke(
                () => Sort(array, left, pivotIndex - 1),
                () => Sort(array, pivotIndex + 1, right)
            );
        }

        public static int Partition(int[] array, int left, int right)
        {
            int pivot = array[right];
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                if (array[j] <= pivot)
                {
                    i++;
                    Swap(array, i, j);
                }
            }

            Swap(array, i + 1, right);
            return i + 1;
        }

        public static void Swap(int[] array, int i, int j)
        {
            if (i == j) return;
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
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
            Sort(arr, 0, arr.Length - 1);
            stopwatch.Stop();

            double executionTime = stopwatch.Elapsed.TotalSeconds;

            var constants = new Constants();

            sortHelper.AppendSortResult("QuickSort Parallel", arr, executionTime, constants.outputQuickSort);
        }
    }
}