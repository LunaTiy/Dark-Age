using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
	[SerializeField] private int _amountCell = 12;
	[SerializeField] InventoryItemInfo _appleInfo;
	[SerializeField] InventoryItemInfo _tomatoInfo;

	private InventoryTester _inventoryTester;
	public Inventory Inventory => _inventoryTester.Inventory;

	private void Awake()
	{
		UIInventorySlot[] uiSlots = GetComponentsInChildren<UIInventorySlot>();
		_inventoryTester = new InventoryTester(_appleInfo, _tomatoInfo, uiSlots);
		_inventoryTester.FillSlots();
	}
}
