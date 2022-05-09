using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIInventorySlot : UISlot
{
	[SerializeField] private UIInventoryItem _uiInventoryItem;
	private UIInventory _uiInventory;
	private Inventory _inventory;

	public IInventorySlot Slot { get; private set; }

	private void Awake()
	{
		_uiInventory = GetComponentInParent<UIInventory>();
		_inventory = _uiInventory.Inventory;
	}

	public override void OnDrop(PointerEventData eventData)
	{
		UIInventoryItem sourceItemUI = eventData.pointerDrag.GetComponent<UIInventoryItem>();
		UIInventorySlot sourceSlotUI = sourceItemUI.GetComponentInParent<UIInventorySlot>();
		IInventorySlot sourceSlot = sourceSlotUI.Slot;

		_inventory.TransitBetweenSlots(this, sourceSlot, Slot);

		Refresh();
		sourceSlotUI.Refresh();
	}

	public void Refresh()
	{
		if (Slot != null)
			_uiInventoryItem.Refresh(Slot);
	}
}
