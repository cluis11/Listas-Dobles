using Listas_Dobles;
Console.WriteLine();

DoubleList listA = new DoubleList();
listA.Insert(1);
listA.Insert(0);
listA.Insert(30);
listA.Insert(50);
listA.Insert(2);

listA.PrintList();

Console.WriteLine();
DoubleList listB = DoubleList.Invert(listA);
listB.PrintList();
Console.WriteLine();
listA.PrintList();

for (int i = 0; i < 5; i++) 
{
    int x = listA.DeleteFirst();
    //Console.WriteLine(x);
}