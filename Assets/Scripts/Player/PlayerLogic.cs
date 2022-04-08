using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic
{
	public event Action Died;

    private int _maxHealthPoints;
    private int _healthPoints;
	private int _hpRegen;

	private int _maxManaPoints;
	private int _manaPoints;
	private int _mpRegen;

	private int _armor;

	public PlayerLogic()
	{
		MaxHealthPoints = 100;
		HealthPoints = 100;
		HpRegen = 1;

		MaxManaPoints = 20;
		ManaPoints = MaxManaPoints;
		MpRegen = 1;

		Armor = 1;
	}

	public int MaxHealthPoints
	{
		get => _maxHealthPoints;
		set
		{
			if (value > _maxHealthPoints) _maxHealthPoints = value;
		}
	}

	public int HealthPoints
	{
		get => _healthPoints;
		set
		{
			if (value <= _maxHealthPoints) _healthPoints = value;
			if (value < 0) _healthPoints = 0;
		}
	}

	public int HpRegen
	{
		get => _hpRegen;
		private set
		{
			if(value >= 0)
				_hpRegen = value;
		}
	}

	public int MaxManaPoints
	{
		get => _maxManaPoints;
		set
		{
			if (value > _maxManaPoints) _maxManaPoints = value;
		}
	}

	public int ManaPoints
	{
		get => _manaPoints;
		set
		{
			if (value < _maxManaPoints && value >= 0) _manaPoints = value;
			else _manaPoints = 0;
		}
	}

	public int MpRegen
	{
		get => _mpRegen;
		private set
		{
			if (value >= 0)
				_mpRegen = value;
		}
	}

	public int Armor
	{
		get => _armor;
		set
		{
			if (value > 0) _armor = value;
			else _armor = 0;
		}
	}

	public void TakeDamage(int damage)
	{
		if (damage <= 0)
			return;

		int damageOnArmor = damage - Armor * 3;
		HealthPoints -= damageOnArmor;

		if (HealthPoints <= 0) Died?.Invoke();
	}
}
