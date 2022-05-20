using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventoryItem : UIItem
{
	[SerializeField] private Image _imageIcon;
	[SerializeField] private Text _textAmount;

	public IInventoryItem Item { get; private set; }

	public void Refresh(IInventorySlot slot)
	{
		if(slot.IsEmpty)
		{
			Cleanup();
			return;
		}

		SetItem(slot.Item);
	}

	private void Cleanup()
	{
		_imageIcon.gameObject.SetActive(false);
		_textAmount.gameObject.SetActive(false);
	}

	private void SetItem(IInventoryItem item)
	{
		Item = item;

		_imageIcon.gameObject.SetActive(true);
		_imageIcon.sprite = Item.Info.SpriteIcon;

		if(Item.State.Amount > 1)
		{
			_textAmount.gameObject.SetActive(true);
			_textAmount.text = $"x{Item.State.Amount}";
		}

	}
}
