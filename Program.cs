using SortingPerformanceSimulator.Algortihms.Parallel;
using SortingPerformanceSimulator.Algortihms.Seqential;
using SortingPerformanceSimulator.SortingManager;
using SortingPerformanceSimulator.Utils;

class Program
{
    static void Main()
    {
        var constants = new Constants();
        var sortHelper = new SortHelper();

        var bubbleSequential = new BubbleSortSequential(sortHelper);
        var bubbleParallel = new BubbleSortParallel(sortHelper);

        var heapSortSequential = new HeapSortSequential(sortHelper);
        var heapSortParallel = new HeapSortParallel(sortHelper);

        var mergeSortSequential = new MergeSortSequential(sortHelper);   
        var mergeSortParallel = new MergeSortParallel(sortHelper);

        var quickSortSequential = new QuickSortSequential(sortHelper);   
        var quickSortParallel = new QuickSortParallel(sortHelper);

        var sequentialSortingManager = new SequentialSortingManager(bubbleSequential, heapSortSequential,
          mergeSortSequential, quickSortSequential);

        var parallelSortingManager = new ParallelSortingManager(bubbleParallel, heapSortParallel,
            mergeSortParallel, quickSortParallel);

        // sequentialSortingManager.RunSequentialBubbleSort(constants);
        // parallelSortingManager.RunParallelBubbleSort(constants);

        // sequentialSortingManager.RunSequentialHeapSort(constants);
        // parallelSortingManager.RunParallelHeapSort(constants);

        sequentialSortingManager.RunSequentialQuickSort(constants);
        parallelSortingManager.RunParallelQuickSort(constants);

        // sequentialSortingManager.RunSequentialMergeSort(constants);
        // parallelSortingManager.RunParallelMergeSort(constants);

        // var sortHelper = new SortHelper();
        // var generator = new TestFileGenerator(constants.dataSetLoc);

        // generator.GenerateTestFile(1000);
        // generator.GenerateTestFile(10000);
        // generator.GenerateTestFile(100_000_000);

        //Console.WriteLine("Fișierele de test au fost generate.");

        //var bubbleSequential = new BubbleSortSequential(sortHelper);
        //var bubbleParallel = new BubbleSortParallel(sortHelper);

        //bubbleSequential.RunFromFile(constants.dataSetMedium);
 
        //await bubbleParallel.RunFromFileAsync(constants.dataSetMedium);

        //bubbleSequential.RunFromFile(constants.dataSetBig);

        //await bubbleParallel.RunFromFileAsync(constants.dataSetBig);

        //bubbleSequential.RunFromFile(constants.dataSetLargest);

        //await bubbleParallel.RunFromFileAsync(constants.dataSetLargest);

        //var heapSortSequential = new HeapSortSequential(sortHelper);   
        //var heapSortParallel = new HeapSortParallel(sortHelper);

        //heapSortSequential.RunFromFile(constants.dataSetMedium);

        //await heapSortParallel.RunFromFileAsync(constants.dataSetMedium);

        //heapSortSequential.RunFromFile(constants.dataSetBig);

        //await heapSortParallel.RunFromFileAsync(constants.dataSetBig);

        //heapSortSequential.RunFromFile(constants.dataSetLargest);

        //await heapSortParallel.RunFromFileAsync(constants.dataSetLargest);
    }
}