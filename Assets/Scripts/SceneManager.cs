using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour {

	public Player playerToWatch;
	public Text playerStatusText;
	public Text targetStatusText;

	// Use this for initialization
	void Start () {
		playerStatusText.text = "I love videogames.";
		targetStatusText.text = "I love videogames.";
	}
	
	// Update is called once per frame
	void Update () {
		HurtHandler hh = playerToWatch.GetComponent<HurtHandler> ();
		string playerStatus = playerToWatch.name + "\n( " + hh.hp.ToString () + " / " + hh.maxHP.ToString () + " )";
		playerStatus += " [ " + playerToWatch.weapon.ammo + " / " + playerToWatch.weapon.maxAmmo + " ] ";
		playerStatus += "\nScrap: " + playerToWatch.GetComponent<Player>().GetJib ();
		playerStatusText.text = playerStatus;

		TargetHandler th = playerToWatch.GetComponent<TargetHandler> ();
		if (th != null && th.target != null) {
			HurtHandler thh = th.target.GetComponent<HurtHandler> ();
			targetStatusText.text = th.target.name + "\n( " + thh.hp.ToString () + " / " + thh.maxHP.ToString () + " )";
		} else {
			targetStatusText.text = "NO TARGET";
		}
	}
}
