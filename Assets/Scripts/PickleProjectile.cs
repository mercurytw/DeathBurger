using UnityEngine;
using System.Collections;

public class PickleProjectile : MonoBehaviour, Team.ITeamAligned
{
	public int damage = 1;
	public string type = "Pickles";
    public float bullet_height = 0.5f;
    public float bullet_speed = 1.0f;
	private BulletPool bPool;
    private Vector3 temp = new Vector3();
    private Vector3 velocity = new Vector3();
    private Team.TeamEnum alignment = Team.TeamEnum.kUnaligned;

    public Team.TeamEnum getAlignment() { return alignment; }
	// Use this for initialization
	public void initialize(float x, float z, Quaternion nheading, BulletPool pool, Team.TeamEnum alignment = Team.TeamEnum.kEnemy)
    {
		bPool = pool;
        this.alignment = alignment;

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
        if ("Terrain" == other.gameObject.tag) 
        {
            deinitialize();
        } else if ((Team.TeamEnum.kPlayer == alignment && "Enemy" == other.gameObject.tag) ||
                   (Team.TeamEnum.kEnemy == alignment && "Player" == other.gameObject.tag))
        {
            EventManager.DispatchEvent(new Damage(damage, alignment, other.gameObject.GetHashCode()));
            deinitialize();
        }
    }
}