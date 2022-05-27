using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIInventoryItem : UIItem, IPointerDownHandler
{
    [SerializeField] private Image _imageIcon;
    [SerializeField] private Text _textAmount;
	[SerializeField] private float _timeBetweenClick = 0.2f;

	private UIInventorySlot _uiSlot;
	private IInventorySlot _slot;

	private IInventoryItem _item;
	private Character _character;

	private bool _isClicked;

	private void Start()
	{
		_character = GetComponentInParent<UIInventory>().Character;

		_uiSlot = GetComponentInParent<UIInventorySlot>();
		_slot = _uiSlot.Slot;
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		if (_isClicked)
		{
			_item.State.Amount--;
			_item.Use(_character);

			if (_item.State.Amount <= 0)
			{
				_slot.Clear();
				Refresh(_uiSlot.Slot);
			}

			_isClicked = false;
		}

		_isClicked = true;
		Invoke("ClearClick", _timeBetweenClick);
	}

	public void Refresh(IInventorySlot slot)
	{
		if (slot.IsEmpty)
		{
			_imageIcon.enabled = false;
			_textAmount.enabled = false;

			_item = null;

			return;
		}

		_item = slot.Item;

        _imageIcon.sprite = _item.Info.SpriteIcon;
		_imageIcon.enabled = true;

		if(_item.State.Amount > 1)
		{
			_textAmount.text = $"x{_item.State.Amount}";
			_textAmount.enabled = true;
		}
		else
		{
			_textAmount.enabled = false;
		}
	}

	private void ClearClick()
	{
		CancelInvoke("ClearClick");
		_isClicked = false;
	}
}
