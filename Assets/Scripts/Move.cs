using UnityEngine;
//using UnityEngine.SceneManagement;
using System.Collections;

public class Move : MonoBehaviour
{
    public const float upSpeed = 5.0f;
    public const float sideSpeed = 5.0f;
    private GameObject model;
    private Camera cam;

    private Rigidbody phys_obj;
    private Vector3 temp_vec = new Vector3();

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
        temp_vec.Set(side, 0.0f, up);
        phys_obj.velocity = temp_vec;

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] hits = Physics.RaycastAll(ray);
        foreach (RaycastHit hit in hits)
        {
            if (hit.collider.tag=="Floor")
            {
                temp_vec.Set(hit.point.x, model.transform.position.y, hit.point.z);
                model.transform.LookAt(temp_vec);
                break;
            }
        }
    }

<<<<<<< HEAD
    void OnCollisionEnter(Collision col) {
        if (col.gameObject.tag == "Enemy") {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
=======
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
>>>>>>> 97a1e5b43d6c76e8bcc984842ce0b8df438f8287
        }
    }

}
