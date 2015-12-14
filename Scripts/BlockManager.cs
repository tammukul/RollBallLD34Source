using UnityEngine;
using System.Collections;

public class BlockManager : MonoBehaviour {
	
	public static BlockManager instance;
	public GameObject[] blocks;
	[HideInInspector]
	public Vector3 lastBlock;
	public GameObject smokeParticle;
	bool firstBlockplaced = false;
	void Awake()
	{
		instance = this;
	}
	// Use this for initialization
	void Start () {
		
		//spawnNewBlock();
		
	}
	
	public void spawnNewBlock()
	{
		if(firstBlockplaced == false)
		{
			firstBlockplaced = true;
			//First block
			Instantiate(blocks[0],Vector3.zero,Quaternion.identity);
		}
		else
		{
			Instantiate(blocks[Random.Range(0,blocks.Length)],lastBlock + new Vector3(Mathf.Round(lastBlock.normalized.x),0,Mathf.Round(lastBlock.normalized.z)),Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
