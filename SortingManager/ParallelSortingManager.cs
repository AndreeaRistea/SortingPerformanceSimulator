using SortingPerformanceSimulator.Algortihms.Parallel;
using SortingPerformanceSimulator.Algortihms.Seqential;
using SortingPerformanceSimulator.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingPerformanceSimulator.SortingManager
{
    public class ParallelSortingManager
    {
        private readonly BubbleSortParallel bubbleSort;

        private readonly HeapSortParallel heapSort;

        private readonly MergeSortParallel mergeSort;

        private readonly QuickSortParallel quickSort;

        public ParallelSortingManager(BubbleSortParallel bubbleSort,
             HeapSortParallel heapSort, MergeSortParallel mergeSort, QuickSortParallel quickSort)
        {
            this.bubbleSort = bubbleSort;
            this.heapSort = heapSort;
            this.mergeSort = mergeSort;
            this.quickSort = quickSort;
        }

        public async Task RunParallelBubbleSortAsync(Constants constants)
        {
            //await bubbleSort.RunFromFileAsync(constants.dataSetMedium);
            //await bubbleSort.RunFromFileAsync(constants.dataSetBig);
            await bubbleSort.RunFromFileAsync(constants.dataSetLargest);
        }

        public async Task RunParallelHeapSortAsync(Constants constants)
        {
            await heapSort.RunFromFileAsync(constants.dataSetMedium);
            await heapSort.RunFromFileAsync(constants.dataSetBig);
            await heapSort.RunFromFileAsync(constants.dataSetLargest);
        }

        public async Task RunParallelMergeSortAsync(Constants constants)
        {
            await mergeSort.RunFromFileAsync(constants.dataSetMedium);
            await mergeSort.RunFromFileAsync(constants.dataSetBig);
            await mergeSort.RunFromFileAsync(constants.dataSetLargest);
        }

        public async Task RunParallelQuickSortAsync(Constants constants)
        {
            await quickSort.RunFromFileAsync(constants.dataSetMedium);
            await quickSort.RunFromFileAsync(constants.dataSetBig);
            await quickSort.RunFromFileAsync(constants.dataSetLargest);
        }
    }
}
