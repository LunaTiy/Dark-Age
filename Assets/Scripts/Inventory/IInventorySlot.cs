using System;

public interface IInventorySlot
{
    IInventoryItem Item { get; }
    Type ItemType { get; }
    int Amount { get; }
    int Capacity { get; }

    bool IsEmpty { get; }
    bool IsFull { get; }

    void SetItem(IInventoryItem item);
    void Clear();
}
