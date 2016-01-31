using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class WaveManager : MonoBehaviour {
    private int num_of_enemies = 0;
    private string[] waves = {"wave1", "wave2"};
    private int curr_wave_idx = 0;

    void Start() {
        seeetup();
    }

    void seeetup() {
        num_of_enemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        Debug.Log(num_of_enemies);
        EventManager.OnDeath += OnDeath;
        
    }

    void OnDestroy() {
        EventManager.OnDeath -= OnDeath;
    }

    private int level_to_load = -1;
    void FixedUpdate() {
        if (-1 != level_to_load)
            SceneManager.LoadScene(level_to_load);
    }

    void OnDeath(Death death) {
        if ("Enemy" != death.victim_obj.tag)
            return;
        // Debug.Log("Ded");
        Debug.Log(num_of_enemies);
        if (0 >= --num_of_enemies) {
            level_to_load = (int)((SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCountInBuildSettings);
        }
    }
}
