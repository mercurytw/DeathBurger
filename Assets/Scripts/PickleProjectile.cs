using UnityEngine;
using System.Collections;

public class PickleProjectile : MonoBehaviour
{
	public int damage = 1;
	public string type = "Pickles";
    public float bullet_height = 0.5f;
    public float bullet_speed = 1.0f;
	private BulletPool bPool;
    private Vector3 temp = new Vector3();
    private Vector3 velocity = new Vector3();

	// Use this for initialization
	public void initialize(float x, float z, Quaternion nheading, BulletPool pool)
    {
		bPool = pool;

        temp.Set(x, bullet_height, z);
        gameObject.transform.position = temp;
        gameObject.transform.rotation = nheading;
        velocity.Set(0.0f, 0.0f, bullet_speed);
    }
	
	void Update() 
    {
        transform.Translate(velocity);
    }

	void deinitialize() {
		bPool.ReleaseBullet (this);
	}

    void OnTriggerEnter(Collider other)
    {
        if ("Enemy" == other.gameObject.tag ||
            "Terrain" == other.gameObject.tag)
        {
            deinitialize();
        }
    }
}