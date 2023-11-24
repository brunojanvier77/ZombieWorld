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

namespace Fy.Helpers {
	public static class Utils {
		public static float Normalize(float min, float max, float value) {
			return (value - min) / (max - min);
		}

		public static float Distance(Vector2Int a, Vector2Int b) {
			if (
				Mathf.Abs(a.x - b.x) + Mathf.Abs(a.y - b.y) == 1
			) {
				return 1f;
			}

			if (
				Mathf.Abs(a.x - b.x) == 1 && 
				Mathf.Abs(a.y - b.y) == 1
			) {
				return 1.41121356237f;
			}

			return Mathf.Sqrt(
				Mathf.Pow((float)a.x-(float)b.x, 2) +
				Mathf.Pow((float)a.y-(float)b.y, 2)				
			);
		}

		public static Vector2Int generatePositionFarFromCenter(int mapWidth, int mapHeight)
		{
			System.Random rand = new System.Random(Environment.TickCount);
			double u1 = rand.NextDouble(); 

			if(u1 < 0.25)
            {
				return new Vector2Int(1, UnityEngine.Random.Range(0,mapHeight));
			}
			else if(u1 < 0.5)
			{
				return new Vector2Int(mapWidth-2, UnityEngine.Random.Range(0, mapHeight));

			}
			else if (u1 < 0.75)
			{
				return new Vector2Int(UnityEngine.Random.Range(0, mapWidth), mapHeight - 2 );

			}
			return new Vector2Int(UnityEngine.Random.Range(0, mapWidth), 1);
		}

}
}