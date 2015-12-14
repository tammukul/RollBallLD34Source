using UnityEngine;
using System.Collections;

public class JumpTrigger : MonoBehaviour {
	
	public float force = 100.0f;
	
	// Use this for initialization
	void Start () {
		

		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.CompareTag("Player"))
		{
			Player.instance.jumpForce(force);
		}
	}
}
