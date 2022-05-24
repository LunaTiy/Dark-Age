using UnityEngine;
using UnityEngine.UI;

public class StatsUI : MonoBehaviour
{
    [SerializeField] private Character _target;
	private StatUI[] _statsUI;
	private Stats Stats => _target.Passives;

	private void Awake()
	{
		_statsUI = GetComponentsInChildren<StatUI>();
	}

	private void OnEnable()
	{
		Invoke("Subscribe", 0.2f);
	}

	private void OnDisable()
	{
		Stats.OnStatsChanged -= StatsChanged;
	}

	private void StatsChanged()
	{
		IStat[] stats = Stats.GetStats();

		for(int i = 0; i < stats.Length && i < _statsUI.Length; i++)
			_statsUI[i].Refresh(stats[i]);

		for (int i = stats.Length; i < _statsUI.Length; i++)
			_statsUI[i].Refresh(null);
	}

	private void Subscribe()
	{
		Stats.OnStatsChanged += StatsChanged;
		StatsChanged();
	}
}
