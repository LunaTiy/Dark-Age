using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
	[SerializeField] private Character _target;
	[SerializeField] private GameObject _prefabSlot;

	private UIInventorySlot[] _uiSlots;
	private GridLayoutGroup _grid;

	public Inventory Inventory => _target.Inventory;

	private void Awake()
	{
		_grid = GetComponent<GridLayoutGroup>();
		InstantiateSlots();

		_uiSlots = GetComponentsInChildren<UIInventorySlot>();
		InstallationInventory();
	}

	private void OnEnable()
	{
		Inventory.OnInventoryStateChanged += InventoryStateChanged;
		InventoryStateChanged();
	}

	private void OnDisable()
	{
		_target.Inventory.OnInventoryStateChanged -= InventoryStateChanged;
	}

	private void InventoryStateChanged()
	{
		foreach(var slot in _uiSlots)
			slot.RefreshSlot();
	}

	private void InstantiateSlots()
	{
		_grid.enabled = true;

		for (int i = 0; i < Inventory.Capacity; i++)
			Instantiate(_prefabSlot, transform);

		Invoke("DisableGrid", 1f);
	}

	private void DisableGrid()
	{
		_grid.enabled = false;
	}

	private void InstallationInventory()
	{
		IInventorySlot[] abstractSlots = Inventory.GetAllSlots();

		for (int i = 0; i < Inventory.Capacity; i++)
		{
			_uiSlots[i].SetSlot(abstractSlots[i]);
			_uiSlots[i].RefreshSlot();
		}
	}
}
