using UnityEngine;

public class ChaseController : MonoBehaviour {

    public float move_speed;
    private Rigidbody body;
    private GameObject player;
    private Vector3 move_vector = new Vector3();
    private NavMeshAgent nav_agent = null;
    private bool use_naieve_pathing = true;

	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody>();
        Debug.Assert(body);
        player = GameObject.FindWithTag("Player");
        Debug.Assert(player);
        nav_agent = GetComponent<NavMeshAgent>();
        use_naieve_pathing = null == nav_agent;
	}
    
	// Update is called once per frame
	void Update () {
        move_vector.Set(player.transform.position.x, 
                        transform.position.y, // intentionally OUR transform, NOT player transform!
                        player.transform.position.z);
        transform.LookAt(move_vector);
        if (!use_naieve_pathing)
            return;

        move_vector.Set(transform.forward.x * move_speed, 0.0f, transform.forward.z * move_speed);
        body.velocity = move_vector;
	}

    // non-naieve navigation is expensive, so only run it on fixed update
    void FixedUpdate() {
        if (use_naieve_pathing)
            return;
        move_vector.Set(player.transform.position.x,
                        transform.position.y, // intentionally OUR transform, NOT player transform!
                        player.transform.position.z);
        nav_agent.SetDestination(move_vector);
    }
}
