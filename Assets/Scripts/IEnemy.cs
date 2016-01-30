using UnityEngine;
using System.Collections;

public class IEnemy : MonoBehaviour {

	public string type;
	public float x;
	public float z;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public IEnemy (string ntype, float nx, float nz) {
		type = ntype;
		x = nx;
		z = nz;
	}
}
