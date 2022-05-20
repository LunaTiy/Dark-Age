using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Basket : MonoBehaviour, IDropHandler
{
	public void OnDrop(PointerEventData eventData)
	{
		UIInventoryItem item = eventData.pointerDrag.GetComponent<UIInventoryItem>();
		UIInventorySlot slotUI = item.GetComponentInParent<UIInventorySlot>();
		IInventorySlot slot = slotUI.Slot;

		slot.Clear();
		slotUI.RefreshSlot();
	}
}
