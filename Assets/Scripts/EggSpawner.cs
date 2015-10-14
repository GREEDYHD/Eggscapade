using UnityEngine;
using System.Collections;

public class EggSpawner : MonoBehaviour
{
	public GameObject[] pEggs;
	private int spawnCount;
	public int spawnRate;
	public float spawnChance;
	public int spawnMax;
	private int currentEgg;
	private int temp;

	// Use this for initialization
	void Start ()
	{
		pEggs = GameObject.FindGameObjectsWithTag ("Egg");
		spawnCount = 0;
		spawnMax = (2 * pEggs.Length) / 5;
		spawnRate = 10; //TimeBetween Spawning
		spawnChance = 2; //Spawm Percent
		currentEgg = 0;
		SpawnEggs();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (CountEggs () < spawnMax)
		{
			SpawnEggs();
		}
	}

	int CountEggs()
	{
		for (int i = 0; i < pEggs.Length; i++)
		{
			if (pEggs[i].GetComponentInParent<Egg>().GetState())
			{
				temp += 1;
			}
		}
		spawnCount = temp;
		temp = 0;
		return spawnCount;
	}
	void SpawnEggs()
	{
		for (int i = currentEgg; i < pEggs.Length; i++)
		{
			currentEgg++;
			float rand = Random.Range(0,10000);
			if ((1 + rand % 100000) < spawnChance)
			{
				pEggs[currentEgg - 1].GetComponentInParent<Egg>().Spawn();
				spawnCount++;
			}
			currentEgg = currentEgg == pEggs.Length ? 0 : currentEgg;
		}
		return;
	}
}
