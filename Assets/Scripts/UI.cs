using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class UI : MonoBehaviour {

    public Text health = null;
    public Text level = null;
    float var = -1.0f;
    float wave = -1.0f;
    // bool ready = false;
    Killable k;
    WaveManager w;

    void Start () {
        k = GameObject.Find("Player").GetComponent<Killable>();
        Debug.Assert(k);
        //w = GameObject.Find("MagicSauce").GetComponent<WaveManager>();
        //Debug.Assert(w);
        StartCoroutine(ShowLevel());
    }

    IEnumerator ShowLevel()
    {
        //wave = w.curr_wave_idx - 1;
        //level.text = "WAVE " + wave.ToString();
        wave = SceneManager.GetActiveScene().buildIndex - 1;
        level.fontSize = 60;
        level.text = "WAVE " + wave.ToString();
        yield return new WaitForSeconds(5);
        level.fontSize = 48;
        //level.text = "";
    }

    void Update () {
        var = k.health;
        health.text = "Health: " + var.ToString();
    }
}