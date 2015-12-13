using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Player : MonoBehaviour {
	
	public static Player instance;
	public float speed = 5.0f;
	bool isMoving = false;
	Vector3 movementVector = new Vector3(1,0,0);
	public GameObject playerModel;
	[HideInInspector]
	public bool gameStarted = false;
	bool isDead = false;
	Rigidbody rb;
	
	void Awake()
	{
		instance = this;
	}
	// Use this for initialization
	void Start () {
		
		rb = GetComponent<Rigidbody>();
		isDead = false; 
		 
	}
	
	public void startPlaying()
	{
		rb.useGravity = true;
		gameStarted = true;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(gameStarted && isDead == false)
		{
			if(playerModel)
				playerModel.transform.Rotate(new Vector3(0,0,1) * -200.0f * Time.deltaTime);
				
			transform.Translate(movementVector * speed * Time.deltaTime);
			
			if(isMoving == false)
			{
				if(Input.GetKeyDown(KeyCode.A))
				{
					isMoving = true;
					AudioManager.instance.playDirectionSFX();
					transform.DORotate(transform.rotation.eulerAngles + new Vector3(0,-90,0),0.25f,RotateMode.Fast).OnComplete(startMovingAgain);
				}
				if(Input.GetKeyDown(KeyCode.D))
				{
					isMoving = true;
					AudioManager.instance.playDirectionSFX();
					transform.DORotate(transform.rotation.eulerAngles + new Vector3(0,90,0),0.25f,RotateMode.Fast).OnComplete(startMovingAgain);
				}
			}
			
			//if(rb.velocity.y)
			//Debug.Log("VelocityY: "+rb.velocity.y);
			if(rb.velocity.y < - 40.0f)
			{
				isDead = true;
				rb.isKinematic = true;
				GameManager.instance.gameOver();
			}
			
		}
		
	}
	
	void startMovingAgain()
	{
		isMoving = false;
	}
	
	public void jumpForce(float force)
	{
		AudioManager.instance.playJumpSFX();
		rb.AddForce(Vector3.up * force);
	}
}
