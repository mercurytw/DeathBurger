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
	public void initialize(float nx, float nz, Quaternion nheading, BulletPool pool)
    {
		x = nx;
		z = nz;
		heading = nheading;
		bPool = pool;

        temp.Set(nx, bullet_height, nz);
        gameObject.transform.position = temp;
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