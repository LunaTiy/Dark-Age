using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIItem : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
	private RectTransform _rectTransform;
	private Canvas _canvas;
	private CanvasGroup _canvasGroup;

	private void Start()
	{
		_rectTransform = GetComponent<RectTransform>();
		_canvas = GetComponentInParent<Canvas>();
		_canvasGroup = GetComponent<CanvasGroup>();
	}

	public void OnDrag(PointerEventData eventData)
	{
		_rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		_canvasGroup.blocksRaycasts = false;
		Transform slot = _rectTransform.parent;
		slot.SetAsLastSibling();
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		_rectTransform.anchoredPosition = Vector2.zero;
		_canvasGroup.blocksRaycasts = true;
	}
}
