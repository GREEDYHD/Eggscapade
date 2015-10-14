using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartGame : MonoBehaviour {

	public GameObject MainMenuPanel;
	public GameObject OptionPanel;
	public GameObject QuitGamePanel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartGameButton()
	{
		Application.LoadLevel ("main");
		//MainMenuPanel.SetActive (false);
	}
	public void OptionButton()
	{
		MainMenuPanel.SetActive (false);
		OptionPanel.SetActive (true);
	}

	public void QuitGameButton()
	{
		MainMenuPanel.SetActive (false);
		OptionPanel.SetActive (false);
		QuitGamePanel.SetActive (true);
	}

	public void BackToMainMenuButton()
	{
		MainMenuPanel.SetActive (true);
		OptionPanel.SetActive (false);
		QuitGamePanel.SetActive (false);

	}

	public void HardBoiledButton ()
	{
		MainMenuPanel.SetActive (false);

		//Application.LoadLevel("HardBoiled");

	}

	public void ExitGame ()
	{
			Application.Quit();
	}
}
