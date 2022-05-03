using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour, ICharacter
{
	public event Action<int, int> HealthChanged;
	public event Action<int, int> ManaChanged;

	[SerializeField] private int _maxHealth = 100;
	[SerializeField] private int _health = 100;
	[SerializeField] private int _maxMana = 20;
	[SerializeField] private int _mana = 20;

	private Stats _passiveSkills;

	public int MaxHealth
	{
		get => _maxHealth;
		set
		{
			if (value > 0) _maxHealth = value;
		}
	}
	public int Health
	{
		get => _health;
		set
		{
			if (value >= 0 && value <= _maxHealth) _health = value;
			else if (value < 0) _health = 0;
		}
	}
	public int MaxMana
	{
		get => _maxMana;
		set
		{
			if (value > 0) _maxMana = value;
		}
	}
	public int Mana
	{
		get => _mana;
		set
		{
			if (value >= 0 && value <= _maxMana) _mana = value;
			else if (value < 0) _mana = 0;
		}
	}

	private void Start()
	{
		_passiveSkills = new Stats(new List<Stat> { 
			new Stat(1, Stat.TypeStat.HealthRegeneration),
			new Stat(1, Stat.TypeStat.ManaRegeneration)
		});

		StartCoroutine(PassiveSkills());
	}

	private IEnumerator PassiveSkills()
	{
		var waitForSeconds = new WaitForSeconds(2f);

		while (true)
		{
			foreach (Stat stat in _passiveSkills.GetStats())
			{
				if (stat.type == Stat.TypeStat.HealthRegeneration) Health += stat.value;
				else if (stat.type == Stat.TypeStat.ManaRegeneration) Mana += stat.value;
				else Health -= stat.value;
			}

			HealthChanged?.Invoke(Health, MaxHealth);
			ManaChanged?.Invoke(Mana, MaxMana);

			yield return waitForSeconds;
		}
	}

	public void TakeDamage(int damage)
	{
		Health -= damage;
		HealthChanged?.Invoke(_health, _maxHealth);
	}
}
