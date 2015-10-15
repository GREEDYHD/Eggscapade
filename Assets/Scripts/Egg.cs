using UnityEngine;
using System.Collections;

public class Egg : MonoBehaviour
{
    public bool isSpawned;
    public Sprite eggSprite;
    public Sprite nullSprite;
    private Vector3 spawnPoint;
    private bool isCarryingMaxEggs;
    private SpriteRenderer sRenderer;
	
    void Start()
    {
        sRenderer = gameObject.GetComponent<SpriteRenderer>();
        sRenderer.sprite = nullSprite;
        spawnPoint = gameObject.transform.position;
        isSpawned = false;
    }

    public void Spawn()
    {
        if (!isSpawned)
        {
            isSpawned = true;
            transform.position = spawnPoint;
            sRenderer.sprite = eggSprite;
        } 
    }

    public void DeSpawn()
    {
        isSpawned = false;
        sRenderer.sprite = nullSprite;
    }

    public bool GetState()
    {
        return isSpawned;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (isSpawned)
        {
			if (collider.GetComponentInParent<Movement>().GetTag() == "Player" && !collider.GetComponentInParent<Movement>().CheckEggs())
            {
                collider.GetComponentInParent<Movement>().AddEgg();
                DeSpawn();
            }
        }		
    }
}