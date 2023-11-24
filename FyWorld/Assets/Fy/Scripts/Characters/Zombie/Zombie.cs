/*
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
| FyWorld - A top down simulation game in a fantasy medieval world.    |
|                                                                      |
|    :copyright: © 2019 Florian Gasquez.                               |
|    :license: GPLv3, see LICENSE for more details.                    |
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
*/
using UnityEngine;
using Fy.Definitions;
using Fy.Characters.AI;

namespace Fy.Characters {
	public class Zombie : BaseCharacter
	{
		/* Contain HumanSkinData, all data about the human skin */
		public ZombieSkin zombieSkin { get; protected set; }
		public Zombie(Vector2Int position, AnimalDef def) : base(position, def)
		{
			this.zombieSkin = new ZombieSkin(this);
			this.movement.onChangeDirection += this.zombieSkin.UpdateLookingAt;
		}

		public override BrainNodePriority GetBrainNode() {
			BrainNodePriority brainNode = new BrainNodePriority();

			brainNode.AddSubnode(new N_EatHuman(() => (this.stats.vitals[Vitals.Hunger].ValueInfToPercent(.99f))));
			brainNode.AddSubnode(new N_Idle());
			return brainNode;
		}
		/// Draw the human skin with HumanSkinData 
		public override void UpdateDraw()
		{
			this.zombieSkin.UpdateDraw();
		}
	}
}