using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour 
{
    public float Speed;
    private float maxSpeed;
    private float movex = 2f;
    private float movey = 2f;
    private string Horizontal;
    private string Vertical;
    public GameObject objectEggBomb;
	public bool leaderStatus;
	public GameObject objectStar;

    public int maxEggs;
    public int numEggs;
    public int totalEggs;
    public int playerID;
    private Vector3 spawnPoint;
    Animator objectAnimator;
    private Rigidbody2D RB2D;

    public Vector2 forwardDirection;
    public float rotationAngle;
    private float targetAngle;
    public float turnSpeed;
    private bool isControlsEnabled = false;

	private float timeDelay = 0;
	private bool isDelayed = false;
	private SpriteRenderer SprRenderer;
	private bool isCarryingFishingRod = true;



    void Start()
    {
		leaderStatus = false;
        forwardDirection = new Vector2(-1, 0);
        rotationAngle = -90;//0 degrees is up (They all start looking left due to animation)
        maxSpeed = Speed;
        objectAnimator = GetComponent<Animator>();
        spawnPoint = transform.position;
        totalEggs = 0;
        RB2D = GetComponent<Rigidbody2D>();
        turnSpeed = 10;
		isControlsEnabled = true;
		SprRenderer = GetComponent<SpriteRenderer> ();
		objectStar = GameObject.FindGameObjectWithTag("Star");
    }
	
    void FixedUpdate()
    {
        if (isControlsEnabled)
        {
            movex = Input.GetAxis("HorizontalPlayer" + playerID);
            movey = Input.GetAxis("VerticalPlayer" + playerID);
            objectAnimator.SetFloat("Speed", Mathf.Abs((Mathf.Abs(movex) + Mathf.Abs(movey)) / 2));
            RB2D.velocity = new Vector2(movex * Speed, movey * Speed);
            forwardDirection = new Vector2 (-movex, -movey);

			if (Input.GetKeyDown("space") && playerID == 1)
			{
				GameObject.Instantiate(objectEggBomb,transform.position,Quaternion.identity);
			}
        }
		if (isDelayed)
		{
			Delay(timeDelay);
		}
    }

    void Update()
    {
        targetAngle = Mathf.Atan2(forwardDirection.y, forwardDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, targetAngle), turnSpeed * Time.deltaTime);
		if (leaderStatus == true)
		{
			//objectStar.transform.position = spawnPoint;//MOVE STAR?! EZ M8
			objectStar.transform.position = transform.position;
		} 
    }
	
    public void AddEgg()
    {
        Speed -= 0.25f;
        numEggs++;
    }
	
    public bool CheckEggs()
    {
        if (numEggs == maxEggs)
        {
            return true;
        } else
        {
            return false;
        }
    }
	public void SetControls(bool value)
    {
        isControlsEnabled = value;
    }

    public void BankEggs()
    {
        totalEggs = + numEggs;
        numEggs = 0;
        Speed = maxSpeed;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Torch")
        {
            ReSpawn();
			Delay(2);
        }
		//(Input.GetKeyDown("Use" + playerID) || Input.GetButtonDown("Use" + playerID)
		//				 
		//}
		//	void OnTriggerStay2D(Collider2D collider)
		//	{
		//		if (collider.name.Substring(0, collider.name.Length - 1) == "spawnPlayer" && isCarryingFishingRod)
		//		{
		//			Debug.Log ("STEAL");
		//			collider.GetComponentInParent<PlayerSpawner>().StealEggs();
		//			isCarryingFishingRod = false;
		//		}
		//	}
    }

	public void SetLeaderTrue()
	{
		leaderStatus = true;
	}

	public void SetLeaderFalse()
	{
		leaderStatus = false;
	}

	void Delay(float time)
	{
		isControlsEnabled = false;
		isDelayed = true;
		timeDelay = time;
		if (timeDelay >= 0)
		{
			SprRenderer.color =  Color.Lerp(Color.white, new Color(0,0,0,0), Time.time);
			timeDelay -= Time.fixedDeltaTime;
		}
		else
		{
			timeDelay = 0;
			isControlsEnabled = true;
			SprRenderer.color =  Color.Lerp(new Color(0,0,0,0),Color.white, Time.time);
			isDelayed = false;
			Speed = 3;
		}
	}

    public int GetID()
    {
        return playerID;
    }

    public void ReSpawn()
    {
        SetControls(false);
        numEggs = 0;
        gameObject.transform.position = spawnPoint;
        Speed = maxSpeed;
        return;
    }

    public string GetTag()
    {
        return gameObject.tag;
    }

    public int GetEggs()
    {
        return numEggs;
    }

    public int GetScore()
    {
        return totalEggs;
    }

    public int GetTotalEggs()
    {
        return totalEggs;
    }
}		