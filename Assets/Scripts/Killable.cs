using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

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
        //test
        //SceneManager.LoadScene("Main", LoadSceneMode.Single);
        //return;

        if (dmg.team == team || 
            dmg.recipient_hash != gameObject.GetHashCode())
            return;

        if (0 < (health -= dmg.amount))
            return;

        Debug.Log("Gonna die");
        EventManager.DispatchEvent(new Death(gameObject.GetHashCode(), gameObject));
        die_later = true;
    }

    void Update() {
        if (die_later) {
                gameObject.SetActive(false);
        }
    }

    void OnDisable() {
        EventManager.OnInflictDamage -= TakeDamage;
    }

    //public float GetHealth()
    //{
    //    return health;
    //}
}
