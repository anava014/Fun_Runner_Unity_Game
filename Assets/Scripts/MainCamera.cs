using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {

	private Transform player;
	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetString ("skin") == "pink") {
			GameObject.Find ("yellowPlayer").SetActive (false);
			GameObject.Find ("Player").SetActive (false);
			player = GameObject.Find ("pinkPlayer").transform;
		} else if (PlayerPrefs.GetString ("skin") == "yellow") {
			GameObject.Find ("pinkPlayer").SetActive (false);
			GameObject.Find ("Player").SetActive (false);
			player = GameObject.Find ("yellowPlayer").transform;
		} else {
			GameObject.Find ("yellowPlayer").SetActive (false);
			GameObject.Find ("pinkPlayer").SetActive (false);
			player = GameObject.Find ("Player").transform;
		}

	}
	
	// Update is called once per frame
	void Update () {
		//player = GameObject.Find (skinManager.returnCurrentSkin ()).transform;
		transform.position = new Vector3 (player.position.x+10, 3, -1f);
	}
}
