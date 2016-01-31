using UnityEngine;
using System.Collections;

public class TextRotator : MonoBehaviour {

    public float rotateStartTime;
    public float turnSpeed;
    private float time;
    private float rotationTracker = 0;
    private float startRotation = 0;
	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if (time > rotateStartTime && rotationTracker < 90)
        {
            startRotation = transform.rotation.x;
            transform.Rotate(new Vector3(1, 0, 0) *-turnSpeed * Time.deltaTime);
            rotationTracker += transform.position.x - startRotation;
        }

	}
}
