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
	public GameObject star;

    private string[] controlScheme;

    private string controlLeft;
    private string controlRight;
    private string controlUp;
    private string controlDown;
    private string controlThrow;
    private string controlDrop;

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
        isControlsEnabled = false;
    }
	
    void FixedUpdate()
    {
        //if (isControlsEnabled)
        {
            movex = Input.GetAxis("HorizontalPlayer" + playerID);
            movey = Input.GetAxis("VerticalPlayer" + playerID);
            objectAnimator.SetFloat("Speed", Mathf.Abs((Mathf.Abs(movex) + Mathf.Abs(movey)) / 2));
            RB2D.velocity = new Vector2(movex * Speed, movey * Speed);
            forwardDirection = new Vector2 (-movex, -movey);
        }
        if (Input.GetKeyDown("space") && playerID == 1)
        {
            GameObject.Instantiate(objectEggBomb,transform.position,Quaternion.identity);
        }
    }

    void Update()
    {
        targetAngle = Mathf.Atan2(forwardDirection.y, forwardDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, targetAngle), turnSpeed * Time.deltaTime);
		if (leaderStatus == true) {
			//MOVE STAR?!
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
        }       
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