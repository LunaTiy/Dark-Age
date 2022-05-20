using System;

public interface IInventoryItem
{
	IInventoryItemInfo Info { get; }
	IInventoryItemState State { get; }

	IInventoryItem Clone();
}
