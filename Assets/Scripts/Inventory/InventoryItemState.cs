using System;

[Serializable]
class InventoryItemState : IInventoryItemState
{
	private int _amount;
	private bool _isEquipped;

	public InventoryItemState()
	{
		_amount = 0;
		_isEquipped = false;
	}

	public int Amount { get => _amount; set => _amount = value; }
	public bool IsEquipped { get => _isEquipped; set => _isEquipped = value; }
}
