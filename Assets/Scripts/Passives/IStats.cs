using System;
using System.Collections.Generic;


interface IStats
{
	IEnumerable<Stat> GetStats();
	void AddStat(Stat stat);
	void RemoveStatsByType(Stat.Type type);
}
