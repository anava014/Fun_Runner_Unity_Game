using UnityEngine;
using System.Collections;

public class Volume : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		Debug.Log ("Volume = " + PlayerPrefs.GetInt ("soundOption"));
		if (PlayerPrefs.GetInt ("soundOption") == 0) {
			gameObject.GetComponent<AudioSource>().volume = 0.0f;
		} else {
			gameObject.GetComponent<AudioSource>().volume = 1.0f;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
