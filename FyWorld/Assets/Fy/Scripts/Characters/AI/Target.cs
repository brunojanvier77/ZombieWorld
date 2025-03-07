/*
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
| FyWorld - A top down simulation game in a fantasy medieval world.    |
|                                                                      |
|    :copyright: © 2019 Florian Gasquez.                               |
|    :license: GPLv3, see LICENSE for more details.                    |
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
*/
using System.Collections.Generic;
using UnityEngine;
using Fy.Entities;
using Fy.Helpers;
using Fy.World;


namespace Fy.Characters.AI {
	public enum TargetType {
		None,
		Tile,
		Adjacent,
	}

	// List of targets in our Game
	public class TargetList {
		public Queue<Target> targets = new Queue<Target>();
		public Target current { get; protected set; }
		public bool setAdjs = false;

		public Vector2Int currentPosition { 
			get {
				if (this.current.closestAdj != new Vector2Int(-1,-1)) {
					return this.current.closestAdj;
				}
				return this.current.position;
			}
		}

		public List<Target> ToList() {
			return new List<Target>(this.targets);
		}

		public TargetList(Tilable tilable) {
			this.Enqueue(tilable);
			this.Next();
		}

		public TargetList(Target target) {
			this.Enqueue(target);
			this.Next();
		}

		public TargetList(Vector2Int position) {
			this.Enqueue(position);
			this.Next();
		}

		public TargetList(List<Tilable> entities) {
			foreach (Tilable tilable in entities) {
				this.Enqueue(tilable);
			}
			this.Next();
		}

		public void Enqueue(Target target) {
			if (target == null || Loki.map[target.position] == null)
				return;
			Loki.map[target.position].reserved = true; // @Check adj
			this.targets.Enqueue(target);
		}

		public void Enqueue(Tilable tilable) {
			Loki.map[tilable.position].reserved = true;
			this.targets.Enqueue(new Target(tilable));
		}

		public void Enqueue(Vector2Int position) {
			Loki.map[position].reserved = true;
			this.targets.Enqueue(new Target(position));
		}

		public void Free() {
			if (this.current != null) {
				Loki.map[this.current.position].reserved = false;
			}
		}

		public void FreeAll() {
			while (this.targets.Count != 0) {
				Target target = this.targets.Dequeue();
				Loki.map[target.position].reserved = false;
			}
		}

		public void Next() {
			this.Free();
			if (this.targets.Count > 0)
				this.current = this.targets.Dequeue();
		}
	}

	// A target in our game.
	public class Target {
		public BaseCharacter targetCharacter { get; protected set; }
		public int distanceToTarget { get; protected set; }
		public Tilable tilable { get; protected set; }
		public Vector2Int position { get; protected set; }
		public Vector2Int closestAdj { get; protected set; }

		public Target(BaseCharacter targetCharacter, int distanceToTarget = 0) : this(targetCharacter.position)
		{
			this.targetCharacter = targetCharacter;
			this.distanceToTarget = distanceToTarget;

			this.position = GetAtGoodDistanceFromTarget(this.targetCharacter, this.distanceToTarget);
		}

        private Vector2Int GetAtGoodDistanceFromTarget(BaseCharacter targetCharacter, int distanceToTarget)
		{
			Vector2 randomOrientation = new Vector2(
				   Mathf.Cos(UnityEngine.Random.Range(0, 360)),
				   Mathf.Sin(UnityEngine.Random.Range(0, 360))
			   );
			Vector2Int targetPosition = targetCharacter.position + new Vector2Int((int)Mathf.Round(distanceToTarget * randomOrientation.x), (int)Mathf.Round(distanceToTarget * randomOrientation.y));

			// Maybe do a max try and error if we reach this.
			int nbTry = 20;
			while (nbTry >= 0 && (Loki.map[targetPosition] == null || Loki.map[targetPosition].blockPath || Loki.map[targetPosition].reserved))
			{
				randomOrientation = new Vector2(
					   Mathf.Cos(UnityEngine.Random.Range(0, 360)),
					   Mathf.Sin(UnityEngine.Random.Range(0, 360))
				   );

				targetPosition = targetCharacter.position + new Vector2Int((int)Mathf.Round(distanceToTarget * randomOrientation.x), (int)Mathf.Round(distanceToTarget * randomOrientation.y));
				nbTry--;
			}
			return targetPosition;
		}

        public Target(Tilable tilable) : this(tilable.position) {
			this.tilable = tilable;
		}

		public Target (Vector2Int position) {
			this.position = position;
			this.closestAdj = new Vector2Int(-1, -1);
		}

		public bool GetClosestAdj(Vector2Int fromPosition) {
			float distance = float.MaxValue;
			TileProperty closestNeigbour = null; 

			for (int i = 0; i < 8; i++) {
				TileProperty tileProperty = Loki.map[this.position+DirectionUtils.neighbours[i]];
				if (tileProperty != null && !tileProperty.blockPath) {
					float d = Utils.Distance(fromPosition, this.position);
					if (d < distance) {
						distance = d;
						closestNeigbour = tileProperty;
					}
				}
			}

			if (closestNeigbour != null) {
				this.closestAdj = closestNeigbour.position;
				return true;
			}
			return false;
		}

		public static Target GetRandomTargetInRange(Vector2Int position, int range = 5) {
			Vector2Int targetPosition = new Vector2Int(
				UnityEngine.Random.Range(position.x-range, position.x+range),
				UnityEngine.Random.Range(position.y-range, position.y+range)
			);

			// Maybe do a max try and error if we reach this.
			int nbTry = 20;
			while (nbTry >= 0 && (Loki.map[targetPosition] == null || Loki.map[targetPosition].blockPath || Loki.map[targetPosition].reserved)) {
				targetPosition = new Vector2Int(
					UnityEngine.Random.Range(position.x-range, position.x+range),
					UnityEngine.Random.Range(position.y-range, position.y+range)
				);
				nbTry--;
			}

			return new Target(targetPosition);
		}
	}
}