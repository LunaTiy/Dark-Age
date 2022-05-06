using System;

public interface IInventoryItem
{
	bool IsEquipped { get; set; }
	Type Type { get; }
	int MaxItemsInSlots { get; }
	int Amount { get; set; }

	IInventoryItem Clone();
}
