using System;

public interface IStat
{
	public IStatInfo Info { get; }
	public int Value { get; }
	public Type TypeStat { get; }
	public int Ticks { get; }

	public enum Type
	{
		None,
		HealthRegeneration,
		ManaRegeneration,
		Poisoning,
		Bleeding
	}

	public void Tick(Characteristics characteristics);
}
