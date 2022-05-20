using UnityEngine;

[CreateAssetMenu(fileName = "InventoryItemInfo", menuName = "Gameplay/Items/Create Item Info")]
public class InventoryItemInfo : ScriptableObject, IInventoryItemInfo
{
	[SerializeField] private string _id;
	[SerializeField] private string _title;
	[SerializeField] private string _description;
	[SerializeField] private int _maxItemsInSlot;
	[SerializeField] private Sprite _spriteIcon;

	public string Id => _id;
	public string Title => _title;
	public string Description => _description;
	public int MaxItemsInSlot => _maxItemsInSlot;
	public Sprite SpriteIcon => _spriteIcon;
}
