using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI : MonoBehaviour {

    public Text health = null;
    float var = -1.0f;
    // bool ready = false;
    Killable k;

    void Start () {
        k = GameObject.Find("Player").GetComponent<Killable>();
        Debug.Assert(k);
    }

    void Update () {
        var = k.health;
        health.text = "Health: " + var.ToString();
    }
}