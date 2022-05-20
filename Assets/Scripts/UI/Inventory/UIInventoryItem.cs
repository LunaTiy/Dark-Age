using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventoryItem : UIItem
{
    [SerializeField] private Image _imageIcon;
    [SerializeField] private Text _textAmount;

    public void Refresh(IInventorySlot slot)
	{
		if (slot.IsEmpty)
		{
			_imageIcon.enabled = false;
			_textAmount.enabled = false;

			return;
		}

		var item = slot.Item;

        _imageIcon.sprite = item.Info.SpriteIcon;
		_imageIcon.enabled = true;

		if(item.State.Amount > 1)
		{
			_textAmount.text = $"x{item.State.Amount}";
			_textAmount.enabled = true;
		}
		else
		{
			_textAmount.enabled = false;
		}
	}
}
