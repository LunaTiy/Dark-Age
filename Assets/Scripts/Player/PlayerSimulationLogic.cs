using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSimulationLogic : MonoBehaviour
{
    [HideInInspector] public PlayerLogic player;

	private float _elapsedTime;

	private void Awake()
	{
		player = new PlayerLogic();
		Debug.Log("Hp player on start:" + player.HealthPoints);
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
		}
	}

	private void MpRegen()
	{
		if(_elapsedTime >= 1f)
		{
			player.ManaPoints += player.MpRegen;
		}
	}
}
