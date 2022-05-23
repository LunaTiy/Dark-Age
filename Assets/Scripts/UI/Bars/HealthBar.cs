using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
	[SerializeField] private Character _target;

	[SerializeField] private Image _fillArea;
	[SerializeField] private Text _text;

	private void OnEnable()
	{
		_target.OnHealthChanged += ShowHealthBar;
	}

	private void OnDisable()
	{
		_target.OnHealthChanged -= ShowHealthBar;
	}

	public void ShowHealthBar(int value, int maxValue)
	{
		_text.text = $"{value} / {maxValue}";
		_fillArea.fillAmount = (float) value / maxValue;
	}
}
