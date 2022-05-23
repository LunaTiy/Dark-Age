using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StatInfo", menuName = "Gameplay/Stats/Create Stat Info")]
public class StatInfo : ScriptableObject, IStatInfo
{
	[SerializeField] private string _title;
	[SerializeField] private string _description;
	[SerializeField] private Sprite _icon;

	public string Title => _title;
	public string Description => _description;
	public Sprite Icon => _icon;
}
