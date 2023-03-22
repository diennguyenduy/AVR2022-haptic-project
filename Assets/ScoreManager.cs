using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public static ScoreManager instance;
	//public bool TorusTouched = false;

	public int random1;
	public int random2;

	public Text scoreText;
	public Text highscoreText;
	public Text userInstruction1;
	public Text userInstruction2;
	public Text userInstruction3;

	public Text Ins1_torus_color;
	public Text Ins1_cylinder_color;
	public Text Ins2_torus_color;
	public Text Ins2_cylinder_color;
	public Text Ins3_torus_color;
	public Text Ins3_cylinder_color;

	public string[][] torusColorArrays = new string[3][]{
		new string[3]{ "blue_torus_child", "green_torus_child", "red_torus_child" },
		new string[3]{ "green_torus_child", "red_torus_child", "blue_torus_child" },
		new string[3]{ "red_torus_child", "blue_torus_child", "green_torus_child"},
	};

	public string[][] torusNameArrays = new string[3][]{
		new string[3]{ "BlueTorus", "GreenTorus", "RedTorus" },
		new string[3]{ "GreenTorus", "RedTorus", "BlueTorus" },
		new string[3]{ "RedTorus", "BlueTorus", "GreenTorus" }
	};

	public string[][] cylinderArrays = new string[3][]{
		new string[3]{"Blue_Cylinder", "Green_Cylinder", "Red_Cylinder"},
		new string[3]{"Blue_Cylinder", "Red_Cylinder", "Green_Cylinder"},
		new string[3]{"Red_Cylinder", "Blue_Cylinder", "Green_Cylinder"}
	};

	public string[][] torusNameToShow = new string[3][]{
		new string[3]{ "Blue Torus", "Green Torus", "Red Torus" },
		new string[3]{ "Green Torus", "Red Torus", "Blue Torus" },
		new string[3]{ "Red Torus", "Blue Torus", "Green Torus" }
	};

	public string[][] cylinderNameToShow = new string[3][]{
		new string[3]{"Blue Cylinder", "Green Cylinder", "Red Cylinder"},
		new string[3]{"Blue Cylinder", "Red Cylinder", "Green Cylinder"},
		new string[3]{"Red Cylinder", "Blue Cylinder", "Green Cylinder"}
	};

	public string[][] torusColorToShow = new string[3][]{
		new string[3]{ "blue", "green", "red" },
		new string[3]{ "green", "red", "blue" },
		new string[3]{ "red", "blue", "green" }
	};

	public string[][] cylinderColorToShow = new string[3][]{
		new string[3]{"blue", "green", "red"},
		new string[3]{"blue", "red", "green"},
		new string[3]{"red", "blue", "green"}
	};

	int score = 0;
	int highscore = 0;

	private void Awake(){
		instance = this;
	}

	public static Color ToColor(string color) {
		return (Color)typeof(Color).GetProperty (color.ToLowerInvariant ()).GetValue (null, null);
	}

	// Use this for initialization
	void Start () {
		scoreText.text = score.ToString () + "/3 Torus";
		//highscoreText.text = "HIGHSCORE: " + highscore.ToString ();

		//System.Random rnd = new System.Random ();
		//random = rnd.Next (0, 3);

		Ins1_torus_color.text = torusNameToShow [0] [0];
		Ins1_torus_color.color = Color.blue;
		Ins1_cylinder_color.text = cylinderNameToShow [0] [0];
		Ins1_cylinder_color.color = Color.blue;

		Ins2_torus_color.text = torusNameToShow [0] [1];
		Ins2_torus_color.color = Color.green;
		Ins2_cylinder_color.text = cylinderNameToShow [0] [1];
		Ins2_cylinder_color.color = Color.green;

		Ins3_torus_color.text = torusNameToShow [0] [2];
		Ins3_torus_color.color = Color.red;
		Ins3_cylinder_color.text = cylinderNameToShow [0] [2];
		Ins3_cylinder_color.color = Color.red;

		//userInstruction1.text = torusNameToShow [0][0] + " to " + cylinderNameToShow [0] [0];
		//userInstruction1.color = Color.blue; 	 
		//userInstruction2.text = torusNameToShow [0][1] + " to " + cylinderNameToShow [0] [1];
		//userInstruction3.text = torusNameToShow [0][2] + " to " + cylinderNameToShow [0] [2];
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void AddPoint(){
		score += 1;
		scoreText.text = score.ToString () + "/3 Torus";

		//if (highscore < score)
		//	PlayerPrefs.SetInt ("highscore", score);
	}

	public void resetPoint(){
		score = 0;
		scoreText.text = score.ToString () + "/3 Torus";

		System.Random rnd = new System.Random ();
		random1 = rnd.Next (0, 3);
		random2 = rnd.Next (0, 3);

		Ins1_torus_color.text = torusNameToShow [random2] [0];
		Ins1_torus_color.color = ToColor(torusColorToShow[random2][0]);
		Ins1_cylinder_color.text = cylinderNameToShow [random1] [0];
		Ins1_cylinder_color.color = ToColor(cylinderColorToShow[random1][0]);

		Ins2_torus_color.text = torusNameToShow [random2] [1];
		Ins2_torus_color.color = ToColor(torusColorToShow[random2][1]);
		Ins2_cylinder_color.text = cylinderNameToShow [random1] [1];
		Ins2_cylinder_color.color = ToColor(cylinderColorToShow[random1][1]);

		Ins3_torus_color.text = torusNameToShow [random2] [2];
		Ins3_torus_color.color = ToColor(torusColorToShow[random2][2]);
		Ins3_cylinder_color.text = cylinderNameToShow [random1] [2];
		Ins3_cylinder_color.color = ToColor(cylinderColorToShow[random1][2]);

		//userInstruction1.text = torusNameToShow [random2][0] + " to " + cylinderNameToShow [random1] [0];
		//userInstruction2.text = torusNameToShow [random2][1] + " to " + cylinderNameToShow [random1] [1];
		//userInstruction3.text = torusNameToShow [random2][2] + " to " + cylinderNameToShow [random1] [2];

		RedCylinderCollision.instance.setTouch ();
		GreenCylinderCollision.instance.setTouch ();
		BlueCylinderCollision.instance.setTouch ();
	}

	public int getScore() {
		return score;
	}

	public string[] getTorusColorArray(){
		return torusColorArrays[random2];
	}

	public string[] getTorusName(){
		return torusNameArrays[random2];
	}

	public string[] getCylinderColor(){
		return cylinderArrays[random1];
	}

}
