using UnityEngine;
using UnityEngine.UI; 
using System.Collections;

public class ToggleMusic : MonoBehaviour {
	
	public Toggle bgMusic;  
	
	// Use this for initialization
	void Start () {
		//soundOption = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (bgMusic.isOn) {
			PlayerPrefs.SetInt ("soundOption", 1); 
		} else if (!bgMusic.isOn)
			PlayerPrefs.SetInt ("soundOption", 0);
	}
}
