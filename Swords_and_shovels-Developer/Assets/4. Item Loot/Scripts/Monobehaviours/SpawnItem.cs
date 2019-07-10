using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour, ISpawns {

	public ItemPickUps_SO[] itemDefinitions;

	private int wichToSpawn = 0;
	private int totalSpawnWeight = 0;
	private int chosen = 0;

	public Rigidbody itemSpawned { get; set;}
	public Renderer itemMaterial { get; set;}
	public ItemPickUp itemType { get; set;}
	// Use this for initialization
	void Start () {
		foreach (ItemPickUps_SO ip in itemDefinitions)
		{
			//Creamos una lista de números en el que cada item toma la cantidad de números correspontientes a su peso
			//Como boletos en una rifa
			totalSpawnWeight += ip.spawnChanceWeight;
		}
	}

	public void CreateSpawn(){
		//Spawn with weighted possibilities
		foreach (ItemPickUps_SO ip in itemDefinitions)
		{
			wichToSpawn += ip.spawnChanceWeight;
			if (wichToSpawn >= chosen)
			{
				itemSpawned = Instantiate(ip.itemSpawnObject, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
				
				itemMaterial = itemSpawned.GetComponent<Renderer>();
				itemMaterial.material = ip.itemMaterial;

				itemType = itemSpawned.GetComponent<ItemPickUp>();
				itemType.itemDefinition = ip;
				break;// En caso de encontrar un item para instanciar dejamps de buscar
			}
		}
	}
	
}
