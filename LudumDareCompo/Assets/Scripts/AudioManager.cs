using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {
	
	public AudioClip placedSound;
	public AudioClip jumpSound;
	public AudioClip directionSound;
	AudioSource asrc;
	public static AudioManager instance;
	void Awake()
	{
		instance = this;
		asrc = GetComponent<AudioSource>();
	}
	public void playDirectionSFX()
	{
		asrc.PlayOneShot(directionSound,0.8f);
	}
	public void playPlacedSFX()
	{
		asrc.PlayOneShot(placedSound,0.1f);
	}
	
	public void playJumpSFX()
	{
		asrc.PlayOneShot(jumpSound,0.7f);
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
