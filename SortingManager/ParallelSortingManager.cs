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

        public void RunParallelBubbleSort(Constants constants)
        {
            bubbleSort.RunFromFile(constants.dataSetMedium);
            bubbleSort.RunFromFile(constants.dataSetBig);
            bubbleSort.RunFromFile(constants.dataSetLargest);
        }

        public void RunParallelHeapSort(Constants constants)
        {
            heapSort.RunFromFile(constants.dataSetMedium);
            heapSort.RunFromFile(constants.dataSetBig);
            heapSort.RunFromFile(constants.dataSetLargest);
        }

        public void RunParallelMergeSort(Constants constants)
        {
            mergeSort.RunFromFile(constants.dataSetMedium);
            mergeSort.RunFromFile(constants.dataSetBig);
            mergeSort.RunFromFile(constants.dataSetLargest);
        }

        public void RunParallelQuickSort(Constants constants)
        {
            quickSort.RunFromFile(constants.dataSetMedium);
            quickSort.RunFromFile(constants.dataSetBig);
            quickSort.RunFromFile(constants.dataSetLargest);
        }
    }
}
