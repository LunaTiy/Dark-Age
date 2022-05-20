using UnityEngine;

public interface IInventoryItemInfo
{
	string Id { get; }
	string Title { get; }
	string Description { get; }
	int MaxItemsInSlot { get; }
	Sprite SpriteIcon { get; }
}
