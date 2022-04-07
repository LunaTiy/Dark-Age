using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


interface IWeapon
{
	public int Damage { get; set; }

	public float TimeBtwAttack { get; set; }

	public int MakeDamage();
}
