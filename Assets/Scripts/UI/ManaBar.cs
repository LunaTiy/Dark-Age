using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
	[SerializeField] private Character _target;

	[SerializeField] private Image _fillArea;
	[SerializeField] private Text _text;

	private void OnEnable()
	{
		_target.ManaChanged += ShowManaBar;
	}

	private void OnDisable()
	{
		_target.ManaChanged -= ShowManaBar;
	}

	public void ShowManaBar(int value, int maxValue)
	{
		_text.text = $"{value} / {maxValue}";
		_fillArea.fillAmount = (float) value / maxValue;
	}
}
