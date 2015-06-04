using UnityEngine;
using System.Collections;

public class BeeGrenade : Projectile {

	public GameObject bee;
	public float delay;
	public int beesToSpawn;
	public float beeSpawnRate;

	private int beesSpawned;
	private float spawnTime;

	private float lastBeeSpawnTime;
	private GameObject[] spawnedBees;

	new void Start() {
		beesSpawned = 0;
		spawnTime = Time.time;
		spawnedBees = new GameObject[beesToSpawn];
	}

	new void Update (){
		if ((spawnTime + delay) < Time.time) {
			if( beesSpawned < beesToSpawn && (lastBeeSpawnTime + beeSpawnRate) < Time.time){
				spawnedBees[beesSpawned] = (GameObject) Instantiate (bee, transform.position, Quaternion.identity);
				spawnedBees[beesSpawned].GetComponent<HomingBee> ().SetOwner (owner);
				beesSpawned++;
				lastBeeSpawnTime = Time.time;
			} else if( beesSpawned >= beesToSpawn ){
				foreach (GameObject bee in spawnedBees){
					bee.GetComponent<HomingBee>().Arm();
				}
				Destroy(gameObject);
			}
		}
	}
}
