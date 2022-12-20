using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;

public class InstantiationExample : MonoBehaviour 
{
	// Reference to the Prefab. Drag a Prefab into this field in the Inspector.
	public GameObject myPrefab;
	float next_spawn_time;

	// This script will simply instantiate the Prefab when the game starts.
	void Start()
	{
		//start off with next spawn time being 'in 7 seconds'
		next_spawn_time = Time.time+7.0f;
	}

	void Update()
	{
		if(Time.time > next_spawn_time)
		{
			//do stuff here (like instantiate)
			//GameObject Torus = GameObject.Find ("Torus"); //instance the Torus object instead of prefab
			//var instance = Instantiate(Torus, new Vector3(-1, 1, -2), Quaternion.identity);

			var instance = Instantiate(myPrefab, new Vector3(-1, 1, -2), Quaternion.identity);
			var objRenderer = instance.GetComponentInChildren<Renderer>(true);

			//Generate random color for torus and then instance a new torus with generated color
			Color color = Color.blue;
			int col = Random.Range (0, 3);

			switch (col) {
			case 1:
				color = Color.red;
				break;
			case 2:
				color = Color.green;
				break;
			case 3:
				color = Color.blue;
				break;
			}
			objRenderer.material.color = color;

			/*
			//Generate random color for cylinder
			string cylinder_color = "blue";
			int cylinder_col = Random.Range (0, 3);

			switch (cylinder_col) {
			case 1:
				cylinder_color = "red";
				break;
			case 2:
				cylinder_color = "green";
				break;
			case 3:
				cylinder_color = "blue";
				break;
			}

			Debug.Log ("Please grab" + color + "Torus and put on " + cylinder_color + " Cylinder!");
			//objRenderer.material.color = Color.blue;
			*/

			//increment next_spawn_time
			next_spawn_time += 7.0f;
		}
	}
}
