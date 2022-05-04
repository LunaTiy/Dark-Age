using System;
using System.Collections.Generic;


class StatPoisoning : Stat
{
	public StatPoisoning(int value, int ticks)
	{
		this.value = value;
		type = Type.HealthRegeneration;
		this.ticks = ticks;
	}

	public override void Tick(Characteristics characteristics)
	{
		characteristics.Health -= value;

		if (ticks > 0) ticks--;
	}
}
