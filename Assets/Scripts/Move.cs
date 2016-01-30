using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour
{
    public const float upSpeed = 5.0f;
    public const float sideSpeed = 5.0f;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        //if (Input.GetKey(KeyCode.W))
        //{

        //}

        float up = Input.GetAxis("Vertical") * upSpeed * Time.deltaTime;
        float side = Input.GetAxis("Horizontal") * sideSpeed * Time.deltaTime;

        transform.Translate(side,0,up);
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

}
