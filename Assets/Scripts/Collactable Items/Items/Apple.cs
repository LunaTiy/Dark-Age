using System;

public class Apple : IInventoryItem
{
	public event Action OnItemUsed;

	public Apple(IInventoryItemInfo info)
	{
		Info = info;
		State = new InventoryItemState();
	}

	public IInventoryItemInfo Info { get; }

	public IInventoryItemState State { get; }

	public IInventoryItem Clone()
	{
		Apple newApple = new Apple(Info);
		newApple.State.Amount = State.Amount;
		return newApple;
	}

	public void Use(Character character)
	{
		character.Characteristics.Health += Info.Value;
		OnItemUsed?.Invoke();
	}
}
