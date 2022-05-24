using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatUI : MonoBehaviour
{
    [SerializeField] private Image _imageIcon;
    [SerializeField] private Text _text;

    public void Refresh(IStat stat)
	{
        if(stat == null)
		{
            _imageIcon.enabled = false;
            _text.enabled = false;

            return;
		}

        RefreshImage(stat);
        RefreshText(stat);        
	}

    private void RefreshImage(IStat stat)
	{
        if (_imageIcon.enabled == false)
            _imageIcon.enabled = true;

        _imageIcon.sprite = stat.Info.Icon;
	}

    private void RefreshText(IStat stat)
	{
        if (stat.Ticks < 1)
        {
            _text.enabled = false;
            return;
        }

        if (_text.enabled == false)
            _text.enabled = true;

        _text.text = $"x{stat.Ticks}";
    }
}
