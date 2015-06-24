using UnityEngine;
using System.Collections;

public class Flag : MonoBehaviour {

	public GameObject target;
	public GameObject particles;
	bool pickedUp;
	Vector3 startPos;
	
	// Use this for initialization
	void Start () {
		startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (pickedUp) {
			transform.position = target.transform.position + new Vector3(0,0.5f,0);
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		// if collide with a Player
		if (col.gameObject.tag == "Player" &&
		    (gameObject.name == "redFlag" && col.gameObject.name == "Player1") ||
		    (gameObject.name == "greenFlag" && col.gameObject.name == "Player2") ) {
			pickedUp = true;
			target = col.gameObject;
		}

		// if collide with Castle
		if (col.gameObject.tag == "Castle") {
			if((gameObject.name == "redFlag" && col.gameObject.name == "castle1")){
				GameMaster.Player1Scored();
				PickedUp();
			}
			else if(gameObject.name == "greenFlag" && col.gameObject.name == "castle2" ){
				GameMaster.Player2Scored();
				PickedUp();
			}
		}
	}

	void PickedUp(){
		Instantiate (particles, transform.position, Quaternion.Euler(new Vector3(270,0,0)));
		transform.position = startPos;
		pickedUp = false;
	}
}
