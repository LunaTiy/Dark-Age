using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterAttack : MonoBehaviour
{
	[HideInInspector] public bool canAttack = true;
	[HideInInspector] public bool isAttack = false;

	private Weapon _weapon;
	private Animator _animator;

	private void Start()
	{
		_weapon = GetComponentInChildren<Weapon>();
		_animator = GetComponent<Animator>();
	}

	public void Attack()
	{
		if (canAttack)
		{
			_animator.SetTrigger("Attack");
			canAttack = false;
			isAttack = true;

			Invoke("EndOfAttack", _weapon.SwingTime);
			Invoke("ReloadAttack", 1 / _weapon.AttackSpeed);
		}
	}

	private void ReloadAttack()
	{
		CancelInvoke("ReloadAttack");
		canAttack = true;
	}

	private void EndOfAttack()
	{
		isAttack = false;
	}
}
