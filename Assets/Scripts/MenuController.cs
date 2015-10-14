using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour 
{
	
	public void LoadLevel(string name)
	{
		Application.LoadLevel (name);
	}
	
	public void Quit()
	{
		Application.Quit ();
	}
	
}
