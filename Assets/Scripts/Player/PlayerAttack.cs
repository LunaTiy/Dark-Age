using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAttack : MonoBehaviour
{
	[SerializeField] private UnityEvent _attacked = new UnityEvent();

	public float timeBtwAttack;
	public float remainingTimeToAttack;
	[HideInInspector] public bool isAttack;

	private Animator _animator;

	private void Start()
	{
		_animator = GetComponent<Animator>();
		timeBtwAttack = gameObject.GetComponentInChildren<WeaponSimulation>().weapon.TimeBtwAttack;
	}

	private void Update()
	{
		AttackLogic();
	}

	private void AttackLogic()
	{
		if (Input.GetKeyDown(KeyCode.Mouse0))
			Attack();

		AttackCooldown();
	}

	private void AttackCooldown()
	{
		if (remainingTimeToAttack > 0)
			remainingTimeToAttack -= Time.deltaTime;
		else if (remainingTimeToAttack < 0)
		{
			remainingTimeToAttack = 0;
			isAttack = false;
		}
	}

	public void Attack()
	{
		if (remainingTimeToAttack == 0)
		{
			_animator.SetTrigger("Attack");
			remainingTimeToAttack = timeBtwAttack;
			isAttack = true;

			_attacked.Invoke();
		}
	}

	public void OnPlayerBlasted()
	{
		remainingTimeToAttack = 1f;
	}
}
