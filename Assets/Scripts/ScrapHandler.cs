using UnityEngine;
using System.Collections;

public class ScrapHandler : MonoBehaviour {
	public int scrap;
	
	public void AddScrap (int amount){
		scrap += amount;
	}
}
