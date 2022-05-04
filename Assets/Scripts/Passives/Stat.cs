using System;

public abstract class Stat
{
	public int value;
	public Type type;
	public int ticks;

	public enum Type
	{
		None,
		HealthRegeneration,
		ManaRegeneration,
		Poisoning,
		Bleeding
	}

	public abstract void Tick(Characteristics characteristics);
}
