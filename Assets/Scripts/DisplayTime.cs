using UnityEngine;
using System.Collections;

public class DisplayTime : MonoBehaviour
{
	
	public  static int playtime = 0; 
	private static int seconds = 0; 
	private static int minutes = 0; 
	private static int milliseconds = 0; 
	//private bool timeVisible = true; 
	
	void Start(){
		StartCoroutine ("PlayTimer");
	}
	
	//Minutes:Seconds:Milliseconds
	private IEnumerator PlayTimer(){
		while (true) {
			yield return new WaitForSeconds (0.01f); 
			playtime += 10;
			milliseconds = playtime % 1000; 
			seconds = (playtime / 1000) % 60; 
			minutes = (playtime / 60000) % 60; 
		}
		
	}
	
	void OnGUI(){
		GUI.color = Color.gray; 
		GUI.skin.box.fontStyle = FontStyle.Bold;
		GUI.skin.label.fontSize = 20;
		string text = string.Format ("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
		GUI.Label(new Rect(50, 20, 400, 50), text);
	}
	
	public static void resetTime(){
		minutes = 0; 
		seconds = 0; 
		milliseconds = 0; 
		playtime = 0; 
	}
	
}
