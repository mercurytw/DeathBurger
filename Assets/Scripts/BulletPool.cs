
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BulletPool
{
    // public string type = "Pickles";
    Stack<PickleProjectile> pool = new Stack<PickleProjectile>();
    private Vector3 temp = new Vector3(-99999f, 0f, 0f);

	// Use this for initialization
	public BulletPool (int amount, string type) {
		for (int i = 0; i < amount; i++) {
            GameObject obj = GameObject.Instantiate((GameObject)Resources.Load(type));
            Debug.Assert(obj);
            obj.transform.position = temp;
            PickleProjectile behavior = obj.GetComponent<PickleProjectile>();
            Debug.Assert(behavior);
            pool.Push(behavior);
		}
	}

	public PickleProjectile GetBullet(float x, float z, Quaternion heading) {

        PickleProjectile bullet = pool.Pop();
        Debug.Assert(null != bullet);
		bullet.initialize (x, z, heading, this);
        bullet.gameObject.SetActive(true);
        return bullet;
	}

	public void ReleaseBullet(PickleProjectile bullet) {
		bullet.gameObject.SetActive (false);
		bullet.gameObject.transform.position = temp;
		pool.Push (bullet);
	}
}
