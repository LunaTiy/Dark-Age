using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateBar : MonoBehaviour
{
	private Image _fillArea;
	private Text _text;

	private void Start()
	{
		_fillArea = GetComponent<Image>();
		_text = transform.GetComponentInChildren<Text>();
	}

	public void DrawUpdatedBar(int value, int maxValue)
	{

		_text.text = $"{value} / {maxValue}";
		_fillArea.fillAmount = (float) value / maxValue;
	}
}
