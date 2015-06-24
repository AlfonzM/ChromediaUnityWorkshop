using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float speed = 10;
	Rigidbody2D rigidbody;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody2D> ();
		Destroy (this, 5);

	}
	
	// Update is called once per frame
	void Update () {
		rigidbody.velocity = transform.right * speed;	
	}

	void OnTriggerEnter2D(Collider2D col){
		if ((gameObject.tag == "Bullet2" && col.gameObject.name == "Player1") || 
		    gameObject.tag == "Bullet1" && col.gameObject.name == "Player2") {
			col.gameObject.GetComponent<Player>().Hit();
			Destroy(this.gameObject);
		}
	}
}