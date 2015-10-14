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
	
    // Update is called once per frame

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
    }
}
