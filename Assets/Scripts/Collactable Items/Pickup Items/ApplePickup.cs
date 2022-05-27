using UnityEngine;

public class ApplePickup : MonoBehaviour, IItemPickup
{
	[SerializeField] private InventoryItemInfo _info;
	public IInventoryItemInfo Info => _info;
	public IInventoryItem Item { get; private set; }

	private void Start()
	{
		Item = new Apple(Info);
		Item.State.Amount = Random.Range(1, 4);
	}

	private void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.TryGetComponent<Character>(out Character character))
		{
			if (character.Inventory.TryToAdd(Item))
				Destroy(gameObject);
		}
	}
}
