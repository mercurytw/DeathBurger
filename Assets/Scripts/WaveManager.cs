using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class WaveManager : MonoBehaviour {
    private int num_of_enemies = 0;
    void Start() {
        num_of_enemies = GameObject.FindGameObjectsWithTag("Respawn").Length;
        EventManager.OnDeath += OnDeath;
    }

    void OnDestroy() {
        EventManager.OnDeath -= OnDeath;
    }

    void OnDeath(Death death) {
        if ("Enemy" != death.victim_obj.tag)
            return;

        if (0 == --num_of_enemies) {
            SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCount);
        }
    }
#if BUTTS
    public string json_file;
	//public int MAX_WAVE = 2;
    public ArrayList waves = new ArrayList();
    //public WaveFactory waveFactory = null;
    int currentWave = 0;
    int num_live_enemies = 0;

    // Use this for initialization
    void Start() {
        JSONObject json = new JSONObject((Resources.Load(json_file) as TextAsset).text);
        Debug.Assert(json.IsArray);
        foreach (JSONObject wave_json in json.list) {
            waves.Add(new Wave(wave_json));
        }

    }

    
	
    /*
	// Update is called once per frame
	void FixedUpdate () {
		for (int i = 0; i < MAX_WAVE; i++) {
			if (waves [i].enemies.Count == 0)
				waves [i] = waveFactory.buildWave ();
		}
	}

	void storeWaves() {
		for(int i = 0; i < MAX_WAVE; i++)
		{
			waves[i] = waveFactory.buildWave ();
		}
	}

	void removeWave() {
		Destroy (waves [currentWave]);
		waves [currentWave] = null;
		currentWave = (currentWave + 1) % MAX_WAVE;
	}
    */
#endif
}
