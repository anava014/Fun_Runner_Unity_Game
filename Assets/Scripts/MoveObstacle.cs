using UnityEngine;
using System.Collections;

public class MoveObstacle : MonoBehaviour {

	private Rigidbody2D obsbody;
	public float speed;
	// Use this for initialization
	void Start () {
		obsbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			obsbody.velocity = new Vector2 (speed, obsbody.velocity.y);
		}
	}
}
