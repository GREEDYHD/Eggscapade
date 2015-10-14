//using UnityEngine;
//using System.Collections;
//
//public class ControllerInterface : MonoBehaviour
//{
//	public float xMovement;
//	public float yMovement;
//
//	private GameObject[] playerList;
//
//	void Start ()
//	{
//		playerList = GameObject.FindGameObjectsWithTag("Player");
//	}
//
//	void Update ()
//	{
//		for (int i = 0; i < playerList.Length; i++)
//		{
//			xMovement = Input.GetAxis("HorizontalPlayer" + (i + 1));
//			yMovement = Input.GetAxis ("VerticalPlayer" + (i + 1));
//			if(xMovement != 0 || yMovement != 0)
//			{
//				playerList[i].GetComponentInParent<Movement>().Move(xMovement, yMovement);
//			}
//		}
//	}
//}