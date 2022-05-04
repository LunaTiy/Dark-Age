using System;

public class Characteristics
{
	private int _maxHealth;
	private int _health;
	private int _maxMana;
	private int _mana;

	public Characteristics()
	{
		_maxHealth = 100;
		_health = 100;
		_maxMana = 20;
		_mana = 20;
	}

	public Characteristics(int maxHealth, int health, int maxMana, int mana)
	{
		MaxHealth = maxHealth;
		Health = health;
		MaxMana = maxMana;
		Mana = mana;
	}

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
}
