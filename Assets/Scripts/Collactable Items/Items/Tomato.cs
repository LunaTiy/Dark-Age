using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tomato : IInventoryItem
{
	public Tomato(IInventoryItemInfo info, IInventoryItemState state)
	{
		Info = info;
		State = state;
	}

	public IInventoryItemInfo Info { get; }

	public IInventoryItemState State { get; }

	public Type Type => GetType();

	public IInventoryItem Clone()
	{
		Tomato newApple = new Tomato(Info, State);
		newApple.State.IsEquipped = false;
		return newApple;
	}
}
