using UnityEngine;

public class LemonPickup : MonoBehaviour, IItemPickup
{
	[SerializeField] private InventoryItemInfo _info;
	public IInventoryItemInfo Info => _info;
	public IInventoryItem Item { get; private set; }

	private void Start()
	{
		Item = new Lemon(Info);
		Item.State.Amount = Random.Range(1, 3);
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.TryGetComponent<Character>(out Character character))
		{
			if (character.Inventory.TryToAdd(Item))
				Destroy(gameObject);
		}
	}
}
