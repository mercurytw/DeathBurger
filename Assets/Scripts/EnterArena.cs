using UnityEngine;
using System.Collections;

public class EnterArena : MonoBehaviour {

    public float movespeed = 0.1f;
    public Behaviour[] to_activate;
    private bool is_descending = false;
    private float target_height = 0;
    private bool was_nonkinematic = false;
    private Rigidbody rb = null;
    private NavMeshAgent mesh_agent = null;
    private bool use_naieve_pathing = false;
    public enum LogicType
    {
        bunny,
        penguin
    }
    public LogicType logic;
	// Use this for initialization
	void Start () {
        Vector3 look_at = new Vector3(0.0f, gameObject.transform.position.y, 0.0f);
        gameObject.transform.LookAt(look_at);
        tmp_vec = movespeed * new Vector3(0f, 0f, 1f);
        rb = gameObject.GetComponent<Rigidbody>();
        if (!rb)
            return;
        was_nonkinematic = !rb.isKinematic;
        rb.isKinematic = true;
        mesh_agent = gameObject.GetComponent<NavMeshAgent>();
        if (use_naieve_pathing = null == mesh_agent) {
            mesh_agent.SetDestination(look_at);
        }

	}

    // hacky bulllshit
    // code duplication with ChaseNavMesh.cs
    private float getHeightForTarget() {
        if (LogicType.bunny == logic) {
            return 0.321f; 
        }
        return 3f;
    }

    private void ReleaseControl() {
        enabled = false;
        foreach (Behaviour be in to_activate)
            be.enabled = true;
        if (null != rb) {
            if (was_nonkinematic)
                rb.isKinematic = false;
            RigidbodyConstraints consts = rb.constraints;
            consts |= RigidbodyConstraints.FreezePositionY;
            rb.constraints = consts;
        }
    }

    private Vector3 tmp_vec;
	// Update is called once per frame
	void Update () {
        if (!use_naieve_pathing)
            return;
        transform.Translate(tmp_vec);
        if (is_descending && 
            transform.position.y <= target_height) {
            tmp_vec.Set(transform.position.x, target_height, transform.position.z);
            ReleaseControl();
        }
	}

    void OnTriggerEnter(Collider col) {
        if (is_descending)
            return;


        if (!use_naieve_pathing) {
            ReleaseControl();
            return;
        }
        target_height = getHeightForTarget();
        is_descending = true;
        tmp_vec.Set(0f, -movespeed, 0f);
    }
}
