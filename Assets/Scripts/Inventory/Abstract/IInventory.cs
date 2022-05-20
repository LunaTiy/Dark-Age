using System;

public interface IInventory
{
	int Capacity { get; }
	bool IsFull { get; }

	IInventoryItem GetItem(Type itemType);
	IInventoryItem[] GetAllItems();
	IInventoryItem[] GetAllItems(Type itemType);
	int GetItemAmount(Type itemType);

	bool TryToAdd(IInventoryItem item);
	void Remove(Type itemType, int amount = 1);
	bool HasItem(Type itemType, out IInventoryItem item);
}
