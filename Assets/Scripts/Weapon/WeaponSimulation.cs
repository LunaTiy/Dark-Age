using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSimulation : MonoBehaviour
{
	[HideInInspector] public Weapon weapon;

	private PlayerAttack _playerAttack;

	private void Start()
	{
		_playerAttack = gameObject.GetComponentInParent<PlayerAttack>();
		weapon = new Weapon();
	}
	private void OnCollisionEnter(Collision collision)
	{
		if (_playerAttack.isAttack)
		{
			Debug.Log($"Hit damage {weapon.Damage}: {collision.gameObject.name}");
		}
	}
}
