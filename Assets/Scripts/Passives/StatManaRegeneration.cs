using System;
using System.Collections.Generic;

class StatManaRegeneration : Stat
{
	public StatManaRegeneration(int value, int ticks)
	{
		this.value = value;
		type = Type.HealthRegeneration;
		this.ticks = ticks;
	}

	public override void Tick(Characteristics characteristics)
	{
		characteristics.Mana += value;
	}
}
