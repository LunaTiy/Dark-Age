using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
	[SerializeField] private Character _target;

	[SerializeField] private Image _fillArea;
	[SerializeField] private Text _text;

	private Characteristics Characteristics => _target.Characteristics;

	private void OnEnable()
	{
		_target.OnManaChanged += ManaChanged;
		ManaChanged();
	}

	private void OnDisable()
	{
		_target.OnManaChanged -= ManaChanged;
	}

	public void ManaChanged()
	{
		int mana = Characteristics.Mana;
		int maxMana = Characteristics.MaxMana;

		_text.text = $"{mana} / {maxMana}";
		_fillArea.fillAmount = (float)mana / maxMana;
	}
}
