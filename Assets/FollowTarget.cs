using UnityEngine;
using System.Collections;

public class FollowTarget : MonoBehaviour {

	Vector3 target;
	public GameObject p1, p2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		target = (p1.transform.position + p2.transform.position) / 2;
		transform.position = Vector3.Lerp (transform.position, new Vector3(target.x, target.y + 1,
		                                                                   transform.position.z), 0.1f);
	}
}
