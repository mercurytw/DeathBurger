using UnityEngine;
using System.Collections;

public class IBullet : MonoBehaviour
{
	public int damage = 1;
	public string type = "Pickles";
    public float bullet_height = 2f;
	private BulletPool bPool;
    private Vector3 temp = new Vector3();

	float x;
	float z;
	Quaternion heading;

	// Use this for initialization
<<<<<<< HEAD
	public IBullet initialize(float nx, float nz, Quaternion nheading, BulletPool pool) {
=======
	public void initialize(float nx, float nz, Quaternion nheading, BulletPool pool)
    {
>>>>>>> 97a1e5b43d6c76e8bcc984842ce0b8df438f8287
		x = nx;
		z = nz;
		heading = nheading;
		bPool = pool;
<<<<<<< HEAD
		return this;
=======

        temp.Set(nx, bullet_height, nz);
        gameObject.transform.position = temp;
>>>>>>> 97a1e5b43d6c76e8bcc984842ce0b8df438f8287
	}
	
	

	void deinitialize() {
		bPool.ReleaseBullet (this);
	}

    void onCollisionEnter(Collider col)
    {
        if (col.tag == "Enemy")
        {
            deinitialize();
        }
    }
}