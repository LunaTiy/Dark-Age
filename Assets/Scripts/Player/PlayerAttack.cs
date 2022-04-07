using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
	[HideInInspector] public bool isAttack;

	private Animator _animator;
	private float _timeBtwAttack;
	private float _timePauseAttack;

	private void Start()
	{
		_animator = GetComponent<Animator>();
		_timeBtwAttack = gameObject.GetComponentInChildren<WeaponSimulation>().weapon.TimeBtwAttack;
	}

	private void Update()
	{
		Attack();
	}

	private void Attack()
	{
		if (!isAttack)
		{
			if (Input.GetKeyDown(KeyCode.Mouse0))
			{
				_animator.SetTrigger("Attack");
				_timePauseAttack = _timeBtwAttack;
				isAttack = true;
			}
		}

		_timePauseAttack -= Time.deltaTime;

		if(_timePauseAttack <= 0)
		{
			_timePauseAttack = 0;
			isAttack = false;
		}
	}
}
