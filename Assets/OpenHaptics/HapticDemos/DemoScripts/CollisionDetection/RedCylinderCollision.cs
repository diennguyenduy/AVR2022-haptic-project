using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RedCylinderCollision : MonoBehaviour {

	//public Text scoreText;
	private bool redTorusTouched = false;
	private bool red1TorusTouched = false;
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
			GameObject red_torus1 = GameObject.Find ("RedTorus01");
			Transform Torus1Transform = red_torus1.transform;
			// get player position
			Vector3 torus1_position = Torus1Transform.position;
			float torus1_x = torus1_position.x;
			float torus1_y = torus1_position.y;
			float torus1_z = torus1_position.z;
			if (redTorusTouched == false) {
				if(torus1_x >= 1.3 && torus1_x <= 1.4) {
					if(torus1_y >= 0.7 && torus1_y <= 1.9) {
						if (torus1_z <= -0.6 && torus1_z >= -1.0) {
							ScoreManager.instance.AddPoint ();
							redTorusTouched = true;
						}
					}
				//score += 1;
				//scoreText.text = score.ToString () + " POINTS";
				//Debug.Log ("Green cylinder is being collised with red torus!");
				}
			}
			//Debug.Log(torus1_position);
		} else if (other.name == "red_torus_child1"){
			GameObject red_torus2 = GameObject.Find ("RedTorus02");
			Transform Torus2Transform = red_torus2.transform;
			// get player position
			Vector3 torus2_position = Torus2Transform.position;
			float torus2_x = torus2_position.x;
			float torus2_y = torus2_position.y;
			float torus2_z = torus2_position.z;
			if (red1TorusTouched == false) {
				if(torus2_x >= 1.3 && torus2_x <= 1.4) {
					if(torus2_y >= 0.7 && torus2_y <= 1.9) {
						if (torus2_z <= -0.6 && torus2_z >= -1.0) {
							ScoreManager.instance.AddPoint ();
							red1TorusTouched = true;
						}
					}
					//score += 1;
					//scoreText.text = score.ToString () + " POINTS";
					//Debug.Log ("Green cylinder is being collised with red torus!");
				}
			}
			//Debug.Log(torus2_position);
		} else if (other.name == "green_torus_child"){
			//score += 1;
			//scoreText.text = score.ToString () + " POINTS";
			Debug.Log("Green cylinder is being collised with green torus!");
		}
		else if (other.name == "blue_torus_child"){
			//score += 1;
			//scoreText.text = score.ToString () + " POINTS";
			Debug.Log("Green cylinder is being collised with blue torus!");
		}
	}
}
