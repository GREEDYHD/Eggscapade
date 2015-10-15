using UnityEngine;
using System.Collections;

public class EnemyAI_Patrol : MonoBehaviour
{

    public Transform[] Waypoints;
    public float Speed;
    public int curWayPoint;
    public bool doPatrol = true;
    public Vector3 Target;
    public Vector3 MoveDirection;
    public Vector3 Velocity;
    public Vector3 TargetPosition;
	public float turnSpeed = 100;

    void Update()
    {
        if (curWayPoint < Waypoints.Length)
        {
            Target = Waypoints [curWayPoint].position;
            MoveDirection = Target - transform.position;
            Velocity = GetComponent<Rigidbody>().velocity;

            if (MoveDirection.magnitude < 0.1f)
            {
                curWayPoint++;
            } 
            else
            {
                Velocity = MoveDirection.normalized * Speed;
            }
        } else
        {
            if (doPatrol)
            {
                curWayPoint = 0;
            } else
            {
                Velocity = Vector3.zero;
            }
        }

        GetComponent<Rigidbody>().velocity = Velocity;
	
        //get the farmer to look at the current waypoint.
        float angle = Mathf.Atan2(MoveDirection.y, MoveDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

//		float targetAngle = Mathf.Atan2(MoveDirection.y, MoveDirection.x) * Mathf.Rad2Deg;
//		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, targetAngle), turnSpeed * Time.deltaTime);
    }
}
