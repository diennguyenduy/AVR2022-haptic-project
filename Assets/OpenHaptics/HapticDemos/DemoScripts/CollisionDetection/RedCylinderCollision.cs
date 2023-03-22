using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RedCylinderCollision : MonoBehaviour {

	public static RedCylinderCollision instance;

	private bool redTorusTouched = false;
	public Text warning;
	public string[] torusColorArray;
	public string[] torusName;
	public string[] cylinderColor;

	private void Awake(){
		instance = this;
	}

	// Use this for initialization
	void Start () {
		torusColorArray = ScoreManager.instance.getTorusColorArray ();
		torusName = ScoreManager.instance.getTorusName ();
		cylinderColor = ScoreManager.instance.getCylinderColor ();

		//for (int i = 0; i < 3; i++) {
		//	Debug.Log ("red " + torusColorArray [i]);
		//	Debug.Log ("red " + cylinderColor [i]);
		//}
	}

	// Update is called once per frame
	void Update () {
	}

	public void setTouch() {
		redTorusTouched = false;

		torusColorArray = ScoreManager.instance.getTorusColorArray ();
		torusName = ScoreManager.instance.getTorusName ();
		cylinderColor = ScoreManager.instance.getCylinderColor ();
	}

	void OnCollisionEnter(Collision collisionInfo) {
		Collider other = collisionInfo.collider;
		for (int i = 0; i < 3; i++) {
			if (cylinderColor [i] == "Red_Cylinder") {
				//Debug.Log("AAAAAAAAAAAAAAAAAAAA: " + i);
				//Debug.Log("Colorrrrrrrrrrrrrrrrr: " + torusColorArray[i]);
				//Debug.Log("OnCollisionEnter : " + other.name);
				//GameObject that = other.gameObject;
				if(other.name == torusColorArray[i]){
					//Debug.Log("Nameeeeeeeeee:  " + torusName[i]);
					GameObject test_torus = GameObject.Find (torusName[i]);
					//Debug.Log("AAAAAAAAAA: " + test_torus);
					Transform Torus1Transform = test_torus.transform;
					// get player position
					Vector3 torus1_position = Torus1Transform.position;
					float torus1_x = torus1_position.x;
					float torus1_y = torus1_position.y;
					float torus1_z = torus1_position.z;
					if (redTorusTouched == false) {
						if(torus1_x >= 1.28 && torus1_x <= 1.5) {
							if(torus1_y >= 0.7 && torus1_y <= 1.9) {
								if (torus1_z <= -0.6 && torus1_z >= -1.0) {
									ScoreManager.instance.AddPoint ();
									redTorusTouched = true;
								}
							}
						}
					}
				}
			}
		}
	}
}
