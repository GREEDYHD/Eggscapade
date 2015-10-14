using UnityEngine;
using System.Collections;
using UnityEngine.Sprites;


public class ChickenCoop : MonoBehaviour 
{
	public Sprite uSprite;
	public Sprite dSprite;
	private SpriteRenderer sRenderer;
	private bool Down;
	public AudioSource source;
	public AudioClip Clip;
    public int playerCount;

	void Start ()
	{   
		sRenderer = gameObject.GetComponent<SpriteRenderer>();
		sRenderer.sprite = uSprite;
		source = GetComponent<AudioSource> ();
        playerCount = 0;
	}

    void Update ()
    {
        if (playerCount > 0)
        {
            sRenderer.sprite = dSprite;
        }
        else
        {
            sRenderer.sprite = uSprite;
        }
    }

	void OnTriggerEnter2D(Collider2D collision)
	{
		source.Play ();
        if (collision.tag == "Player")
        {
            playerCount++;
        }
	}

	void OnTriggerExit2D(Collider2D collision)
	{
		source.Stop ();
        if (collision.tag == "Player")
        {
            playerCount--;
        }
	}
}