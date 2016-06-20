using UnityEngine;
using System.Collections;

public class DropObs : MonoBehaviour {
	
	private Rigidbody2D obsbody;

	// Use this for initialization
	void Start () {
		obsbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (obsbody.position.y <= -1) {
			obsbody.gravityScale = 0;
			obsbody.position = new Vector2(obsbody.position.x, -1);
			obsbody.constraints = RigidbodyConstraints2D.FreezePositionY;
		}
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {
			obsbody.gravityScale = 1; 
		}
	}
}
