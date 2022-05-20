using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag : MonoBehaviour
{
    [SerializeField] private GameObject _inventory;

	bool isOpen = false;

    public void OpenCloseInventory()
	{
		isOpen = !isOpen;
		_inventory.SetActive(isOpen);
	}
}
