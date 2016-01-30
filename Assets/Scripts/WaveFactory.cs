using UnityEngine;
using System.Collections;
using System.IO;

public class WaveFactory : MonoBehaviour {

	public string filename;
	JSONObject json;

	// Use this for initialization
	void Start () {

		json = new JSONObject((Resources.Load(filename) as TextAsset).text);

	}

	public Wave buildWave() {
		Wave w = new Wave ();

		JSONObject enemyList = json.GetField ("enemies");

		foreach(JSONObject jo in enemyList.list) {
			string type = jo.GetField("type").str;
			float x = jo.GetField("x").n;
			float z = jo.GetField("z").n;
			w.enemies.Push(new IEnemy(type,x,z));
		}

		JSONObject intervalList = json.GetField ("intervals");
		foreach (JSONObject jo in intervalList.list) {
			w.intervals.Push((int)jo.i);
		}
		return w;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
