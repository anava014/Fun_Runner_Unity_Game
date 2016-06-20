using UnityEngine;
using System.Collections;
//using playerNamespace;

public class MainCameraMultiplayer : MonoBehaviour {

	private Transform player;
	private string playerName;

	// Use this for initialization
	void Start () {
		Debug.Log ("Init Camera");
		//playerName = players.newCameraPlayerName ();
		//playerName = "Multiplayer(Clone)";
		////player = GameObject.Find (playerName).transform;
		//player = GameObject.Find ("Multiplayer").transform;
		//Debug.Log ("Camera: " + playerName);

	}
	
	// Update is called once per frame
	void Update () {
			//player = GameObject.Find (playerName).transform;
			player = GameObject.Find ("Multiplayer(Clone)").transform;
		//transform.position = new Vector3 (player.position.x + 10, 3, -1f);
		transform.position = new Vector3 (player.position.x, player.position.y, -1f);

	}
}
