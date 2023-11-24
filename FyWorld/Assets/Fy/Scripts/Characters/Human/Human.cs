/*
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
| FyWorld - A top down simulation game in a fantasy medieval world.    |
|                                                                      |
|    :copyright: © 2019 Florian Gasquez.                               |
|    :license: GPLv3, see LICENSE for more details.                    |
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
*/
using UnityEngine;
using System.Collections.Generic;
using Fy.Definitions;
using Fy.Characters.AI;
using Fy.Visuals;
using Fy.World;
using Fy.Helpers;
using Fy.Entities;

namespace Fy.Characters {
	// Human representation in our game
	public class Human : BaseCharacter {

		public Gun gun { get; protected set; }
		/* Contain HumanSkinData, all data about the human skin */
		public HumanSkin humanSkin { get; protected set; }

		/// Instantiate an human object
		public Human(Vector2Int position, bool hasGun, AnimalDef def) : base(position, def) {
			this.humanSkin = new HumanSkin(this);
			this.movement.onChangeDirection += this.humanSkin.UpdateLookingAt;
            if (hasGun)
            {
				gun = new Gun(this);
            }

			this.brain = new CharacterBrain(this, this.GetBrainNode());
		}

		/// Get the root BrainNode for the human AI
		public override BrainNodePriority GetBrainNode() {
			BrainNodePriority brainNode = new BrainNodePriority();

			// one brain for military
            if (gun != null)
            {
                brainNode.AddSubnode(new N_Attack());
				brainNode.AddSubnode(new N_Sleep(() => (this.stats.vitals[Vitals.Energy].ValueInfToPercent(.15f))));
				brainNode.AddSubnode(new N_EatVegies(() => (this.stats.vitals[Vitals.Hunger].ValueInfToPercent(.25f))));
			}
            else
			{
				// one brain for workers
				brainNode.AddSubnode(new N_Sleep(() => (this.stats.vitals[Vitals.Energy].ValueInfToPercent(.15f)))); 
				brainNode.AddSubnode(new N_EatVegies(() => (this.stats.vitals[Vitals.Hunger].ValueInfToPercent(.25f))));
				brainNode.AddSubnode(new N_Cut(WorldUtils.HasPlantsToCut));
				//brainNode.AddSubnode(new N_Grow(WorldUtils.FieldHasWork));
				brainNode.AddSubnode(new N_HaulRecipe(WorldUtils.HaulRecipeNeeded));
				brainNode.AddSubnode(new N_Idle());
			}


			return brainNode;
		}

		/// Draw the human skin with HumanSkinData 
		public override void UpdateDraw() {
			this.humanSkin.UpdateDraw();
		}


	}
}