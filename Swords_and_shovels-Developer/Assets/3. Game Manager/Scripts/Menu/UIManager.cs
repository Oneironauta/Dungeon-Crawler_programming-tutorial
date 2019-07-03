using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager> {

	[SerializeField] private MainMenu _mainMenu;
	[SerializeField] private PauseMenu _pauseMenu;
	[SerializeField] private Camera _dummyCamera;

	void Start(){

		GameManager.Instance.OnGameStateChanged.AddListener(HandleGameStateChange);
	}

	void HandleGameStateChange(GameManager.GameState currentState, GameManager.GameState previousState){
		
		_pauseMenu.gameObject.SetActive(currentState == GameManager.GameState.PAUSED);
	}

	private void Update(){

		if(GameManager.Instance.CurrentGameState != GameManager.GameState.PREGAME){
			return;
		}
		if (Input.GetKeyDown(KeyCode.Space))
		{
			GameManager.Instance.StartGame();
		}
	}

	public void SetDummyCameraActive(bool active){

		_dummyCamera.gameObject.SetActive(active);
	}
}
