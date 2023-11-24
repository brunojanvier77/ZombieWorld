/*
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
| FyWorld - A top down simulation game in a fantasy medieval world.    |
|                                                                      |
|    :copyright: © 2019 Florian Gasquez.                               |
|    :license: GPLv3, see LICENSE for more details.                    |
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
*/
using UnityEngine;
using System;
using Fy.Definitions;
using Fy.World;

namespace Fy.Characters.AI {
	public class N_EatHuman : BrainNodeConditional {
		private class N_EatHumanTaskData : BrainNode {
			public override Task GetTask() {
				BaseCharacter result = WorldUtils.ClosestHumanFromEnum(this.character.position, Loki.map.characters);
				if(result != null)
					return new Task(
						Defs.tasks["task_eathuman"],
						new TargetList(new Target(result))
					);

				return null;
			}
		}

		public N_EatHuman(Func<bool> condition) : base(condition) {
			this.subNodes.Add(new N_EatHumanTaskData());
		}
	}
}