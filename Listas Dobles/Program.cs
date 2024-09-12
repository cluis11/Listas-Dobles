using Listas_Dobles;
Console.WriteLine();

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

listA.PrintList();
Console.WriteLine();
listR.PrintList();