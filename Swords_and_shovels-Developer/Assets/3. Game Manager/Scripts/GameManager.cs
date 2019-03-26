using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	// Revisar en qué nivel estamos
	// load and unload game levels
	// revisar en qué estado de juego estamos
	// generar otros persistent systems

	private string _currentLevelName = string.Empty;

	List<AsyncOperation> _loadOperations;

	private void Start(){

		DontDestroyOnLoad(gameObject);//para asegurar que nuestro game manager permanecerá siempre
		_loadOperations = new List<AsyncOperation>();
		LoadLevel("Main");
	}

	void OnLoadOperationComplete(AsyncOperation ao){
		
		if (_loadOperations.Contains(ao))
		{
			_loadOperations.Remove(ao);
			// mandar mensajes
			// hacer transición de escenas
		}
		Debug.Log("Load complete.");
	}

	void OnUnLoadOperationComplete(AsyncOperation ao){
		
		Debug.Log("Unload complete.");
	}

	public void LoadLevel(string levelName){
		//Usamos la operación asyncrona para que haya ciertas operaciónes corriendo en segundo plano
		AsyncOperation ao = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);
		if(ao == null){
			Debug.Log("[GameManager] Unable to load level " + levelName);
			return;
		}
		ao.completed += OnLoadOperationComplete;
		_loadOperations.Add(ao);
		_currentLevelName = levelName;
	}

	public void UnloadLevel(string levelName){

		AsyncOperation ao = SceneManager.UnloadSceneAsync(levelName);
		if(ao == null){
			Debug.Log("[GameManager] Unable to unload level " + levelName);
			return;
		}
		ao.completed += OnUnLoadOperationComplete;
	}
}
