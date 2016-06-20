using UnityEngine;
using System.Collections;

public class falcon_SpawnManager : MonoBehaviour {
	
	public int maxPlatforms = 100;
	public GameObject platform;
	public float horizontalMin = 7.5f;
	public float horizontalMax = 14f;
	public float verticalMin = -1;
	public float verticalMax = 2f;
	float yGroundPosition = -.2f;
	float yAirPosition = .5f;
	
	private Vector2 originPosition;
	
	void Start () {
		
		originPosition = transform.position;
		Spawn ();
		
	}
	
	
	void Spawn(){
		originPosition.x += 10;

		groundAirGround();
		originPosition.x += 5;
		airGroundCombo ();
		originPosition.x += 5;
		doubleAir ();
		originPosition.x += 5;
		doubleGround ();
		originPosition.x += 5;
		groundAirCombo ();
		originPosition.x += 5;
		singleAir ();
		originPosition.x += 5;
		groundAirCombo ();
		originPosition.x += 5;
		wall ();
		originPosition.x += 5;

		threeGroundQuick();
		originPosition.x += 5;
		groundAirCombo ();
		originPosition.x += 5;
		doubleAir ();
		originPosition.x += 5;
		doubleGround ();
		originPosition.x += 5;
		groundAirCombo ();
		originPosition.x += 5;
		singleAir ();
		originPosition.x += 5;

		wall();
		originPosition.x += 5;
		wall ();
		originPosition.x += 5;
		singleAir ();
		originPosition.x += 5;
		singleGround ();
		originPosition.x += 5;
		doubleAir ();
		originPosition.x += 5;
		doubleGround ();
		originPosition.x += 5;

		airGroundCombo();
		originPosition.x += 5;
		wall ();
		originPosition.x += 5;
		airGroundCombo ();
		originPosition.x += 5;
		wall ();
		originPosition.x += 5;
		airBound ();
		originPosition.x += 5;
		airBound ();
		originPosition.x += 5;

		wall ();
		originPosition.x += 5;
		airGroundCombo ();
		originPosition.x += 5;
		wall ();
		originPosition.x += 5;
		doubleAir ();
		originPosition.x += 5;
		doubleGround ();
		originPosition.x += 5;
		groundAirCombo ();
		originPosition.x += 5;
		singleAir ();
		originPosition.x += 5;
		doubleAir ();
		originPosition.x += 5;
		doubleGround ();
		originPosition.x += 5;
		groundAirCombo ();
		originPosition.x += 5;
		singleAir ();
		originPosition.x += 5;
		groundAirCombo ();
		originPosition.x += 5;
		wall ();
		originPosition.x += 5;

		airGroundCombo ();
		originPosition.x += 5;
		wall ();
		originPosition.x += 5;
		groundAirCombo ();
		originPosition.x += 5;

	}

	void wall(){
		Vector2 randomPosition = originPosition + new Vector2 (2, yGroundPosition);
		Instantiate (platform, randomPosition, Quaternion.identity);
		originPosition.x = randomPosition.x;
		randomPosition = originPosition - new Vector2 (0, yGroundPosition);
		Instantiate (platform, randomPosition, Quaternion.identity);
		originPosition.x = randomPosition.x;
	}

	void airGroundCombo(){
		Vector2 randomPosition = originPosition + new Vector2 (2, yAirPosition + .3f);
		Instantiate (platform, randomPosition, Quaternion.identity);
		originPosition.x = randomPosition.x;
		randomPosition = originPosition + new Vector2 (1, yGroundPosition);
		Instantiate (platform, randomPosition, Quaternion.identity);
		originPosition.x = randomPosition.x;
	}

	void groundAirCombo(){
		Vector2 randomPosition = originPosition + new Vector2 (2, yGroundPosition);
		Instantiate (platform, randomPosition, Quaternion.identity);
		originPosition.x = randomPosition.x;
		randomPosition = originPosition + new Vector2 (1, yAirPosition + .3f);
		Instantiate (platform, randomPosition, Quaternion.identity);
		originPosition.x = randomPosition.x;
	}
	
	void airBound(){
		Vector2 randomPosition = originPosition + new Vector2 (2, yAirPosition);
		Instantiate (platform, randomPosition, Quaternion.identity);
		originPosition.x = randomPosition.x;
	}
	
	void groundAirGround(){
		Vector2 randomPosition = originPosition + new Vector2 (2, yGroundPosition);
		Instantiate (platform, randomPosition, Quaternion.identity);
		originPosition.x = randomPosition.x;
		randomPosition = originPosition + new Vector2 (5, yAirPosition);
		Instantiate (platform, randomPosition, Quaternion.identity);
		originPosition.x = randomPosition.x;
		randomPosition = originPosition + new Vector2 (5, yGroundPosition);
		Instantiate (platform, randomPosition, Quaternion.identity);
		originPosition.x = randomPosition.x;
	}
	
	void threeGroundQuick(){
		for (int i = 0; i < 3; ++i) {
			Vector2 randomPosition = originPosition + new Vector2 (1, yGroundPosition);
			Instantiate (platform, randomPosition, Quaternion.identity);
			originPosition.x = randomPosition.x;
		}
	}

	void doubleAir(){
		for (int i = 0; i < 2; ++i) {
			Vector2 randomPosition = originPosition + new Vector2 (3, yAirPosition);
			Instantiate (platform, randomPosition, Quaternion.identity);
			originPosition.x = randomPosition.x;
		}
	}
	void doubleGround(){
		for (int i = 0; i < 2; ++i) {
			Vector2 randomPosition = originPosition + new Vector2 (2, yGroundPosition);
			Instantiate (platform, randomPosition, Quaternion.identity);
			originPosition.x = randomPosition.x;
		}
	}
	void singleGround(){
		Vector2 randomPosition = originPosition + new Vector2 (4, yGroundPosition);
		Instantiate (platform, randomPosition, Quaternion.identity);
		originPosition.x = randomPosition.x;
	}
	
	void singleAir(){
		Vector2 randomPosition = originPosition + new Vector2 (4, yAirPosition);
		Instantiate (platform, randomPosition, Quaternion.identity);
		originPosition.x = randomPosition.x;
	}
	
}
