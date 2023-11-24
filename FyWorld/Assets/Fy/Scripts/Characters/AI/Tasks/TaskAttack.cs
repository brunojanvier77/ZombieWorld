/*
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
| FyWorld - A top down simulation game in a fantasy medieval world.    |
|                                                                      |
|    :copyright: © 2019 Florian Gasquez.                               |
|    :license: GPLv3, see LICENSE for more details.                    |
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
*/
using Fy.Entities;
using UnityEngine;

namespace Fy.Characters.AI
{
	public class TaskAttack : TaskClass
	{
		public TaskAttack(BaseCharacter character, Task task) : base(character, task) { }

		public override bool Perform()
		{
			Debug.Log("TaskAttack Perform");
			BaseCharacter zombie = (BaseCharacter)this.task.targets.current.targetCharacter;
			
			if(zombie is Zombie && character is Human && ((Human)character).gun != null)
            {
				Gun g = ((Human)character).gun;
				g.Shoot((Zombie)zombie);
				Debug.Log("Zombie got shot");
			}
			return true;
		}
	}
}