using UnityEngine;
using System.Collections;

public class Killable : MonoBehaviour {
    public float health = 1.0f;
    public Team.TeamEnum team = Team.TeamEnum.kUnaligned;
    private bool die_later;
	// Use this for initialization
	void Start () {
        EventManager.OnInflictDamage += TakeDamage;
        die_later = false;
	}
	
	void TakeDamage(Damage dmg) {
        if (dmg.team == team)
            return;

        if (0 < (health -= dmg.amount))
            return;

        EventManager.DispatchEvent(new Death(gameObject.GetHashCode()));
    }

    void Update() {
        if (die_later) {
            gameObject.SetActive(false);
        }
    }

    void OnDisable() {
        EventManager.OnInflictDamage -= TakeDamage;
    }
}
