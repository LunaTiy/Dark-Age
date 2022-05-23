using System;
using System.Collections.Generic;

class StatManaRegeneration : IStat
{
	public StatManaRegeneration(IStatInfo info, int value, int ticks)
	{
		Info = info;
		Value = value;
		TypeStat = IStat.Type.ManaRegeneration;
		Ticks = ticks;
	}

	public IStatInfo Info { get; private set; }
	public int Value { get; private set; }
	public IStat.Type TypeStat { get; private set; }
	public int Ticks { get; private set; }

	public void Tick(Characteristics characteristics)
	{
		characteristics.Mana += Value;

		if (Ticks > 0) Ticks--;
	}
}
