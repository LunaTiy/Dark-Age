using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

interface ICharacter
{
	int MaxHealth { get; set; }
	int Health { get; set; }
	int MaxMana { get; set; }
	int Mana { get; set; }

	void TakeDamage(int damage);
}
