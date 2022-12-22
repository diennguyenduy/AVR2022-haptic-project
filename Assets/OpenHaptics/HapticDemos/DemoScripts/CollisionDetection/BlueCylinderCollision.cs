using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlueCylinderCollision : MonoBehaviour {

	//public Text scoreText;
	public Text warning;
	private bool blueTorusTouched = false;
	//int score = 0;

	// Use this for initialization
	void Start () {
		//scoreText.text = score.ToString () + " POINTS";
	}

	// Update is called once per frame
	void Update () {
		//guiText.text = "Score: " + Counter;
		//Counter += 1;
	}

	void OnCollisionEnter(Collision collisionInfo) {
		Collider other = collisionInfo.collider;
		//Debug.Log("OnCollisionEnter : " + other.name);
		//GameObject that = other.gameObject;
		if(other.name == "red_torus_child"){
			//score += 1;
			//scoreText.text = score.ToString () + " POINTS";
			Debug.Log("Green cylinder is being collised with red torus!");
		} else if (other.name == "green_torus_child"){
			//score += 1;
			//scoreText.text = score.ToString () + " POINTS";
			Debug.Log("Green cylinder is being collised with green torus!");
		} else if (other.name == "blue_torus_child"){
			GameObject blue_torus = GameObject.Find ("BlueTorus");
			Transform TorusTransform = blue_torus.transform;
			// get player position
			Vector3 torus_position = TorusTransform.position;
			float torus_x = torus_position.x;
			float torus_y = torus_position.y;
			float torus_z = torus_position.z;
			if (blueTorusTouched == false) {
				if(torus_x >= -1.8 && torus_x <= -1.6) {
					if(torus_y >= 0.7 && torus_y <= 1.9) {
						if (torus_z <= -0.7 && torus_z >= -0.9) {
							ScoreManager.instance.AddPoint ();
							blueTorusTouched = true;
						}
					}
					//score += 1;
					//scoreText.text = score.ToString () + " POINTS";
					//Debug.Log ("Green cylinder is being collised with red torus!");
				}
			}
		}
	}
}
