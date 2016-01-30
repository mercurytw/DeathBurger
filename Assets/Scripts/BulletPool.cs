using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BulletPool
{
    // public string type = "Pickles";
    Stack<IBullet> pool = new Stack<IBullet>();
    private Vector3 temp = new Vector3(-99999f, 0f, 0f);

    // Use this for initialization
    public BulletPool (int amount, string type) {
		for (int i = 0; i < amount; i++) {
            GameObject obj = GameObject.Instantiate((GameObject)Resources.Load(type));
            Debug.Assert(obj);
            obj.transform.position = temp;
            IBullet behavior = obj.GetComponent<IBullet>();
            Debug.Assert(behavior);
            pool.Push(behavior);
		}
	}
<<<<<<< HEAD
	
	// Update is called once per frame
	public void Update () {

	}
=======
>>>>>>> 97a1e5b43d6c76e8bcc984842ce0b8df438f8287

	public IBullet GetBullet(float x, float z, Quaternion heading) {

<<<<<<< HEAD
		if (amount < 1)
			return null;
		amount--;
		return pool.Pop().initialize (x, z, heading, this);
=======
        IBullet bullet = pool.Pop();
        Debug.Assert(null != bullet);
		bullet.initialize (x, z, heading, this);
        bullet.gameObject.SetActive(true);
>>>>>>> 97a1e5b43d6c76e8bcc984842ce0b8df438f8287
	}

	public void ReleaseBullet(IBullet bullet) {
		bullet.gameObject.SetActive (false);
        bullet.gameObject.transform.position = temp;
        pool.Push (bullet);
	}
}