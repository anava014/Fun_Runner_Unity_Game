using UnityEngine;
	using System.Collections;
	
	public class SpawnManager : MonoBehaviour {

		public int maxPlatforms = 20;
		public GameObject platform;
		public float horizontalMin = 7.5f;
		public float horizontalMax = 14f;
		public float verticalMin = -1;
		public float verticalMax = 2f;
		float yGroundPosition = -.2f;
		float yAirPosition = .5f;
	    public GameObject playerObject;
		
		private Vector2 originPosition;
		
		void Start () {
			
			originPosition = transform.position;
			originPosition.x += 10;
			//Spawn ();
			
		}

		void Update(){
			if (playerObject.transform.position.x + 30f >= originPosition.x)
				spawnMore ();
		}
	
		
		void Spawn(){
			originPosition.x += 10;
			int index;
			for (int i = 0; i < maxPlatforms; i++){
				index = Random.Range(1, 9);
				switch (index) {
					case 1: threeGroundQuick();
						break;
					case 2: airBound ();
						break;
					case 3: groundAirGround ();
						break;
					case 4: tripleAir();
						break;
					case 5: doubleGround();
						break;
					case 6: singleAir ();
						break;
					case 7: singleGround ();
						break;
					case 8: doubleAir ();
						break;
				}

				originPosition.x += 5;
			}  
		}

		void spawnMore(){
			int index;
			for (int i = 0; i < maxPlatforms; i++){
				index = Random.Range(1, 9);
				switch (index) {
					case 1: threeGroundQuick();
						break;
					case 2: airBound ();
						break;
					case 3: groundAirGround ();
						break;
					case 4: tripleAir();
						break;
					case 5: doubleGround();
						break;
					case 6: singleAir ();
						break;
					case 7: singleGround ();
						break;
					case 8: doubleAir ();
						break;
				}
			
				originPosition.x += 5;
			}  

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
				Vector2 randomPosition = originPosition + new Vector2 (0, yGroundPosition);
				Instantiate (platform, randomPosition, Quaternion.identity);
				originPosition.x = randomPosition.x;
			}
		}

		void tripleAir(){
			for (int i = 0; i < 3; ++i) {
				Vector2 randomPosition = originPosition + new Vector2 (2, yAirPosition);
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
