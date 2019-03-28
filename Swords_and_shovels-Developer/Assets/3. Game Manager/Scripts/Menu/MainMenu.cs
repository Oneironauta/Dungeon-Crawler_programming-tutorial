using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

	// Funciones que puedan recibir animation events
	// Funciones para detonar las animaciones de fade in/out

	// Track the aAnimation Component
	[SerializeField] private Animation _mainMenuAnimator;
	// Track the AnimationClips for fade in/out
	[SerializeField] private AnimationClip _fadeOutAnimation;
	[SerializeField] private AnimationClip _fadeInAnimation;

	void Start(){

		GameManager.Instance.OnGameStateChanged.AddListener(HandleGameStateChange);
	}
	
	//No todas las transiciones de estado son iguales, para eso hay que saber el estado del que venimos y al que vamos
	void HandleGameStateChange(GameManager.GameState currentState, GameManager.GameState previousState){
		if(previousState == GameManager.GameState.PREGAME && currentState == GameManager.GameState.RUNNING){

			FadeOut();
		}
	}
	public void OnFadeOutComplete(){
		Debug.LogWarning("FadeOut Complete");
	}

	public void OnFadeInComplete(){
		Debug.LogWarning("FadeIn Complete");

		UIManager.Instance.SetDummyCameraActive(true);
	}
	
	public void FadeIn(){

		_mainMenuAnimator.Stop();
		_mainMenuAnimator.clip = _fadeInAnimation;
		_mainMenuAnimator.Play();
	}

	public void FadeOut(){

		UIManager.Instance.SetDummyCameraActive(false);

		_mainMenuAnimator.Stop();
		_mainMenuAnimator.clip = _fadeOutAnimation;
		_mainMenuAnimator.Play();
	}

	
}
