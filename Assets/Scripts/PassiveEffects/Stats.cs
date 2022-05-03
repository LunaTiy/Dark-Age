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

	public void RemoveStat(Stat.TypeStat type)
	{
		if (_stats.Count == 0)
			return;

		for(int i = 0; i < _stats.Count; i++)
			if (_stats[i].type == type)
				_stats.RemoveAt(i);
	}
}
