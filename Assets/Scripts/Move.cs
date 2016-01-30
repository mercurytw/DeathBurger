using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour
{
    public const float upSpeed = 5.0f;
    public const float sideSpeed = 5.0f;

    private Rigidbody phys_obj;
    private Vector3 move_velocity = new Vector3();

    // Use this for initialization
    void Start () {
        phys_obj = GetComponent<Rigidbody>();
        Debug.Assert(phys_obj);
	}

    
	// Update is called once per frame
	void Update ()
    {
        float up = Input.GetAxis("Vertical") * upSpeed;
        float side = Input.GetAxis("Horizontal") * sideSpeed;
        move_velocity.Set(side, 0.0f, up);
        phys_obj.velocity = move_velocity;
    }

}
