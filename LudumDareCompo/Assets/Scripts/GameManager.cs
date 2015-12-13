using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {
	
	public static GameManager instance;
	public enum GameStates
	{
		Menu,
		GameScene,
		GameOver
	};
	
	public GameObject mainmenuPanel;
	public GameObject gameOverPanel;
	public GameObject gameScenePanel;
	
	public Text score;
	int points;
	bool gameRunning = false;
	public Text finalScore;
	void Awake()
	{
		instance = this;
	}
	
	// Use this for initialization
	void Start () {
		
		Time.timeScale = 1.2f;
		switchUI(GameStates.Menu);
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(gameRunning)
		{
			points += 1;
			score.text = "Score : "+points;
		}
		
	}
	
	public void startButtonPressed()
	{
		Invoke("startGame",2.5f);
		switchUI(GameStates.GameScene);
		BlockManager.instance.spawnNewBlock();
	}
	
	void startGame()
	{
		Player.instance.startPlaying();
		gameRunning = true;
	}
	
	void showmainmenu()
	{
		mainmenuPanel.SetActive(true);
	}
	public void switchUI(GameStates state)
	{
		
		mainmenuPanel.SetActive(false);
		gameOverPanel.SetActive(false);
		gameScenePanel.SetActive(false);
		
		switch(state)
		{
			case GameStates.Menu:
			mainmenuPanel.SetActive(true);
			//Invoke("showmainmenu",3.5f);
			break;
			
			case GameStates.GameOver:
			gameOverPanel.SetActive(true);
			break;
			
			case GameStates.GameScene:
			gameScenePanel.SetActive(true);
			break;
			
			default:
			break;
		}
		
	}
	
	public void gameOver()
	{
		gameRunning = false;
		switchUI(GameStates.GameOver);
		finalScore.text = "Score : "+points;
	}
	
	public void restartButtonPressed()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
