using UnityEditor;
using UnityEngine;
using System.Collections;
using System.IO;

public class GenerateJSON : Editor {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	static string jsonify(GameObject[] gameObjects,int[] intervals)
	{
		JSONObject json = new JSONObject (JSONObject.Type.OBJECT);

		JSONObject jenemies = new JSONObject (JSONObject.Type.ARRAY);
		json.AddField ("enemies",jenemies);
		foreach(GameObject go in gameObjects)
			jenemies.Add (go);

		JSONObject jintervals = new JSONObject (JSONObject.Type.ARRAY);
		json.AddField ("intervals",jintervals);
		foreach(int i in intervals)
			jintervals.Add (i);

		return json.Print ();
	}



	[MenuItem ("CONTEXT/GenerateJSONPuppet/WriteToFile")]
	static void WriteToFile()
	{
		GenerateJSONPuppet jp = Selection.activeGameObject.GetComponent<GenerateJSONPuppet> ();


		File.WriteAllText (jp.filename,jsonify(jp.gameObjects,jp.intervals));
	}
}
