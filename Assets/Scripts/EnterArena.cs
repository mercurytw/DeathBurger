using UnityEngine;
using System.Collections;

public class EnterArena : MonoBehaviour {

    public float movespeed = 0.1f;
    public Behaviour[] to_activate;
    private bool is_descending = false;
    private float target_height = 0;
    public enum LogicType
    {
        bunny,
        penguin
    }
    public LogicType logic;
	// Use this for initialization
	void Start () {
        gameObject.transform.LookAt(new Vector3(0.0f, gameObject.transform.position.y, 0.0f));
        tmp_vec = movespeed * new Vector3(0f, 0f, 1f);
        
	}

    // hacky bulllshit
    private float getHeightForTarget() {
        if (LogicType.bunny == logic) {
            return 0.3f; 
        }
        return 3f;
    }

    private Vector3 tmp_vec;
	// Update is called once per frame
	void Update () {
        transform.Translate(tmp_vec);
        if (is_descending && 
            transform.position.y <= target_height) {
            tmp_vec.Set(transform.position.x, target_height, transform.position.z);
            enabled = false;
            foreach (Behaviour be in to_activate)
                be.enabled = true;
            
        }
	}

    void OnTriggerEnter(Collider col) {
        if (is_descending)
            return;

        target_height = getHeightForTarget();
        is_descending = true;
        tmp_vec.Set(0f, -movespeed, 0f);
    }
}
