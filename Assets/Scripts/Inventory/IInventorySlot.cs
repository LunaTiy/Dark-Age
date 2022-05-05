using System;

public interface IInventorySlot
{
    IInventoryItem item { get; set; }
    Type ItemType { get; }
    int Amount { get; }
    int Capacity { get; }

    bool IsEmpty { get; }
    bool IsFull { get; }

    bool TryToAddItem(IInventoryItem item);
    bool Clear();
}
