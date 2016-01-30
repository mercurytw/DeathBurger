using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Wave : MonoBehaviour {

	public Stack<IEnemy> enemies = new Stack<IEnemy>();
	public Stack<int> intervals = new Stack<int>();
	int activeEnemies = 0; //Spawn parts of waves at a time

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (enemies.Count > 0) {
			if (activeEnemies == 0)
				spawn ();
		}
	}

	void spawn() {
		activeEnemies = (intervals.Peek() < enemies.Count)? intervals.Pop():enemies.Count;
		for (int i = 0; i < activeEnemies; i++) {
						Instantiate(enemies.Pop());
		}
	}


}
