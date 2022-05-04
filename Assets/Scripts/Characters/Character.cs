using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
	[Header("Events")]
	[SerializeField] private UnityEvent<float> _takedDamage;
	public event Action<int, int> HealthChanged;
	public event Action<int, int> ManaChanged;

	private Characteristics _characteristics;	
	private Stats _passives;

	private void Start()
	{
		_characteristics = new Characteristics();

		_passives = new Stats(new List<Stat> { 
			new StatHealthRegeneration(1, -1),
			new StatManaRegeneration(1, -1),
		});

		StartCoroutine(InfluencePassives());
	}

	private IEnumerator InfluencePassives()
	{
		var waitForSeconds = new WaitForSeconds(2f);

		while (true)
		{
			_passives.Influence(_characteristics);

			HealthChanged?.Invoke(_characteristics.Health, _characteristics.MaxHealth);
			ManaChanged?.Invoke(_characteristics.Mana, _characteristics.MaxMana);

			yield return waitForSeconds;
		}
	}

	public void TakeDamage(int damage)
	{
		_characteristics.Health -= damage;
		HealthChanged?.Invoke(_characteristics.Health, _characteristics.MaxHealth);

		_takedDamage?.Invoke(0.2f);
	}

	public void GetPassiveEffect(Stat stat)
	{
		if (stat == null)
			return;

		_passives.AddStat(stat);
	}
}
