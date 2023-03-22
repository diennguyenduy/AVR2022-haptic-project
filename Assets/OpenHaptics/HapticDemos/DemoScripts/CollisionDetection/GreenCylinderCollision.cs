using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreenCylinderCollision : MonoBehaviour {

	public static GreenCylinderCollision instance;

	private bool greenTorusTouched = false;
	public Text warning;
	public string[] torusColorArray;
	public string[] cylinderColor;
	public string[] torusName;

	private void Awake(){
		instance = this;
	}

	// Use this for initialization
	void Start () {
		torusColorArray = ScoreManager.instance.getTorusColorArray ();
		cylinderColor = ScoreManager.instance.getCylinderColor ();
		torusName = ScoreManager.instance.getTorusName ();
		//scoreText.text = score.ToString () + " POINTS";
	}

	// Update is called once per frame
	void Update () {
		//guiText.text = "Score: " + Counter;
		//Counter += 1;
	}

	public void setTouch() {
		greenTorusTouched = false;

		torusColorArray = ScoreManager.instance.getTorusColorArray ();
		cylinderColor = ScoreManager.instance.getCylinderColor ();
		torusName = ScoreManager.instance.getTorusName ();
	}

	void OnCollisionEnter(Collision collisionInfo) {
		Collider other = collisionInfo.collider;
		for (int i = 0; i < 3; i++) {
			if (cylinderColor [i] == "Green_Cylinder") {
				//Debug.Log("OnCollisionEnter : " + other.name);
				//GameObject that = other.gameObject;
				if (other.name == torusColorArray[i]){
					GameObject green_torus = GameObject.Find (torusName[i]);
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
				}
			}
		}
	}
}
