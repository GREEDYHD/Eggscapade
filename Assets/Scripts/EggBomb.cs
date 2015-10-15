using UnityEngine;
using System.Collections;

public class EggBomb : MonoBehaviour
{
    public float bombTimer = 10;
    private SpriteRenderer SR;
    private bool isBombExploded = false;

   	void Start ()
    {
        SR = gameObject.GetComponent<SpriteRenderer>();
	}

	void FixedUpdate ()
    {
        bombTimer -= Time.deltaTime;
        SR.color =  Color.Lerp(Color.white, Color.red, Time.time / bombTimer * 0.2f);
        if (bombTimer < 0)
        {
            if(!isBombExploded)
            {
                isBombExploded = true;
            }
            else
            {
                Destroy(gameObject);
            }
        }
	}
   
    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.tag == "Player" && isBombExploded)
        {
            collider.GetComponentInParent<Movement>().ReSpawn();
            Destroy(gameObject);
            Debug.Log("Player " + collider.tag + "hit by bomb");
        }
		if (collider.tag == "Egg" && isBombExploded)
		{
			collider.GetComponentInParent<Egg>().DeSpawn();
			Destroy(gameObject);
			Debug.Log("Player " + collider.tag + "hit by bomb");
		}
    }
}