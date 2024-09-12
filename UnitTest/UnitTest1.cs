using Listas_Dobles;
namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMergeSortedList()
        {
            DoubleList listA = new DoubleList();
            DoubleList listB = new DoubleList();
            listA = new DoubleList();
            listA.InsertInOrder(25);
            listA.InsertInOrder(6);
            listA.InsertInOrder(10);
            listA.InsertInOrder(0);
            listA.InsertInOrder(2);

            listB.InsertInOrder(7);
            listB.InsertInOrder(3);
            listB.InsertInOrder(11);
            listB.InsertInOrder(4);
            listB.InsertInOrder(50);

            DoubleList listR = new DoubleList();
            listR.InsertInOrder(25);
            listR.InsertInOrder(6);
            listR.InsertInOrder(10);
            listR.InsertInOrder(0);
            listR.InsertInOrder(2);
            listR.InsertInOrder(7);
            listR.InsertInOrder(3);
            listR.InsertInOrder(11);
            listR.InsertInOrder(4);
            listR.InsertInOrder(50);

            DoubleList.MergeSorted(listA, listB, SortDirection.Ascending);

            Assert.AreEqual(listA, listA);
        }

        [TestMethod]
        public void MergeSorted_ListAIsNull()
        {
            // Arrange
            DoubleList listA = null;
            var listB = new DoubleList(); // Suponemos que esto es un objeto válido

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() =>
                DoubleList.MergeSorted(listA, listB, SortDirection.Ascending)
            );
        }

        [TestMethod]
        public void MergeSorted_ListBIsNull()
        {
            // Arrange
            DoubleList listA = new DoubleList();
            DoubleList listB = null; // Suponemos que esto es un objeto válido

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() =>
                DoubleList.MergeSorted(listA, listB, SortDirection.Ascending)
            );
        }


        [TestMethod]
        public void Middle()
        {
            DoubleList listA = new DoubleList();
            DoubleList listB = new DoubleList();
            DoubleList listC = new DoubleList();
            DoubleList listD = new DoubleList();
            listA.InsertInOrder(1);
            listB.InsertInOrder(1);
            listB.InsertInOrder(2);
            listC.InsertInOrder(0);
            listC.InsertInOrder(1);
            listC.InsertInOrder(2);
            listD.InsertInOrder(0);
            listD.InsertInOrder(1);
            listD.InsertInOrder(3);
            listD.InsertInOrder(2);

            Assert.AreEqual(1, listA.GetMiddle());
            Assert.AreEqual(2, listB.GetMiddle());
            Assert.AreEqual(1, listC.GetMiddle());
            Assert.AreEqual(2, listD.GetMiddle());
        }

    }
}