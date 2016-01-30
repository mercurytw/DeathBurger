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
    private Vector3 move_velocity = new Vector3();

    // Use this for initialization
    void Start ()
    {
        phys_obj = GetComponent<Rigidbody>();
        Debug.Assert(phys_obj);
        model = gameObject.transform.GetChild(2).gameObject;
        cam = Camera.main;
    }

	// Update is called once per frame
	void Update ()
    {
        float up = Input.GetAxis("Vertical") * upSpeed;
        float side = Input.GetAxis("Horizontal") * sideSpeed;
        move_velocity.Set(side, 0.0f, up);
        phys_obj.velocity = move_velocity;

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] hits;
        hits = Physics.RaycastAll(ray);
        foreach (RaycastHit hit in hits)
        {
            if (hit.collider.tag=="Floor")
            {
                model.transform.LookAt(new Vector3(hit.point.x,this.transform.position.y,hit.point.z));
                break;
            }
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
