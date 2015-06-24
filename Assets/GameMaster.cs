using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameMaster : MonoBehaviour {

	public static int p1score, p2score;

	public static GameObject p1ScoreText, p2ScoreText;

	// Use this for initialization
	void Start () {
		p1ScoreText = GameObject.Find ("p1");
		p2ScoreText = GameObject.Find ("p2");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public static void Player1Scored(){
		p1score++;
		p1ScoreText.GetComponent<Text> ().text = p1score.ToString();
	}
	
	public static void Player2Scored(){
		p2score++;
		p2ScoreText.GetComponent<Text> ().text = p2score.ToString();
	}
}
