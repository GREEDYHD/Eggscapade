using UnityEngine;
using System.Collections;

public class PlayerSpawner : MonoBehaviour
{
    public int spawnID;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (spawnID == collider.GetComponentInParent<Movement>().GetID() && collider.GetComponentInParent<Movement>().GetEggs() != 0)//If player of correct ID collides with me and they're carrying eggs then bank their eggs
        {
			Debug.Log("Player" + collider.GetComponentInParent<Movement>().GetID() + " Banked " + collider.GetComponentInParent<Movement>().GetEggs() + " Eggs");
            collider.GetComponentInParent<Movement>().BankEggs();	
        }
    }

	public void StealEggs()
	{
		Instantiate(new Egg(), transform.position, Quaternion.identity);
		Debug.Log("Eggs Banked");
	}
}