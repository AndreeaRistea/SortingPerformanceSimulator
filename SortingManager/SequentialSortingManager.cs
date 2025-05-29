using SortingPerformanceSimulator.Algortihms.Seqential;
using SortingPerformanceSimulator.Utils;

namespace SortingPerformanceSimulator.SortingManager
{
    public class SequentialSortingManager
    {
        private readonly BubbleSortSequential bubbleSort;

        private readonly HeapSortSequential heapSort;

        private readonly MergeSortSequential mergeSort;

        private readonly QuickSortSequential quickSort;

        public SequentialSortingManager (BubbleSortSequential bubbleSort,
              HeapSortSequential heapSort, MergeSortSequential mergeSort, QuickSortSequential quickSort)
        {
            this.bubbleSort= bubbleSort;
            this.heapSort= heapSort;
            this.mergeSort= mergeSort;
            this.quickSort= quickSort;
        }

        public void RunSequentialBubbleSort (Constants constants)
        {
            //bubbleSort.RunFromFile(constants.dataSetMedium);
            //bubbleSort.RunFromFile(constants.dataSetBig);
            bubbleSort.RunFromFile(constants.dataSetLargest);  
        }

        public void RunSequentialHeapSort(Constants constants)
        {
            heapSort.RunFromFile(constants.dataSetMedium);
            heapSort.RunFromFile(constants.dataSetBig);
            heapSort.RunFromFile(constants.dataSetLargest);
        }

        public void RunSequentialMergeSort(Constants constants)
        {
            mergeSort.RunFromFile(constants.dataSetMedium);
            mergeSort.RunFromFile(constants.dataSetBig);
            mergeSort.RunFromFile(constants.dataSetLargest);
        }

        public void RunSequentialQuickSort(Constants constants)
        {
            quickSort.RunFromFile(constants.dataSetMedium);
            quickSort.RunFromFile(constants.dataSetBig);
            quickSort.RunFromFile(constants.dataSetLargest);
        }
    }
}
