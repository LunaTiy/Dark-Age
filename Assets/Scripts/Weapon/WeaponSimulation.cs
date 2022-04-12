using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSimulation : MonoBehaviour
{
	[HideInInspector] public Weapon weapon;
	private float _attackTime;

	private void Awake()
	{
		weapon = new Weapon();
	}

	private void Update()
	{
		if (_attackTime > 0) _attackTime -= Time.deltaTime;
		else if (_attackTime < 0) _attackTime = 0;
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Enemy" && _attackTime > 0)
		{
			Debug.Log($"Hit damage {weapon.Damage}: {collision.gameObject.name}");
		}
	}

	public void OnAttacked(float time)
	{
		_attackTime = time;
	}
}
