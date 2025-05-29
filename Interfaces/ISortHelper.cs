namespace SortingPerformanceSimulator.Interfaces
{
    public interface ISortHelper
    {
        int[] ReadDataFromFile(string filePath);
        void PrintArray(int[] array, string title, string outputDirectory);
        void AppendSortResult(string algorithmName, int[] array, double executionTime, string outputFilePath);
    }
}
