//using UnityEngine;
//using System.Collections;
//  
//public class PlayerManager : MonoBehaviour
//{
//	private Vector2 movementVector;
//
//	public float Speed = 8;
//		  
//	void Start ()
//	{
//
//	}
//		  
//	void FixedUpdate ()
//	{
//		movementVector.x = Input.GetAxis ("P1_PAD_X") * Speed;
//		movementVector.y = Input.GetAxis ("P1_PAD_Y") * Speed;
//
////		movementVector.x = Input.GetAxis ("P1_KEY_X") * Speed;
////		movementVector.y = Input.GetAxis ("P1_KEY_Y") * Speed;
//
//		GetComponent<Rigidbody2D> ().velocity = movementVector;
//		Debug.Log(movementVector);			 
//
//		if (Input.GetButtonDown("P1_PAD_BUTTON_A")) 
//		{
//			GetComponent<SpriteRenderer> ().sprite = null;
//		}
//	} 
//}