using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour {
	
	public Toggle slowTime;
	public Toggle speedDash;
	public Toggle hyperJump;
	public Toggle shield;
	
	public static int state_st = 0;
	public static int state_sd = 0;
	public static int state_hj = 0;
	public static int state_s = 0;
	
	public static int coin = 0;
	private bool poor = false; 
	
	
	void Start()
	{
		coin = PlayerPrefs.GetInt("Coins");
		//coin = 10000;
	}
	
	void Update(){
		//coin = PlayerPrefs.GetInt("Coins");
		
		if (slowTime.isOn) 
		{
			if(state_st == 0)
			{
				if(coin < 50){
					poor = true; 
				}
				else if(coin >= 50){
					coin = coin - 50;
					PlayerPrefs.SetInt("Slow", 1);
				}
			}
			
			state_st = 1;
		}
		
		if (!slowTime.isOn) 
		{
			state_st = 0;
			PlayerPrefs.SetInt("Slow", 0);
		}
		
		if (speedDash.isOn) 
		{
			if(state_sd == 0)
			{
				if(coin < 50){
					poor = true; 
				}
				else if(coin > 50){
					coin = coin - 50;
					PlayerPrefs.SetInt("Dash", 1);
				}
			}
			
			state_sd = 1;
		}
		
		if (!speedDash.isOn) 
		{
			state_sd = 0;
			PlayerPrefs.SetInt("Dash", 0);
		}
		
		if (hyperJump.isOn) 
		{
			if(state_hj == 0)
			{
				if(coin < 50){
					poor = true; 
				}
				else if(coin > 50){
					coin = coin - 50;
					PlayerPrefs.SetInt("Jump", 1);
				}
			}
			
			state_hj = 1;
		}
		
		if (!hyperJump.isOn) 
		{
			state_hj = 0;
			PlayerPrefs.SetInt("Jump", 0);
		}
		
		if (shield.isOn) 
		{
			if(state_s == 0)
			{
				if(coin < 50){
					poor = true; 
				}
				else if(coin > 50){
					coin = coin - 50;
					PlayerPrefs.SetInt("Shield", 1);
				}
			}
			
			state_s = 1;
		}
		
		if (!shield.isOn) 
		{
			state_s = 0;
			PlayerPrefs.SetInt("Shield", 0);
		}
		
		PlayerPrefs.SetInt("Coins", coin);
	}
	
	void OnGUI(){
		GUI.color = Color.white; 
		GUI.skin.box.fontStyle = FontStyle.Bold;
		GUI.skin.label.fontSize = 20;
		GUI.Label(new Rect(50, 50, 400, 50), "Coins: " + coin);
		
		if (poor) {
			GUI.Label(new Rect(50, 70, 400, 50), "Not enough coins!");
		}
	}

	public void setYellow(){
		PlayerPrefs.SetString ("skin", "yellow");
	}

	public void setPink(){
		PlayerPrefs.SetString ("skin", "pink");
	}

	public void setDefault(){
		PlayerPrefs.SetString ("skin", "black");
	}
}
