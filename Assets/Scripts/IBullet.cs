using UnityEngine;
using System.Collections;

public class IBullet : MonoBehaviour {

	public int damage = 1;
	public string type = "Pickles";
	BulletPool bPool;

	float x;
	float z;
	Quaternion heading;

	// Use this for initialization
	public IBullet initialize(float nx, float nz, Quaternion nheading, BulletPool pool) {
		x = nx;
		z = nz;
		heading = nheading;
		bPool = pool;
		return this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void deinitialize() {
		bPool.ReleaseBullet (this);
	}

	void onHit() {
		//Special Effects
		deinitialize ();
	}
}
