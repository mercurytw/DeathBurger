using UnityEngine;
using System.Collections;

public class Killable : MonoBehaviour {
    public float health = 1.0f;
    public Team.TeamEnum team = Team.TeamEnum.kUnaligned;
	// Use this for initialization
	void Start () {
        EventManager.OnInflictDamage += TakeDamage;
	}
	
	void TakeDamage(Damage dmg) {
        if (dmg.team == team)
            return;

        if (0 < (health -= dmg.amount))
            return;

        EventManager.DispatchEvent(new Death(gameObject.GetHashCode()));
        gameObject.SetActive(false);
    }

    void OnDisable() {
        EventManager.OnInflictDamage -= TakeDamage;
    }
}
