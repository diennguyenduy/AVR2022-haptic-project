using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking; //Network

public class GetTicPosition : MonoBehaviour {

	//movement speed in units per second
	//private float movementSpeed = 5f;

	// Use this for initialization
	void Start () {
		//StartCoroutine(Upload());
	}

	IEnumerator Upload(string device_position)
	{
		//WWWForm form = new WWWForm();
		//form.AddField("myField", "myData");

		using (UnityWebRequest www = UnityWebRequest.Post("localhost:8080", device_position))
		{
			yield return www.Send();

			if (www.isError)
			{
				Debug.Log(www.error);
			}
			else
			{
				Debug.Log("Form upload complete!");
			}
		}
	}

	// Update is called once per frame
	void Update () {
		GameObject haptic_tip = GameObject.Find ("Sphere");
		Transform TipTransform = haptic_tip.transform;
		// get player position
		Vector3 position = TipTransform.position;

		// convert vector3 to string
		string PositionString = position.x + " " + position.y + " " + position.z;

		// send data to server
		//StartCoroutine(Upload(PositionString));

		//update the position
		//transform.position = transform.position + new Vector3(horizontalInput * movementSpeed * Time.deltaTime, verticalInput * movementSpeed * Time.deltaTime, 0);

		//output to log the position change
		//Debug.Log(PositionString);
	}
}
