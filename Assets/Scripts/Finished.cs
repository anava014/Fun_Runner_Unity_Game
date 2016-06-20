using UnityEngine;
using System.Collections;

public class Finished : MonoBehaviour {
	
	void Start()
	{
		DisplayTime.resetTime();
	}
	
	void OnGUI()
	{
		string message = "Highest Score for this level: " + DisplayHighScore.return_highscore();
		message = message + "\n Your score: " + DisplayHighScore.format(DisplayTime.playtime);
		message = message + "\n Your total amount of coins: " + coinScript.coins;
		
		GUI.color = Color.black;
		GUI.Label(new Rect(150, 120, 400, 500), message);
	}
}
