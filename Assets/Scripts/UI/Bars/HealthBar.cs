using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
	[SerializeField] private Character _target;

	[SerializeField] private Image _fillArea;
	[SerializeField] private Text _text;

	private Characteristics Characteristics => _target.Characteristics;

	private void OnEnable()
	{
		_target.OnHealthChanged += HealthChanged;
		HealthChanged();
	}

	private void OnDisable()
	{
		_target.OnHealthChanged -= HealthChanged;
	}

	public void HealthChanged()
	{
		int health = Characteristics.Health;
		int maxHealth = Characteristics.MaxHealth;

		_text.text = $"{health} / {maxHealth}";
		_fillArea.fillAmount = (float) health / maxHealth;
	}
}
