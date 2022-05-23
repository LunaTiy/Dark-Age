using System;
using System.Collections.Generic;


interface IStats
{
	IStat[] GetStats();
	void AddStat(IStat stat);
	void RemoveStatsByType(IStat.Type type);
}
