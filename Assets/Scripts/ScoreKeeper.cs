using UnityEngine;
using System.Collections;

public class ScoreKeeper : MonoBehaviour
{
	public GameObject[] objectPlayers;
	private int[] scorePlayers;


	void Start()
	{
		objectPlayers = GameObject.FindGameObjectsWithTag ("Player");
		scorePlayers = new int[4]; //Contains players scores in the player number order
		GetPlayerScores();
	}

	void Update()
	{
		GetPlayerScores();
	}

	void GetPlayerScores()
	{
		for (int i = 0; i < objectPlayers.Length; i++)
		{
			scorePlayers[i] = objectPlayers[i].GetComponentInParent<Movement>().GetScore(); //Stores player scores in the player score array
		}
	}

	public GameObject GetWinner()
	{
		int winningScore =  Mathf.Max(scorePlayers[0], Mathf.Max(scorePlayers[1], Mathf.Max(scorePlayers[2], scorePlayers[3]))); // compares and returns the highest score
		for (int i = 0; i < objectPlayers.Length; i++)
		{
			if (winningScore == (objectPlayers[i].GetComponentInParent<Movement>().GetScore())) //matches the highest score to the correct player
			{
				Debug.Log("Player " + objectPlayers[i].GetComponentInParent<Movement>().GetID() + " wins");
				return objectPlayers[i]; //Winning player
			}
		}
		return null;
	}

    void GetCurrentLeader()
    {

    }
}
