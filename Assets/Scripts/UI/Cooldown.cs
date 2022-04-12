using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cooldown : MonoBehaviour
{
	private Image _cooldownImage;
	private float _remainingTime;
	private float _timeBtwAttack;

	private void Start()
	{
		_cooldownImage = GetComponent<Image>();
	}

	private void Update()
	{
		if (_remainingTime > 0f)
		{
			_cooldownImage.fillAmount = (_remainingTime - _timeBtwAttack) / (0 - _timeBtwAttack);
			_remainingTime -= Time.deltaTime;
		}
		else if(_remainingTime < 0)
		{
			_remainingTime = 0f;
			_cooldownImage.fillAmount = 1f;
		}
	}

	public void StartCooldown(float time)
	{
		_timeBtwAttack = time;
		_remainingTime = time;
	}
}
