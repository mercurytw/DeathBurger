using UnityEngine;
using System.Collections;

public class WaveManager : MonoBehaviour {

	public int MAX_WAVE = 2;
	public Wave[] waves;
	public WaveFactory waveFactory = new WaveFactory ();
	int currentWave = 0;

	// Use this for initialization
	void Start () {
		waves = new Wave[MAX_WAVE];
		storeWaves ();
	}
	
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
}
