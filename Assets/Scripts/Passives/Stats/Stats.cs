using System;
using System.Collections.Generic;

public class Stats : IStats
{
	public event Action OnStatsChanged;

	private List<IStat> _stats;

	public Stats()
	{
		_stats = new List<IStat>();
	}

	public Stats(List<IStat> stats)
	{
		_stats = stats;
	}

	public IStat[] GetStats()
	{
		return _stats.ToArray();
	}

	public void AddStat(IStat stat)
	{
		_stats.Add(stat);

		OnStatsChanged?.Invoke();
	}

	public void RemoveStatsByType(IStat.Type type)
	{
		if (_stats.Count == 0)
			return;

		for(int i = _stats.Count - 1; i >= 0; i--)
			if (_stats[i].TypeStat == type)
				_stats.RemoveAt(i);

		OnStatsChanged?.Invoke();
	}

	public void Influence(Characteristics characteristics)
	{
		for(int i = _stats.Count - 1; i >= 0; i--)
		{
			_stats[i].Tick(characteristics);

			if (_stats[i].Ticks == 0)
				_stats.RemoveAt(i);
		}

		OnStatsChanged?.Invoke();
	}
}
