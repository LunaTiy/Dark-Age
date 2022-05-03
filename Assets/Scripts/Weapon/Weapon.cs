using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	[SerializeField] private GameObject _holder;

    [SerializeField] private int _damage = 20;
    [SerializeField] private float _attackSpeed = 2f;
	[SerializeField] private float _swingTime = 0.5f;

	public float AttackSpeed { get => _attackSpeed; }
	public float SwingTime { get => _swingTime; }

	private void OnEnable()
	{
		_holder = GetComponentInParent<Character>().gameObject;
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.TryGetComponent<Character>(out Character hitTarget) && _holder.GetComponent<CharacterAttack>().isAttack)
		{
			if (hitTarget.gameObject != _holder)
			{
				hitTarget.TakeDamage(_damage);
			}
		}
	}
}
