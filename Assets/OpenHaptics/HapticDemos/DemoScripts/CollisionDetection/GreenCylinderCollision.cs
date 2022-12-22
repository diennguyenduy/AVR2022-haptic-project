using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreenCylinderCollision : MonoBehaviour {

	//public Text scoreText;
	private bool greenTorusTouched = false;
	public Text warning;
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
			Debug.Log("Green cylinder - red torus!");
		} else if (other.name == "green_torus_child"){
			GameObject green_torus = GameObject.Find ("GreenTorus");
			Transform TorusTransform = green_torus.transform;
			// get player position
			Vector3 torus_position = TorusTransform.position;
			float torus_x = torus_position.x;
			float torus_y = torus_position.y;
			float torus_z = torus_position.z;
			if (greenTorusTouched == false) {
				if(torus_x >= -0.22 && torus_x <= -0.08) {
					if(torus_y >= 0.7 && torus_y <= 1.7) {
						if (torus_z <= -0.7 && torus_z >= -0.9) {
							ScoreManager.instance.AddPoint ();
							greenTorusTouched = true;
						}
					}
					//score += 1;
					//scoreText.text = score.ToString () + " POINTS";
					//Debug.Log ("Green cylinder is being collised with red torus!");
				}
			}
		} else if (other.name == "blue_torus_child"){
			//score += 1;
			//scoreText.text = score.ToString () + " POINTS";
			Debug.Log("Green cylinder - Blue torus!");
		}
	}
}
