using UnityEngine;
using System.Collections;
using UnityEngine.Sprites;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour 
{
	public Material Player1Win;
	public Material Player2Win;
	public Material Player3Win;
	public Material Player4Win;
	private Renderer mRenderer;

	public GameObject objectScoreKeeper; 
	//public int winner;
	// Update is called once per frame
	void Awake()
	{
		mRenderer = gameObject.GetComponent<Renderer> ();
		mRenderer.material = null;
	}

	void Update () 
	{

	}

	public void ActivateEndScreen()
	{
		GameObject playerWinner = objectScoreKeeper.GetComponentInParent<ScoreKeeper>().GetWinner();
	 	
		switch (playerWinner.GetComponentInParent<Movement>().GetID()) //This switches depending on the winning players ID
		{
		case 1:
			mRenderer.material = Player1Win;
			break;
		case 2:
			mRenderer.material = Player2Win;
			break;
		case 3:
			mRenderer.material = Player3Win;
			break;
		case 4:
			mRenderer.material = Player4Win;
			break;
		default:
			mRenderer.material = null;
			break;
		}
	}
    public void ActivateLeaderboard()
    {
        //Vector2 screenPosition = new Vector2(Screen.width/2 , Screen.height/2);
        mRenderer.material = null;
        //string playerName = "Player";
    }
}