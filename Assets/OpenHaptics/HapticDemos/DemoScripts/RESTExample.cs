using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class RESTExample : MonoBehaviour
{
	void Start()
	{
		StartCoroutine(Upload());
	}

	IEnumerator Upload()
	{
		//WWWForm form = new WWWForm();
		//form.AddField("myField", "myData");

		string data = "ABCCCCCCCCCCCCCC";

		using (UnityWebRequest www = UnityWebRequest.Post("http://0.0.0.0:8000/", data))
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
}