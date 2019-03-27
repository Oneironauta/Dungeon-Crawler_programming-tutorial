using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager> {

	// Revisar en qué nivel estamos
	// load and unload game levels
	// revisar en qué estado de juego estamos
	// generar otros persistent systems

	public GameObject[] SystemPrefabs;

	List<GameObject> _instancedSystemPrefabs;
	List<AsyncOperation> _loadOperations;
	private string _currentLevelName = string.Empty;

	private void Start(){

		DontDestroyOnLoad(gameObject);//para asegurar que nuestro game manager permanecerá siempre

		_instancedSystemPrefabs = new List<GameObject>();
		_loadOperations = new List<AsyncOperation>();

		InstantiateSystemPrefabs();
		LoadLevel("Main");
	}

	//Llenamos la lista de SystemPrefabs con todas las instancias
	void InstantiateSystemPrefabs(){

		GameObject prefabInstance;
		for (int i = 0; i < SystemPrefabs.Length; ++i)
		{
			prefabInstance = Instantiate(SystemPrefabs[i]);
			_instancedSystemPrefabs.Add(prefabInstance);
		}
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

	protected override void OnDestroy(){

		base.OnDestroy();

		for (int i = 0; i < _instancedSystemPrefabs.Count; i++)
		{
			Destroy(_instancedSystemPrefabs[i]);
		}
		_instancedSystemPrefabs.Clear();
	}
}
