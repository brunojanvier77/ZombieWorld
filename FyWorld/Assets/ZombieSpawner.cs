using Fy;
using Fy.Characters;
using Fy.Definitions;
using Fy.World;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameManager manager;
    public int MaxAmountZombieInWave = 1000;
    public int MaxAmountMinutesGame = 20;
    public int MaxAmountSecondBetweenWaves = 30;
    public int StartingNumberZombies = 5;

    private int[] arrayWaveSize;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawner());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Spawner()
    {
        int length = PrepareWaveSizes();
        for (int i = 0; i < length; i++)
        {
            yield return new WaitForSeconds(MaxAmountSecondBetweenWaves);
            SpawnWave(i);
        }
        manager.Success();
    }

    private int PrepareWaveSizes()
    {
        // a game is 20 minutes, that is 40 waves to survive.

        int length = MaxAmountMinutesGame * 60 / MaxAmountSecondBetweenWaves;
        float ratio = Mathf.Pow((float)(MaxAmountZombieInWave) / (float)(StartingNumberZombies), 1.0f / ((float)length - 1.0f));
        arrayWaveSize = new int[length];

        for (int i = 0; i < length; i++)
        {
            arrayWaveSize[i] = (int)(StartingNumberZombies * Mathf.Pow(ratio, (float)i));
        }

        return length;
    }

    void SpawnWave(int lvl)
    {
        int nbZombies = arrayWaveSize[lvl];
        while (nbZombies >= 0)
        {
            Vector2Int position = new Vector2Int(Random.Range(0, manager.mapSize.x), Random.Range(0,manager.mapSize.y));
            TileProperty tileProperty = Loki.map[position];
            if (tileProperty != null && !tileProperty.blockPath)
            {
                Loki.map.SpawnZombie(new Zombie(position, Defs.animals["zombie"]));
                nbZombies--;
            }
        }
    }
}
