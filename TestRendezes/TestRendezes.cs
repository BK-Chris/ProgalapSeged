namespace TestRendezes
{
    // Quick Sort Test Cases
    [TestClass]
    public sealed class QuickSortTests
    {
        [TestMethod]
        public void QuickSortEmptyList()
        {
            int[] array = [];
            Rendezes.Rendezes.QuickSort(array, 0, array.Length - 1);
            Assert.AreEqual(0, array.Length);
        }

        [TestMethod]
        public void QuickSortSingleElementList()
        {
            int[] array = [5];
            Rendezes.Rendezes.QuickSort(array, 0, array.Length - 1);
            Assert.AreEqual(1, array.Length);
            Assert.AreEqual(5, array[0]);
        }

        [TestMethod]
        public void QuickSortSortedList()
        {
            int[] array = [1, 2, 3, 4, 5];
            Rendezes.Rendezes.QuickSort(array, 0, array.Length - 1);
            CollectionAssert.AreEqual(new int[] { 1, 2, 3, 4, 5 }, array);
        }

        [TestMethod]
        public void QuickSortReverseSortedList()
        {
            int[] array = [5, 4, 3, 2, 1];
            Rendezes.Rendezes.QuickSort(array, 0, array.Length - 1);
            CollectionAssert.AreEqual(new int[] { 1, 2, 3, 4, 5 }, array);
        }

        [TestMethod]
        public void QuickSortListWithDuplicates()
        {
            int[] array = [3, 1, 4, 4, 2, 5, 3];
            Rendezes.Rendezes.QuickSort(array, 0, array.Length - 1);
            CollectionAssert.AreEqual(new int[] { 1, 2, 3, 3, 4, 4, 5 }, array);
        }

        [TestMethod]
        public void QuickSortListWithNegativeNumbers()
        {
            int[] array = [-3, 1, -1, 2, 0];
            Rendezes.Rendezes.QuickSort(array, 0, array.Length - 1);
            CollectionAssert.AreEqual(new int[] { -3, -1, 0, 1, 2 }, array);
        }

        [TestMethod]
        public void QuickSortListWithAllIdenticalElements()
        {
            int[] array = [7, 7, 7, 7, 7];
            Rendezes.Rendezes.QuickSort(array, 0, array.Length - 1);
            CollectionAssert.AreEqual(new int[] { 7, 7, 7, 7, 7 }, array);
        }

        [TestMethod]
        public void QuickSortLargeList()
        {
            int[] array = Enumerable.Range(1, 1000).Reverse().ToArray();
            Rendezes.Rendezes.QuickSort(array, 0, array.Length - 1);
            CollectionAssert.AreEqual(Enumerable.Range(1, 1000).ToArray(), array);
        }

    }
}