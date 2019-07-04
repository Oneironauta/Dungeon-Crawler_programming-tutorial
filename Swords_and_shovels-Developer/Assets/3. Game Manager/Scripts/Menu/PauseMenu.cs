using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

	[SerializeField] private Button ResumeButton;
	[SerializeField] private Button RestartButton;
	[SerializeField] private Button QuitButton;

	private void Start(){

		ResumeButton.onClick.AddListener(HandheldResumeClicked);
		RestartButton.onClick.AddListener(HandheldRestartClicked);
		QuitButton.onClick.AddListener(HandheldQuitClicked);
	}

	void HandheldResumeClicked(){

		GameManager.Instance.TogglePause();
	}

	void HandheldRestartClicked(){

		GameManager.Instance.RestartGame();
	}

	void HandheldQuitClicked(){

		GameManager.Instance.QuitGame();
	}
}
