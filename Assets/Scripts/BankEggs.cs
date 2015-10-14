using UnityEngine;
using System.Collections;

public class BankEggs : MonoBehaviour
{
    public int spawnID;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (spawnID == collider.GetComponentInParent<Movement>().GetID() && collider.GetComponentInParent<Movement>().GetEggs() != 0)//If player of correct ID collides with me and they're carrying eggs then bank their eggs
        {
            collider.GetComponentInParent<Movement>().BankEggs();	
            Debug.Log("Eggs Banked");
        }
    }
}