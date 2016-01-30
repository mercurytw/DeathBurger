using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BulletPool : MonoBehaviour {

	public int amount = 100;
	public string type = "Pickles";
	Stack<IBullet> pool = new Stack<IBullet>();

	// Use this for initialization
	public void Start () {
		for (int i = 0; i < amount; i++) {
			pool.Push(new IBullet());
		}
	}
	
	// Update is called once per frame
	public void Update () {
	
	}

	public void GetBullet(float x, float z, Quaternion heading) {

		pool.Pop().initialize (x, z, heading, this);
		amount--;

	}

	public void ReleaseBullet(IBullet bullet) {
		bullet.gameObject.SetActive (false);
		pool.Push (bullet);
		amount++;
	}
}
