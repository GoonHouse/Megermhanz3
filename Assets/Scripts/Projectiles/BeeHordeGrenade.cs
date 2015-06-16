using UnityEngine;
using System.Collections;

public class BeeHordeGrenade : Projectile {

	public GameObject horde;
	public GameObject bee;
	public float delay;
	public int beesToSpawn;
	public float beeSpawnRate;
	
	private int beesSpawned;
	private float spawnTime;

	private bool spawnedHordeYet;
	private GameObject myHorde;
	
	private float lastBeeSpawnTime;
	
	new void Start() {
		beesSpawned = 0;
		spawnTime = Time.time;
		spawnedHordeYet = false;
	}
	
	new void Update (){
		if ((spawnTime + delay) < Time.time) {
			if(!spawnedHordeYet){
				myHorde = (GameObject) Instantiate (horde, transform.position, Quaternion.identity);
				BeeHorde bh = myHorde.GetComponent<BeeHorde>();
				bh.SetOwner(this.owner);
				bh.Init(beesToSpawn);
				spawnedHordeYet = true;
			}
			if( beesSpawned < beesToSpawn && (lastBeeSpawnTime + beeSpawnRate) < Time.time){
				GameObject theBee = (GameObject) Instantiate (bee, transform.position, Quaternion.identity);
				HordeBee hb = theBee.GetComponent<HordeBee> ();
				hb.SetOwner (owner);
				hb.SetHorde (myHorde);
				beesSpawned++;
				lastBeeSpawnTime = Time.time;
			} else if( beesSpawned >= beesToSpawn ){
				myHorde.GetComponent<BeeHorde>().Arm();
				Destroy(gameObject);
			}
		}
	}
}
