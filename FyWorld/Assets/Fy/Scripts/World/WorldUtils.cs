/*
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
| FyWorld - A top down simulation game in a fantasy medieval world.    |
|                                                                      |
|    :copyright: © 2019 Florian Gasquez.                               |
|    :license: GPLv3, see LICENSE for more details.                    |
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
*/
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Fy.Entities;
using Fy.Helpers;
using Fy.Definitions;
using Fy.Characters.AI;
using Fy.Characters;

namespace Fy.World {
	public struct BucketResult {
		public bool result;
		public LayerGridBucket bucket;
		public Tilable tilable;
	}

	public static partial class WorldUtils {
		public static Tilable ClosestTilableFromEnum (Vector2Int position, IEnumerable<Tilable> tilables) {
			Tilable result = null;
			float minDistance = float.MaxValue;
			foreach (Tilable tilable in tilables) {
				float currentMinDistance = Utils.Distance(position, tilable.position);
				if (currentMinDistance < minDistance) {
					minDistance = currentMinDistance;
					result = tilable;
				}
			}

			return result;
		}

		public static BaseCharacter NextToAttack(Vector2Int position, IEnumerable<BaseCharacter> zombies)
		{
			BaseCharacter zombie = ClosestHumanFromEnum(position, zombies);
			return zombie;
		}


		public static BaseCharacter ClosestHumanFromEnum(Vector2Int position, IEnumerable<BaseCharacter> characters)
		{
			BaseCharacter result = null;
			float minDistance = float.MaxValue;
			foreach (BaseCharacter c in characters)
			{
				float currentMinDistance = Utils.Distance(position, c.position);
				if (currentMinDistance < minDistance)
				{
					minDistance = currentMinDistance;
					result = c;
				}
			}

			return result;
		}

	}
}