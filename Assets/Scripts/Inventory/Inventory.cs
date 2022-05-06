using System;
using System.Collections.Generic;
using System.Linq;

class Inventory : IInventory
{
	public event Action<object, IInventoryItem, int> InventoryItemAdded;
	public event Action<object, Type, int> InventoryItemRemoved;


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
			if (!slot.IsEmpty && slot.Item.IsEquipped)
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
				slot.Item.Amount -= amountToRemove;

				if (slot.Amount <= 0)
					slot.Clear();

				InventoryItemRemoved?.Invoke(sender, itemType, amountToRemove);

				break;
			}

			InventoryItemRemoved?.Invoke(sender, itemType, slot.Amount);

			amountToRemove -= slot.Amount;
			slot.Clear();
		}
	}

	private bool TryAddToSlot(object sender, IInventorySlot slot, IInventoryItem item)
	{
		bool isFits = slot.Amount + item.Amount <= item.MaxItemsInSlots;

		int amountToAdd = isFits ? item.Amount : item.MaxItemsInSlots - slot.Amount;
		int amountLeft = item.Amount - amountToAdd;

		if (slot.IsEmpty)
		{
			var clonedItem = item.Clone();
			clonedItem.Amount = amountToAdd;

			slot.SetItem(clonedItem);
		}
		else
		{
			slot.Item.Amount += amountToAdd;
		}

		InventoryItemAdded?.Invoke(sender, item, amountToAdd);

		if (amountLeft <= 0)
			return true;

		item.Amount = amountLeft;

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
}
