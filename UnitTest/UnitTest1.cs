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
            for (int i = 0; i < 10; i++) 
            {
                Assert.AreEqual(listR.DeleteFirst(), listA.DeleteFirst());
            }

            listA = new DoubleList();
            listB = new DoubleList();
            listA.InsertInOrder(10);
            listA.InsertInOrder(15);

            listB.InsertInOrder(9);
            listB.InsertInOrder(40);
            listB.InsertInOrder(50);

            listR = new DoubleList();
            listR.InsertInOrder(9);
            listR.InsertInOrder(10);
            listR.InsertInOrder(15);
            listR.InsertInOrder(40);
            listR.InsertInOrder(50);

            DoubleList.MergeSorted(listA, listB, SortDirection.Descending);
            for (int i = 0; i < 5; i++)
            {
                Assert.AreEqual(listR.DeleteLast(), listA.DeleteFirst());
            }

            listA = new DoubleList();
            listB = new DoubleList();

            listB.InsertInOrder(9);
            listB.InsertInOrder(40);
            listB.InsertInOrder(50);

            listR = new DoubleList();
            listR.InsertInOrder(9);
            listR.InsertInOrder(40);
            listR.InsertInOrder(50);

            DoubleList.MergeSorted(listA, listB, SortDirection.Descending);
            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(listR.DeleteLast(), listA.DeleteFirst());
            }

            listA = new DoubleList();
            listB = new DoubleList();

            listA.InsertInOrder(15);
            listA.InsertInOrder(10);

            listR = new DoubleList();
            listR.InsertInOrder(10);
            listR.InsertInOrder(15);

            DoubleList.MergeSorted(listA, listB, SortDirection.Ascending);
            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(listR.DeleteFirst(), listA.DeleteFirst());
            }
        }

        [TestMethod]
        public void TestMergeSorted_ListAIsNull()
        {
            DoubleList listA = null;
            var listB = new DoubleList(); 

            Assert.ThrowsException<ArgumentNullException>(() =>
                DoubleList.MergeSorted(listA, listB, SortDirection.Ascending)
            );
        }

        [TestMethod]
        public void TestMergeSorted_ListBIsNull()
        {
            DoubleList listA = new DoubleList();
            DoubleList listB = null; 

            Assert.ThrowsException<ArgumentNullException>(() =>
                DoubleList.MergeSorted(listA, listB, SortDirection.Ascending)
            );
        }

        [TestMethod]
        public void TestInvertir()
        {
            DoubleList listA = new DoubleList();
            listA.Insert(1);
            listA.Insert(0);
            listA.Insert(30);
            listA.Insert(50);
            listA.Insert(2);

            DoubleList listB = new DoubleList();
            listB.Insert(1);
            listB.Insert(0);
            listB.Insert(30);
            listB.Insert(50);
            listB.Insert(2);

            DoubleList.Invert(listA);

            for (int i = 0; i < 5; i++)
            {
                Assert.AreEqual(listA.DeleteFirst(), listB.DeleteLast());
            }
            DoubleList listC = new DoubleList();
            listC.Insert(2);
            Assert.AreEqual(2, listC.DeleteFirst());
        }

        [TestMethod]
        public void TestInvertirNull()
        {
            DoubleList listA = new DoubleList();
            Assert.ThrowsException<InvalidOperationException>(() =>
                DoubleList.Invert(listA)
            );

            listA = null;
            Assert.ThrowsException<ArgumentNullException>(() =>
                DoubleList.Invert(listA)
            );
        }


        [TestMethod]
        public void TestMiddleNull()
        {
            // Arrange
            DoubleList listA = null;

            // Act & Assert
            Assert.ThrowsException<NullReferenceException>(() =>
                listA.GetMiddle()
            );

            listA = new DoubleList();
            Assert.ThrowsException<NullReferenceException>(() =>
                listA.GetMiddle()
            );
        }

        [TestMethod]
        public void TestMiddle()
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