using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torus1Collision : MonoBehaviour {

	int Counter = 0;
	public GUIText guiText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//guiText.text = "Score: " + Counter;
		//Counter += 1;
	}

	void React ()
	{
		Counter++;
	}

	void OnCollisionEnter(Collision collisionInfo) {
		Collider other = collisionInfo.collider;
		//Debug.Log("OnCollisionEnter : " + other.name);
		//GameObject that = other.gameObject;
		if(other.name == "Red_Cylinder"){
			//gameObject scoreText = gameObject.Find ("scoreText");
			//scoreText.SendMessage("React");
			Debug.Log("Collised to red cylinder!");
			//yield WaitForSeconds(1);
			//gameObject.active=false;
		} else if (other.name == "Blue_Cylinder"){
			//gameObject scoreText = gameObject.Find ("scoreText");
			//scoreText.SendMessage("React");
			Debug.Log("Collised to blue cylinder!");
			//yield WaitForSeconds(1);
			//gameObject.active=false;
		} else if (other.name == "Green_Cylinder"){
			//gameObject scoreText = gameObject.Find ("scoreText");
			//scoreText.SendMessage("React");
			Debug.Log("Collised to green cylinder!");
			//yield WaitForSeconds(1);
			//gameObject.active=false;
		}
	}
}
