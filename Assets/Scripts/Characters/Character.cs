using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
	[Header("Events")]
	[SerializeField] private UnityEvent<float> _takedDamage;

	[Header("Properties")]
	[SerializeField] private int _capacityInventory = 12;

	private Inventory _inventory;
	private Characteristics _characteristics;	
	private Stats _passives;

	public Inventory Inventory => _inventory;
	public Characteristics Characteristics => _characteristics;
	public Stats Passives => _passives;

	private void Awake()
	{
		_inventory = new Inventory(_capacityInventory);
		_characteristics = new Characteristics();
		_passives = new Stats();

		StartCoroutine(InfluencePassives());
	}

	private IEnumerator InfluencePassives()
	{
		var waitForSeconds = new WaitForSeconds(1f);

		while (true)
		{
			_passives.Influence(_characteristics);
			yield return waitForSeconds;
		}
	}

	public void TakeDamage(int damage)
	{
		_characteristics.Health -= damage;
		_takedDamage?.Invoke(0.2f);
	}
}
