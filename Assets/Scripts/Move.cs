using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Move : MonoBehaviour
{
    public const float upSpeed = 5.0f;
    public const float sideSpeed = 5.0f;
    private GameObject model;
    private Camera cam;

    private Rigidbody phys_obj;
    private Vector3 temp_vec = new Vector3();

    public BulletPool gun;
    public const float delay = 0.2f;
    public float timer = 0.0f;

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

    private bool bShoot = true;
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
            if (hit.collider.tag=="Finish")
            {
                Vector3 pointVector = new Vector3(hit.point.x, model.transform.position.y, hit.point.z);
                model.transform.LookAt(pointVector);
                //if (timer <= Time.time)
                break;
            }
        }

        if (bShoot)
        {
            bShoot = false;
            gun.GetBullet(transform.position.x, transform.position.z, model.transform.rotation);
            timer = Time.time + delay;
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
