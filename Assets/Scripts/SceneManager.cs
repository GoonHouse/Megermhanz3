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
		ScrapHandler sh = playerToWatch.GetComponent<ScrapHandler> ();
		string playerStatus = playerToWatch.name + "\n( " + hh.hp.ToString () + " / " + hh.maxHP.ToString () + " )";
		playerStatus += " [ " + playerToWatch.weapon.ammo + " / " + playerToWatch.weapon.maxAmmo + " ] ";
		playerStatus += "\nScrap: " + sh.scrap;
		playerStatusText.text = playerStatus;

		TargetHandler th = playerToWatch.GetComponent<TargetHandler> ();
		if (th != null && th.GetTarget() != null) {
			HurtHandler thh = th.GetTarget().GetComponent<HurtHandler> ();
			targetStatusText.text = th.GetTarget().name + "\n( " + thh.hp.ToString () + " / " + thh.maxHP.ToString () + " )";
		} else {
			targetStatusText.text = "NO TARGET";
		}
	}
}
