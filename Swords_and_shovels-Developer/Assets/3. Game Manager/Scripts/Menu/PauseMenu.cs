﻿using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

	[SerializeField] private Button ResumeButton;
	[SerializeField] private Button RestartButton;
	[SerializeField] private Button QuitButton;

	private void Start(){

		ResumeButton.onClick.AddListener(HandheldResumeClicked);
	}

	void HandheldResumeClicked(){

		GameManager.Instance.TogglePause();
	}
}
