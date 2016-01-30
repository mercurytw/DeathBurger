using UnityEngine;

public class ChaseController : MonoBehaviour {

    public float move_speed = 3.0f;
    private Rigidbody body;
    private GameObject player;
    private Vector3 move_vector = new Vector3();

	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody>();
        Debug.Assert(body);
        player = GameObject.FindWithTag("Player");
        Debug.Assert(player);
	}
	
	// Update is called once per frame
	void Update () {
        move_vector.Set(player.transform.position.x, 
                        transform.position.y, // intentionally OUR transform, NOT player transform!
                        player.transform.position.z);
        transform.LookAt(move_vector);
        move_vector.Set(transform.forward.x * move_speed, 0.0f, transform.forward.z * move_speed);
        body.velocity = move_vector;
	}
}
