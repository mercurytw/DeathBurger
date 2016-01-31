
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BulletPool
{
    // public string type = "Pickles";
    Stack<IProjectile> pool = new Stack<IProjectile>();
    private Vector3 temp = new Vector3(-99999f, 0f, 0f);

	// Use this for initialization
	public BulletPool (int amount, string type) {
		for (int i = 0; i < amount; i++) {
            GameObject obj = GameObject.Instantiate((GameObject)Resources.Load(type));
            Debug.Assert(obj);
            obj.transform.position = temp;
            IProjectile behavior = obj.GetComponent<IProjectile>();
            Debug.Assert(behavior != null);
            pool.Push(behavior);
		}
	}

	public IProjectile GetBullet(float x, float z, Quaternion heading, Team.TeamEnum alignment = Team.TeamEnum.kEnemy) {

        IProjectile bullet = pool.Pop();
        Debug.Assert(null != bullet);
		bullet.initialize (x, z, heading, this, alignment);
        bullet.getGameObject().SetActive(true);
        return bullet;
	}

	public void ReleaseBullet(IProjectile bullet) {
		bullet.getGameObject().SetActive (false);
		bullet.getGameObject().transform.position = temp;
		pool.Push (bullet);
	}
}
