using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


interface IStats
{
	IEnumerable<Stat> GetStats();

	void AddStat(Stat stat);

	void RemoveStat(Stat.TypeStat type);
}
