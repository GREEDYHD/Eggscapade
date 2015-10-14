using UnityEngine;
using System.Collections;

public class MoviePlay : MonoBehaviour {
	public MovieTexture movTexture;
	public AudioSource movAudio;
	public Countdown countdown;

	void Start(){
		PlayMovie ();
	}
	public void PlayMovie(){
		countdown.hasVideoStarted = true;
		movTexture.Play ();
		movAudio.Play ();
	}

}
