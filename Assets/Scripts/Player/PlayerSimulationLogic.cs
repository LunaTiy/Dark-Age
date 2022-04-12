using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerSimulationLogic : MonoBehaviour
{
    [HideInInspector] public PlayerLogic player;
	[SerializeField] private BarEvent _updatedHpBar;
	[SerializeField] private BarEvent _updatedMpBar;

	private float _elapsedTime;

	private void Awake()
	{
		player = new PlayerLogic();
	}

	private void Start()
	{
		_updatedHpBar.Invoke(player.HealthPoints, player.MaxHealthPoints);
		_updatedMpBar.Invoke(player.ManaPoints, player.MaxManaPoints);
	}

	private void Update()
	{
		_elapsedTime += Time.deltaTime;

		HpRegen();
		MpRegen();

		if (_elapsedTime >= 1f) _elapsedTime = 0;
	}

	private void HpRegen()
	{
		if (_elapsedTime >= 1f)
		{
			player.HealthPoints += player.HpRegen;
			_updatedHpBar.Invoke(player.HealthPoints, player.MaxHealthPoints);
		}
	}

	private void MpRegen()
	{
		if(_elapsedTime >= 1f)
		{
			player.ManaPoints += player.MpRegen;
			_updatedMpBar.Invoke(player.ManaPoints, player.MaxManaPoints);
		}
	}

	public void TakeDamage(int damage)
	{
		player.TakeDamage(damage);
		_updatedHpBar.Invoke(player.HealthPoints, player.MaxHealthPoints);
	}

	public void CastAbility(int mp)
	{
		player.ManaPoints -= mp;
		_updatedMpBar.Invoke(player.ManaPoints, player.MaxManaPoints);
	}
}

[Serializable]
public class BarEvent : UnityEvent<int, int> { }
