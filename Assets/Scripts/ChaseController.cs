using UnityEngine;

public class ChaseController : MonoBehaviour {

    public float move_speed;
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
    float time = 0;
	// Update is called once per frame
	void Update () {
        move_vector.Set(player.transform.position.x, 
                        transform.position.y, // intentionally OUR transform, NOT player transform!
                        player.transform.position.z);
        transform.LookAt(move_vector);
        move_vector.Set(transform.forward.x * move_speed, 0.0f, transform.forward.z * move_speed);
        if (0f == (float)(Time.realtimeSinceStartup % 10))
            Debug.Log(move_vector);
        body.velocity = move_vector;
	}
}
