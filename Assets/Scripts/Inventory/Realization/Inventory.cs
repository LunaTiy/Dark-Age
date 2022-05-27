using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : IInventory
{
	public event Action OnInventoryStateChanged;

	private IInventorySlot[] _slots;

	public Inventory(int capacity)
	{
		_slots = new InventorySlot[capacity];

		for (int i = 0; i < _slots.Length; i++)
		{
			_slots[i] = new InventorySlot();
		}
	}

	public int Capacity => _slots.Length;
	public bool IsFull => _slots.All(slot => slot.IsFull);

	public IInventoryItem GetItem(Type itemType)
	{
		return _slots.ToList().Find(slot => slot.ItemType == itemType).Item;
	}

	public bool HasItem(Type itemType, out IInventoryItem item)
	{
		item = GetItem(itemType);
		return item != null;
	}

	public int GetItemAmount(Type itemType)
	{
		int amount = 0;
		
		foreach(IInventorySlot slot in _slots)
			if (!slot.IsEmpty && slot.ItemType == itemType) amount += slot.Amount;

		return amount;
	}

	public IInventoryItem[] GetAllItems()
	{
		List<IInventoryItem> items = new List<IInventoryItem>();

		foreach(IInventorySlot slot in _slots)
			if (!slot.IsEmpty) items.Add(slot.Item);

		return items.ToArray();
	}

	public IInventoryItem[] GetAllItems(Type itemType)
	{
		List<IInventoryItem> allItems = GetAllItems().ToList();

		return allItems.FindAll(item => item.GetType() == itemType).ToArray();
	}

	public void Remove(Type itemType, int amount = 1)
	{
		IInventorySlot[] slots = GetAllSlots(itemType);

		if (slots.Length == 0) return;

		for(int i = slots.Length - 1; i >= 0; i--)
		{
			IInventorySlot slot = slots[i];

			if(slot.Amount >= amount)
			{
				slot.Item.State.Amount -= amount;

				if (slot.Amount == 0)
					slot.Clear();

				break;
			}

			amount -= slot.Amount;
			slot.Clear();
		}

		OnInventoryStateChanged?.Invoke();
	}

	public bool TryToAdd(IInventoryItem item)
	{
		if (IsFull) return false;

		IInventorySlot[] slotsWithSameItem = _slots.ToList().FindAll(slot => !slot.IsEmpty && !slot.IsFull && slot.ItemType == item.GetType()).ToArray();

		for(int i = 0; i < slotsWithSameItem.Length; i++)
		{
			var slot = slotsWithSameItem[i];
			int freeSpace = slot.Capacity - slot.Amount;

			if (freeSpace >= item.State.Amount)
			{
				slot.Item.State.Amount += freeSpace;
				OnInventoryStateChanged?.Invoke();

				return true;
			}
			else
			{
				slot.Item.State.Amount += freeSpace;
				item.State.Amount -= freeSpace;
			}
		}

		IInventorySlot[] emptySlots = _slots.ToList().FindAll(slot => slot.IsEmpty).ToArray();

		for (int i = 0; i < emptySlots.Length; i++)
		{
			var slot = emptySlots[i];

			if (item.Info.MaxItemsInSlot >= item.State.Amount)
			{
				slot.SetItem(item);
				item.OnItemUsed += UsedItem;
				OnInventoryStateChanged?.Invoke();

				return true;
			}
			else
			{
				var newItem = item.Clone();
				newItem.State.Amount = item.Info.MaxItemsInSlot;

				slot.SetItem(newItem);
				item.OnItemUsed += UsedItem;
				item.State.Amount -= item.Info.MaxItemsInSlot;
			}
		}

		OnInventoryStateChanged?.Invoke();

		return false;
	}

	public IInventorySlot[] GetAllSlots()
	{
		return _slots;
	}

	public IInventorySlot[] GetAllSlots(Type itemType)
	{
		return _slots.ToList().FindAll(slot => !slot.IsEmpty && slot.ItemType == itemType).ToArray();
	}

	public void TransitBetweenSlots(IInventorySlot fromSlot, IInventorySlot toSlot)
	{
		if (fromSlot.IsEmpty) return;

		if (fromSlot == toSlot) return;

		if (toSlot.IsEmpty)
		{
			toSlot.SetItem(fromSlot.Item.Clone());
			fromSlot.Clear();

			OnInventoryStateChanged?.Invoke();
			return;
		}

		if (fromSlot.ItemType != toSlot.ItemType)
		{
			var fromItem = fromSlot.Item.Clone();
			var toItem = toSlot.Item.Clone();

			fromSlot.Clear();
			toSlot.Clear();

			fromSlot.SetItem(toItem);
			toSlot.SetItem(fromItem);

			OnInventoryStateChanged?.Invoke();
			return;
		}

		if(fromSlot.ItemType == toSlot.ItemType)
		{
			int freeSpace = toSlot.Capacity - toSlot.Amount;

			if (freeSpace == 0) return;

			if(freeSpace >= fromSlot.Amount)
			{
				toSlot.Item.State.Amount += fromSlot.Amount;
				fromSlot.Clear();
			}
			else
			{
				toSlot.Item.State.Amount += freeSpace;
				fromSlot.Item.State.Amount -= freeSpace;
			}

			OnInventoryStateChanged?.Invoke();
			return;
		}
	}

	private void UsedItem()
	{
		OnInventoryStateChanged?.Invoke();
	}
}
