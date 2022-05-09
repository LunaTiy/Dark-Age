using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UISlot : MonoBehaviour, IDropHandler
{
	public virtual void OnDrop(PointerEventData eventData)
	{
		Transform draggableItem = eventData.pointerDrag.transform;
		draggableItem.SetParent(transform);
		draggableItem.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
	}
}
