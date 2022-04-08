using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownBlast : MonoBehaviour
{
	[SerializeField] private PlayerBlastAround _playerBlast;

	private Image _cooldownImage;
	private float _remainingTime;
	private float _timeBtwBlast;

	private void Start()
	{
		_cooldownImage = GetComponent<Image>();
	}

	private void Update()
	{
		if (_remainingTime > 0f)
		{
			_cooldownImage.fillAmount = (_remainingTime - _timeBtwBlast) / (0 - _timeBtwBlast);
			_remainingTime -= Time.deltaTime;
		}
		else if(_remainingTime < 0)
		{
			_remainingTime = 0f;
			_cooldownImage.fillAmount = 1f;
		}
	}

	public void OnPlayerBlasted()
	{
		_timeBtwBlast = _playerBlast.timeBtwBlast;
		_remainingTime = _timeBtwBlast;
	}
}
