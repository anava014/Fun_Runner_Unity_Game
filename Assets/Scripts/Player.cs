using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private float speed;
	private float jumpspeed;
	private Rigidbody2D playerbody;
	private bool holdjump;
	private bool wascrouched;

	private Vector3 spawnPoint;
	Animator anim;

	public AudioClip jumpsound;

	private int shielded;
	//private float distToGround;

	// Use this for initialization
	void Start () {
		spawnPoint = transform.position;
		playerbody = GetComponent<Rigidbody2D>();
		//distToGround = GetComponent<Collider2D>().bounds.extents.y;
		holdjump = false;
		anim = GetComponent <Animator> ();
		if (PlayerPrefs.GetInt ("Jump") == 1) {
			jumpspeed = 40;
		} else {
			jumpspeed = 32;
		}
		if (PlayerPrefs.GetInt ("Shield") == 1) {
			shielded = 1;
		} else {
			shielded = 0;
			GameObject.Find ("Shield").SetActive (false);
		}
		if (PlayerPrefs.GetInt ("Slow") == 1) {
			Time.timeScale = .7f;
		} else {
			Time.timeScale = 1f;
		}
		if (PlayerPrefs.GetInt ("Dash") == 1) {
			speed = 24;
		} else {
			speed = 14;
		}
	}
	
	// Update is called once per frame
	void Update () {
		playerbody.velocity = new Vector2 (speed, playerbody.velocity.y);

		if(playerbody.position.y <= .03)
			anim.SetFloat("Speed", 0);
		else 
			anim.SetFloat("Speed", 1);

		if (Input.touchCount > 0) {
			foreach(Touch touch in Input.touches){
				if (Input.GetTouch (0).phase == TouchPhase.Began && touch.position.x < Screen.width/2) {
					anim.SetFloat ("Speed", 1);
					if (isGrounded ()) {
						playerbody.velocity = new Vector2 (playerbody.velocity.x, jumpspeed);
						AudioSource.PlayClipAtPoint (jumpsound, this.transform.position);
						holdjump = true;
					}
				}
				if(Input.GetTouch (0).phase == TouchPhase.Began && touch.position.x > Screen.width/2){
					transform.localScale = new Vector3(transform.localScale.x, .5f, 0);
					playerbody.gravityScale = 22;
					wascrouched = true;
				}
			}
			if (holdjump) {
				if (playerbody.velocity.y < 0) {
					playerbody.gravityScale = 3;
					//Debug.Log ("test");
				}
			}

			if(Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(0).phase == TouchPhase.Canceled){
				holdjump = false;
				playerbody.gravityScale = 18;

				if(wascrouched == true){
					transform.localScale = new Vector3(transform.localScale.x, 1f, 0);
					anim.SetFloat ("Speed", 0);
					wascrouched = false;
				}
			}
		}
		/*if (Input.GetKeyUp (KeyCode.Space)) {

			playerbody.gravityScale = 18;
			holdjump = false;
		}


		if (Input.GetKeyUp (KeyCode.LeftControl)) {
			//transform.position = new Vector3(transform.position.x, .5f, 0);
			transform.localScale = new Vector3(transform.localScale.x, 1f, 0);
			playerbody.gravityScale = 18;
			anim.SetFloat("Speed", 0);
		}*/

	}

	void OnTriggerEnter2D(Collider2D other){
//		if (other.tag == "Obstacle") {
//			Application.LoadLevel (Application.loadedLevel);
//		}
//		transform.position = spawnPoint;

		if (other.gameObject.tag == "Obstacle")
		{
			Debug.Log ("collided with "+other.gameObject.name);
			if(shielded > 0){
				shielded--;
				GameObject.Find ("Shield").SetActive (false);
			}
			else{
			Application.LoadLevel("Death");
			}
		}
		if (other.gameObject.tag == "finish")
        {
            DisplayHighScore.insert_Score();
            Application.LoadLevel("Finish");
        }
	}


	bool isGrounded(){
		if (playerbody.velocity.y == 0) {
			return true;
		} else {
			return false;
		}
	}

	public bool isShielded(){
		if (shielded > 0) {
			return true;
		} else {
			return false;
		}
	}
}
