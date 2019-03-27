using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Esta clase está hecha para crear una sola instancia del GameManager que recibe
//Hereda únicamente de las otras clases identicas tipo Singleton que manejen el mismo tipo de clase <T>
public class Singleton<T> : MonoBehaviour where T : Singleton<T>{

	private static T instance;

	//[Accesor] Para hacer esta clase de solo lectura omitimos el "set"
	//Protege internamente y comparte con el exterior
	public static T Instance{

		get{return instance; }
	}
	public static bool IsInitialized{
		get{ return instance != null; }
	}

	//Método protegido y virtual para poder acceder a él y sobreescribirlo desde otra clase que extienda de Singleton
	protected virtual void Awake(){

		if(instance != null){
			Debug.LogError("[Singleton] Tratando de duplicar la instancia de la clase Singleton");
		}
		else{
			instance = (T) this;
		}
	}

	protected virtual void OnDestroy(){

		if (instance == this)
		{
			instance = null;
		}
	}
}
