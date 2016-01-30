using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

    public const float rate_of_fire_seconds = 1.0f;
    public Team.TeamEnum team = Team.TeamEnum.kEnemy;
    public Transform bullet_heading;
    public string bullet_class;
    private BulletPool gun;
    public int pool_size = 20;

    // Use this for initialization
    void Start () {
        gun = new BulletPool(pool_size, bullet_class);
	}

    private float shoot_time_agg = float.PositiveInfinity;
	// Update is called once per frame
	void Update () {
        if (rate_of_fire_seconds <= (shoot_time_agg += Time.deltaTime)) {
            shoot_time_agg = 0.0f;
            gun.GetBullet(bullet_heading.position.x, bullet_heading.position.z, bullet_heading.rotation, team);
        }
    }
}
