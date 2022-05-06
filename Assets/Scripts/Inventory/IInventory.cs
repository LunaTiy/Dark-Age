using System;

public interface IInventory
{
	event Action<object, IInventoryItem, int> OnInventoryItemAdded;
	event Action<object, Type, int> OnInventoryItemRemoved;

	int Capacity { get; set; }
	bool IsFull { get; }

	IInventoryItem GetItem(Type itemType);
	IInventoryItem[] GetAllItems();
	IInventoryItem[] GetAllItems(Type itemType);
	IInventoryItem[] GetEquippedItems();
	int GetItemAmount(Type itemType);

	bool TryToAdd(object sender, IInventoryItem item);
	void Remove(object sender, Type itemType, int amount = 1);
	bool HasItem(Type itemType, out IInventoryItem item);
}
