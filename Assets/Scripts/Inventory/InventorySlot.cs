using System;

class InventorySlot : IInventorySlot
{
	public IInventoryItem Item { get; private set; }

	public Type ItemType => IsEmpty ? null : Item.Type;

	public int Amount => IsEmpty ? 0 : Item.State.Amount;

	public int Capacity { get; private set; }

	public bool IsEmpty => Item == null;

	public bool IsFull => !IsEmpty && Amount == Capacity;

	public void Clear()
	{
		if (IsEmpty)
			return;

		Capacity = 0;
		Item.State.Amount = 0;
		Item = null;
	}

	public void SetItem(IInventoryItem item)
	{
		if(!IsEmpty || item.State.Amount <= 0)
			return;

		Item = item;
		Capacity = item.Info.MaxItemInSlots;
	}
}
