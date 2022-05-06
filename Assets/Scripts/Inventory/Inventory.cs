using System;
using System.Collections.Generic;
using System.Linq;

class Inventory : IInventory
{
	public event Action<object, IInventoryItem, int> OnInventoryItemAdded;
	public event Action<object, Type, int> OnInventoryItemRemoved;
	public event Action<object> OnInventoryStateChanged;


	private List<IInventorySlot> _slots;

	public Inventory(int capacity)
	{
		Capacity = capacity;

		_slots = new List<IInventorySlot>(Capacity);
		
		for (int i = 0; i < Capacity; i++)
			_slots.Add(new InventorySlot());
	}

	public int Capacity { get; set; }

	public bool IsFull => !_slots.Any(slot => !slot.IsFull);

	public IInventoryItem[] GetAllItems()
	{
		List<IInventoryItem> allItems = new List<IInventoryItem>();
		
		foreach(IInventorySlot slot in _slots)
		{
			if (!slot.IsEmpty)
				allItems.Add(slot.Item);
		}

		return allItems.ToArray();
	}

	public IInventoryItem[] GetAllItems(Type itemType)
	{
		List<IInventoryItem> allItemsOfType = new List<IInventoryItem>();

		foreach(IInventorySlot slot in _slots)
			if (!slot.IsEmpty && slot.ItemType == itemType)
				allItemsOfType.Add(slot.Item);

		return allItemsOfType.ToArray();
	}

	public IInventoryItem[] GetEquippedItems()
	{
		List<IInventoryItem> equippedItems = new List<IInventoryItem>();

		foreach(IInventorySlot slot in _slots)
		{
			if (!slot.IsEmpty && slot.Item.State.IsEquipped)
				equippedItems.Add(slot.Item);
		}

		return equippedItems.ToArray();
	}

	public IInventoryItem GetItem(Type itemType)
	{
		return _slots.Find(slot => slot.ItemType == itemType).Item;
	}

	public int GetItemAmount(Type itemType)
	{
		return _slots.FindAll(slot => !slot.IsEmpty && slot.ItemType == itemType).Sum(slot => slot.Amount);
	}

	public bool HasItem(Type itemType, out IInventoryItem item)
	{
		item = GetItem(itemType);
		return item != null;
	}

	public bool TryToAdd(object sender, IInventoryItem item)
	{
		IInventorySlot slotWithSameItem = _slots.Find(slot => !slot.IsEmpty && !slot.IsFull && slot.ItemType == item.Type);

		if (slotWithSameItem != null)
			return TryAddToSlot(sender, slotWithSameItem, item);

		IInventorySlot emptySlot = _slots.Find(slot => slot.IsEmpty);

		if (emptySlot != null)
			return TryAddToSlot(sender, emptySlot, item);

		return false;
	}

	public void Remove(object sender, Type itemType, int amount = 1)
	{
		IInventorySlot[] slotsWithItem = GetAllSlots(itemType);

		if (slotsWithItem.Length == 0)
			return;

		int amountToRemove = amount;

		for(int i = slotsWithItem.Length - 1; i >= 0; i--)
		{
			var slot = slotsWithItem[i];

			if(slot.Amount >= amountToRemove)
			{
				slot.Item.State.Amount -= amountToRemove;

				if (slot.Amount <= 0)
					slot.Clear();

				OnInventoryItemRemoved?.Invoke(sender, itemType, amountToRemove);
				OnInventoryStateChanged?.Invoke(sender);

				break;
			}

			OnInventoryItemRemoved?.Invoke(sender, itemType, slot.Amount);
			OnInventoryStateChanged?.Invoke(sender);

			amountToRemove -= slot.Amount;
			slot.Clear();
		}
	}

	private bool TryAddToSlot(object sender, IInventorySlot slot, IInventoryItem item)
	{
		bool isFits = slot.Amount + item.State.Amount <= item.Info.MaxItemInSlots;

		int amountToAdd = isFits ? item.State.Amount : item.Info.MaxItemInSlots - slot.Amount;
		int amountLeft = item.State.Amount - amountToAdd;

		if (slot.IsEmpty)
		{
			var clonedItem = item.Clone();
			clonedItem.State.Amount = amountToAdd;

			slot.SetItem(clonedItem);
		}
		else
		{
			slot.Item.State.Amount += amountToAdd;
		}

		OnInventoryItemAdded?.Invoke(sender, item, amountToAdd);
		OnInventoryStateChanged?.Invoke(sender);

		if (amountLeft <= 0)
			return true;

		item.State.Amount = amountLeft;

		return TryToAdd(sender, item);
	}

	public IInventorySlot[] GetAllSlots(Type itemType)
	{
		return _slots.FindAll(slot => !slot.IsEmpty && slot.ItemType == itemType).ToArray();
	}

	public IInventorySlot[] GetAllSlots()
	{
		return _slots.ToArray();
	}

	public void TransitBetweenSlots(object sender, IInventorySlot fromSlot, IInventorySlot toSlot)
	{
		if (fromSlot == null)
			return;

		if (toSlot.IsFull)
			return;

		if (!toSlot.IsEmpty && fromSlot.ItemType != toSlot.ItemType)
			return;

		bool isFits = fromSlot.Amount + toSlot.Amount <= fromSlot.Capacity;
		int amountToAdd = isFits ? fromSlot.Amount : fromSlot.Capacity - toSlot.Amount;
		int amountLeft = fromSlot.Amount - amountToAdd;

		if (toSlot.IsEmpty)
		{
			toSlot.SetItem(fromSlot.Item);
			fromSlot.Clear();

			OnInventoryStateChanged?.Invoke(sender);
			return;
		}

		toSlot.Item.State.Amount += amountToAdd;

		if (isFits)
			fromSlot.Clear();
		else
			fromSlot.Item.State.Amount = amountLeft;

		OnInventoryStateChanged?.Invoke(sender);
	}
}
