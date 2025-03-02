namespace TestKereses
{
    // Binary Search Test Cases
    [TestClass]
    public sealed class BinarySearchTests
    {
        [TestMethod]
        public void BinarySearchEmptyList()
        {
            List<int> ints = [];
            var result = Kereses.Kereses.BinarySearch(ints, 1);
            Assert.AreEqual(-1, result);
        }
        [TestMethod]
        public void BinarySearchItemNotInList()
        {
            List<int> ints = [1, 2, 3, 4, 5];
            var result = Kereses.Kereses.BinarySearch(ints, 6);
            Assert.AreEqual(-1, result);
        }
        [TestMethod]
        public void BinarySearchItemFoundInTheMiddle()
        {
            List<int> ints = [1, 2, 3, 4, 5];
            var result = Kereses.Kereses.BinarySearch(ints, 3);
            Assert.AreEqual(2, result);
        }
        [TestMethod]
        public void BinarySearchItemFoundInTheEnd()
        {
            List<int> ints = [1, 2, 3, 4, 5];
            var result = Kereses.Kereses.BinarySearch(ints, 5);
            Assert.AreEqual(4, result);
        }
        [TestMethod]
        public void BinarySearchItemFoundInTheBegining()
        {
            List<int> ints = [1, 2, 3, 4, 5];
            var result = Kereses.Kereses.BinarySearch(ints, 1);
            Assert.AreEqual(0, result);
        }
        [TestMethod]
        public void BinarySearchNonInteger()
        {
            List<char> chars = ['a', 'b', 'c', 'd', 'e'];
            var result = Kereses.Kereses.BinarySearch(chars, 'b');
            Assert.AreEqual(1, result);
        }
        // A bináris keresés nem garantálja az első indexet, több azonos elem esetén!
        [TestMethod]
        public void BinarySearchDuplicates()
        {
            List<int> ints = [1, 2, 2, 7, 9];
            var result = Kereses.Kereses.BinarySearch(ints, 2);
            Assert.AreEqual(2, result);
            Assert.AreNotEqual(1, result);
        }
    }
}
