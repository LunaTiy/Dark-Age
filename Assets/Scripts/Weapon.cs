using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : IWeapon
{
    private int _damage;
    private float _timeBtwAttack;

	public Weapon()
	{
        _damage = 10;
        _timeBtwAttack = 0.4f;
	}

	public Weapon(int damage, float timeBtwAttack)
	{
        Damage = damage;
        TimeBtwAttack = timeBtwAttack;
	}

    public int Damage 
    {
        get => _damage;
        set
        {
            if (value > 0)  _damage = value;
        }
    }

    public float TimeBtwAttack
	{
        get => _timeBtwAttack;
		set
		{
            if (value >= 0) _timeBtwAttack = value; 
		}
	}

    public int MakeDamage()
	{
        return Damage;
	}
}
