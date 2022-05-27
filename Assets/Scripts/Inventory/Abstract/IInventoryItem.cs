using System;

public interface IInventoryItem
{
	public event Action OnItemUsed;
	IInventoryItemInfo Info { get; }
	IInventoryItemState State { get; }

	IInventoryItem Clone();
	void Use(Character character);
}
