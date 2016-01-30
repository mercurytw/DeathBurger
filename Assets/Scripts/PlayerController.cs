#define DEBUG_PLAYER_LOOK_VECTOR

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class PlayerController : MonoBehaviour
{
    public const float upSpeed = 5.0f;
    public const float sideSpeed = 5.0f;
    public GameObject model;
    private Camera cam;

    private Rigidbody phys_obj;
    private Vector3 temp_vec = new Vector3();

    private BulletPool gun;
    public const float rate_of_fire_seconds = 0.5f;
    // Use this for initialization
    void Start ()
    {
        phys_obj = GetComponent<Rigidbody>();
        Debug.Assert(phys_obj);
        model = gameObject.transform.GetChild(2).gameObject;
        Debug.Assert(model);
        cam = Camera.main;

        gun = new BulletPool(20, "Bullet");
    }

    private float shoot_time_agg = float.PositiveInfinity;
	// Update is called once per frame
	void Update ()
    {
        float up = Input.GetAxis("Vertical") * upSpeed;
        float side = Input.GetAxis("Horizontal") * sideSpeed;
        temp_vec.Set(side, 0.0f, up);
        phys_obj.velocity = temp_vec;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] hits;
        hits = Physics.RaycastAll(ray);
        foreach (RaycastHit hit in hits)
        {
            if (hit.collider.tag=="Floor")
            {
                Vector3 pointVector = new Vector3(hit.point.x, model.transform.position.y, hit.point.z);
                model.transform.LookAt(pointVector);
                break;
            }
        }

#if DEBUG_PLAYER_LOOK_VECTOR
        Debug.DrawRay(model.transform.position, model.transform.forward * 1.5f, Color.cyan);
#endif

        if (rate_of_fire_seconds <= (shoot_time_agg += Time.deltaTime))
        {
            shoot_time_agg = 0.0f;
            gun.GetBullet(transform.position.x, transform.position.z, model.transform.rotation);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

}
