using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InventoryItemInfo", menuName = "Gameplay/Items/Create ItemInfo")]
class InventoryItemInfo : ScriptableObject, IInventoryItemInfo
{
	[SerializeField] private string _id;
	[SerializeField] private string _title;
	[SerializeField] private string _description;
	[SerializeField] private int _maxItemInSlots;
	[SerializeField] private Sprite _spriteIcon;

	public string Id => _id;
	public string Title => _title;
	public string Description => _description;
	public int MaxItemInSlots => _maxItemInSlots;
	public Sprite SpriteIcon => _spriteIcon;
}
