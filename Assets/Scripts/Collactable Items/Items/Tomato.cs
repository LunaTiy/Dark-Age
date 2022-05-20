using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tomato : IInventoryItem
{
	public Tomato(IInventoryItemInfo info)
	{
		Info = info;
		State = new InventoryItemState();
	}

	public IInventoryItemInfo Info { get; }

	public IInventoryItemState State { get; }

	public Type Type => GetType();

	public IInventoryItem Clone()
	{
		Tomato newTomato = new Tomato(Info);
		newTomato.State.Amount = State.Amount;
		return newTomato;
	}
}
