using System;

public class Lemon : IInventoryItem
{
	public event Action OnItemUsed;

	public Lemon(IInventoryItemInfo info)
	{
		Info = info;
		State = new InventoryItemState();
	}

	public IInventoryItemInfo Info { get; }

	public IInventoryItemState State { get; }

	public IInventoryItem Clone()
	{
		Lemon newTomato = new Lemon(Info);
		newTomato.State.Amount = State.Amount;
		return newTomato;
	}

	public void Use(Character character)
	{
		character.Characteristics.Health += Info.Value;

		OnItemUsed?.Invoke();
	}
}
