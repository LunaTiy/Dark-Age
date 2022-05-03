using System;

class Stat
{
	public int value;
	public TypeStat type;

	public enum TypeStat
	{
		None,
		HealthRegeneration,
		ManaRegeneration,
		Poisoning,
		Bleeding
	}

	public Stat(int value, TypeStat type)
	{
		this.value = value;
		this.type = type;
	}	
}
