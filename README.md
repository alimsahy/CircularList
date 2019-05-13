# CircularList
Simple circular list implementation using C#

[alt text](https://static.javatpoint.com/ds/images/circular-singly-linked-list.png)

# Usage

```csharp
CircularList myList = new CircularList();

myList.Insert(25); // Index: 0
myList.Insert(42); // Index: 1
myList.Insert(12); // Index: 2
myList.Insert(10); // Index: 3

myList.RemoveAt(2); // Removes 12

int beforeMinimumValue = myList.GetPrevious(myList.Min()).Value;
int beforeMinimumIndex = myList.GetPrevious(myList.Min()).Index;

int max = myList.Max().Value;
int min = myList.Min().Value;
int sum = myList.Sum();
int avg = myList.Avg();
