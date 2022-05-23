using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
	[Header("Events")]
	[SerializeField] private UnityEvent<float> _takedDamage;
	public event Action<int, int> OnHealthChanged;
	public event Action<int, int> OnManaChanged;

	[Header("Properties")]
	[SerializeField] private int _capacityInventory = 12;

	private Inventory _inventory;
	private Characteristics _characteristics;	
	private Stats _passives;

	public Inventory Inventory => _inventory;
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
		var waitForSeconds = new WaitForSeconds(2f);

		while (true)
		{
			_passives.Influence(_characteristics);

			OnHealthChanged?.Invoke(_characteristics.Health, _characteristics.MaxHealth);
			OnManaChanged?.Invoke(_characteristics.Mana, _characteristics.MaxMana);

			yield return waitForSeconds;
		}
	}

	public void TakeDamage(int damage)
	{
		_characteristics.Health -= damage;
		OnHealthChanged?.Invoke(_characteristics.Health, _characteristics.MaxHealth);

		_takedDamage?.Invoke(0.2f);
	}
}
