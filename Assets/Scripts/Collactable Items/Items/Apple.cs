using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : IInventoryItem
{
	public Apple(IInventoryItemInfo info)
	{
		Info = info;
		State = new InventoryItemState();
	}

	public IInventoryItemInfo Info { get; }

	public IInventoryItemState State { get; }

	public Type Type => GetType();

	public IInventoryItem Clone()
	{
		Apple newApple = new Apple(Info);
		newApple.State.Amount = State.Amount;
		return newApple;
	}
}
