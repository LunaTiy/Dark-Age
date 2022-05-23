using System;
using System.Collections.Generic;


class StatPoisoning : IStat
{
	public StatPoisoning(IStatInfo info, int value, int ticks)
	{
		Info = info;
		Value = value;
		TypeStat = IStat.Type.Poisoning;
		Ticks = ticks;
	}

	public IStatInfo Info { get; private set; }
	public int Value { get; private set; }
	public IStat.Type TypeStat { get; private set; }
	public int Ticks { get; private set; }

	public void Tick(Characteristics characteristics)
	{
		characteristics.Health -= Value;

		if (Ticks > 0) Ticks--;
	}
}
