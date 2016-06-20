using UnityEngine;
using System.Collections;

public class coinScript : MonoBehaviour {
	
	public static int coins = 0; 
	// Use this for initialization
	
	void Start () {
		coins = PlayerPrefs.GetInt ("Coins", coins); 
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.CompareTag ("Player")){
			Destroy(gameObject);
			coins++; 
		}
		PlayerPrefs.SetInt ("Coins", coins); 
	}
	
	void OnGUI(){
		GUI.color = Color.gray; 
		GUI.skin.box.fontStyle = FontStyle.Bold;
		GUI.skin.label.fontSize = 20;	
		GUI.Label(new Rect(50, 50, 400, 50), "Coins: " + coins);
	}
	
	
	
}
