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
	public class TaskEatHuman : TaskClass
	{
		public TaskEatHuman(BaseCharacter character, Task task) : base(character, task) { }

		public override bool Perform()
		{

			BaseCharacter human = (BaseCharacter)this.task.targets.current.targetCharacter;
			if(human.position == character.position)
            {
				Debug.Log("Human got damage -1");
				human.GetDamage(-1);
			}
			return true;
		}
	}
}