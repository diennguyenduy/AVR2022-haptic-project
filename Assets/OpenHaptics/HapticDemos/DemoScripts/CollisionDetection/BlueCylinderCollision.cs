using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlueCylinderCollision : MonoBehaviour {

	public static BlueCylinderCollision instance;

	private bool blueTorusTouched = false;
	public string[] torusColorArray;
	public string[] cylinderColor;
	public string[] torusName;

	private void Awake(){
		instance = this;
	}

	// Use this for initialization
	void Start () {
		torusColorArray = ScoreManager.instance.getTorusColorArray ();
		torusName = ScoreManager.instance.getTorusName ();
		cylinderColor = ScoreManager.instance.getCylinderColor ();

		for (int i = 0; i < 3; i++) {
			Debug.Log (torusColorArray [i]);
			Debug.Log (cylinderColor [i]);
		}
	}

	// Update is called once per frame
	void Update () {
	}

	public void setTouch() {
		blueTorusTouched = false;

		torusColorArray = ScoreManager.instance.getTorusColorArray ();
		torusName = ScoreManager.instance.getTorusName ();
		cylinderColor = ScoreManager.instance.getCylinderColor ();
	}

	void OnCollisionEnter(Collision collisionInfo) {
		Collider other = collisionInfo.collider;
		for (int i = 0; i < 3; i++) {
			if (cylinderColor [i] == "Blue_Cylinder") {
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
					if (blueTorusTouched == false) {
						if(torus_x >= -1.8 && torus_x <= -1.6) {
							if(torus_y >= 0.7 && torus_y <= 1.9) {
								if (torus_z <= -0.7 && torus_z >= -0.9) {
									ScoreManager.instance.AddPoint ();
									blueTorusTouched = true;
								}
							}
						}
					}
				}
			}
		}
	}
}
