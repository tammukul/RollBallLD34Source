using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Block : MonoBehaviour {
	
	Transform[] individualBlocks;
	int tIterator = 0;
	// Use this for initialization
	void Start () {
		
		individualBlocks = transform.GetComponentsInChildren<Transform>();
		startPlacing();
		tIterator = 0;
		Destroy(gameObject,20.0f);
		
		for(int i=0;i<individualBlocks.Length;i++)
		{
			if(individualBlocks[i].GetComponent<Collider>())
				individualBlocks[i].GetComponent<Collider>().enabled = false;
		}
		
	}
	
	void startPlacing()
	{
		float delayTime = 0;
		int randomNumber = 0;
		Vector3 originalPosition;
		BlockManager.instance.lastBlock = individualBlocks[individualBlocks.Length - 1].position;
		for(int i=1;i<individualBlocks.Length;i++)
		{
			Vector3 temp = individualBlocks[i].position;
			originalPosition = temp;
			randomNumber = Random.Range(0,2);
			if(randomNumber == 0)
			{
				temp.z += 50.0f;
				temp.y = Random.Range(-50,50);
				individualBlocks[i].position = temp;
				individualBlocks[i].DOMove(originalPosition,1.5f).SetDelay(delayTime).OnComplete(createSmoke);
				delayTime += 0.13f;
			}
			if(randomNumber == 1)
			{
				temp.z -= 50.0f; 
				temp.y = Random.Range(-50,50);
				individualBlocks[i].position = temp;
				individualBlocks[i].DOMove(originalPosition,1.5f).SetDelay(delayTime).OnComplete(createSmoke);
				delayTime += 0.13f;
			}
		}
	}
	
	void createSmoke()
	{
		if(individualBlocks[tIterator].GetComponent<Collider>())
			individualBlocks[tIterator].GetComponent<Collider>().enabled = true;
		
		AudioManager.instance.playPlacedSFX();
			
		GameObject ps = Instantiate(BlockManager.instance.smokeParticle,individualBlocks[tIterator].position,Quaternion.identity) as GameObject;
		tIterator ++;
		Destroy(ps,1.5f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
