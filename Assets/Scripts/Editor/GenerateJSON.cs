using UnityEditor;
using UnityEngine;
using System.Collections;
using System.IO;

public class GenerateJSON : Editor {

	public string filename;
	public GameObject[] gameObjects;
	public int[] intervals;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	string jsonify()
	{
		JSONObject json = new JSONObject (JSONObject.Type.OBJECT);

		JSONObject jenemies = new JSONObject (JSONObject.Type.ARRAY);
		json.AddField ("enemies",jenemies);
		foreach(GameObject go in gameObjects)
			jenemies.Add (go);

		JSONObject jintervals = new JSONObject (JSONObject.Type.ARRAY);
		json.AddField ("intervals",jintervals);
		foreach(GameObject go in gameObjects)
			jintervals.Add (go);

		return json.Print ();
	}



	[MenuItem ("CONTEXT/GenerateJSONPuppet/WriteToFile")]
	void WriteToFile()
	{
		File.WriteAllText (filename, jsonify());
	}
}
