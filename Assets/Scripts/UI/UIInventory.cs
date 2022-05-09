using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
	[SerializeField] private int _amountCell = 12;
    public Inventory Inventory { get; private set; }

	private void Awake()
	{
		Inventory = new Inventory(_amountCell);
	}
}
