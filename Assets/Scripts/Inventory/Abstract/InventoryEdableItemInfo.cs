using UnityEngine;

[CreateAssetMenu(fileName = "InventoryEdableItemInfo", menuName = "Gameplay/Items/Create Edable Item Info")]
public class InventoryEdableItemInfo : ScriptableObject, IInventoryItemInfo
{
	[SerializeField] private string _id;
	[SerializeField] private string _title;
	[SerializeField] private string _description;
	[SerializeField] private int _maxItemsInSlot;
	[SerializeField] private int _value;
	[SerializeField] private Sprite _spriteIcon;

	public string Id => _id;
	public string Title => _title;
	public string Description => _description;
	public int MaxItemsInSlot => _maxItemsInSlot;
	public int Value => _value;
	public Sprite SpriteIcon => _spriteIcon;
}
