using UnityEngine;
using UnityEngine.EventSystems;

public class UIInventorySlot : UISlot
{
	[SerializeField] private UIInventoryItem _item;
	
	private UIInventory _uiInventory;
	private Inventory _inventory;

    public IInventorySlot Slot { get; private set; }

	private void Start()
	{
		_uiInventory = GetComponentInParent<UIInventory>();
		_inventory = _uiInventory.Inventory;
	}

	public void SetSlot(IInventorySlot slot)
	{
		Slot = slot;
	}

	public void RefreshSlot()
	{
		_item.Refresh(Slot);
	}

	public override void OnDrop(PointerEventData eventData)
	{
		UIInventoryItem draggedUIItem = eventData.pointerDrag.GetComponent<UIInventoryItem>();
		IInventorySlot fromSlot = draggedUIItem.GetComponentInParent<UIInventorySlot>().Slot;

		_inventory.TransitBetweenSlots(fromSlot, Slot);
	}
}
