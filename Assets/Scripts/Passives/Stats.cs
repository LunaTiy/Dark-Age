using System;
using System.Collections.Generic;

class Stats : IStats
{
	private List<Stat> _stats;

	public Stats()
	{
		_stats = new List<Stat>();
	}

	public Stats(List<Stat> stats)
	{
		_stats = stats;
	}

	public IEnumerable<Stat> GetStats()
	{
		return _stats;
	}

	public void AddStat(Stat stat)
	{
		_stats.Add(stat);
	}

	public void RemoveStatsByType(Stat.Type type)
	{
		if (_stats.Count == 0)
			return;

		for(int i = _stats.Count - 1; i >= 0; i--)
			if (_stats[i].type == type)
				_stats.RemoveAt(i);
	}

	public void Influence(Characteristics characteristics)
	{
		for(int i = _stats.Count - 1; i >= 0; i--)
		{
			_stats[i].Tick(characteristics);

			if (_stats[i].ticks == 0)
				_stats.RemoveAt(i);
		}
	}
}
