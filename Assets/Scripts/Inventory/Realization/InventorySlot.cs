using System;

public class InventorySlot : IInventorySlot
{
	public InventorySlot()
	{
		Item = null;
	}

	public IInventoryItem Item { get; private set; }
	public Type ItemType => IsEmpty ? null : Item.GetType();
	public int Amount => IsEmpty ? 0 : Item.State.Amount;
	public int Capacity => IsEmpty ? 0 : Item.Info.MaxItemsInSlot;
	public bool IsEmpty => Item == null;
	public bool IsFull
	{
		get
		{
			if (IsEmpty) return false;
			return Capacity - Amount <= 0;
		}
	}

	public void Clear()
	{
		if (IsEmpty) return;

		Item = null;
	}

	public void SetItem(IInventoryItem item)
	{
		Item = item;
	}
}
