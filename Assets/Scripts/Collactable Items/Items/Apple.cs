using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : IInventoryItem
{
	public Apple(IInventoryItemInfo info, IInventoryItemState state)
	{
		Info = info;
		State = state;
	}

	public IInventoryItemInfo Info { get; }

	public IInventoryItemState State { get; }

	public Type Type => GetType();

	public IInventoryItem Clone()
	{
		Apple newApple = new Apple(Info, State);
		newApple.State.IsEquipped = false;
		return newApple;
	}
}
