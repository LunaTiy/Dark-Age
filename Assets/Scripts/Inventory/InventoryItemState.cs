using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemState : IInventoryItemState
{
	public InventoryItemState()
	{
		Amount = 0;
		IsEquipped = false;
	}

	public int Amount { get; set; }
	public bool IsEquipped { get; set; }
}
