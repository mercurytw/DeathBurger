using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BulletPool : MonoBehaviour {

	public int amount = 100;
	public string type = "Pickles";
	List<IBullet> pool = new List<IBullet>();

	// Use this for initialization
	public void Start () {
	
	}
	
	// Update is called once per frame
	public void Update () {
	
	}

	public void GetBullet(float x, float z, Quaternion heading) {
		if (amount < 1)
			return;

		IBullet newBullet = new IBullet ();
		amount--;
		pool.Add(newBullet.initialize (x, z, heading, this));
	}

	public void ReleaseBullet(IBullet bullet) {
		pool.Remove (bullet);
		amount++;
	}
}
