using UnityEngine;

public class EventManager {

    // ======== Damage
    public delegate void InflictDamage(Damage dmg);
    public static event InflictDamage OnInflictDamage;

    // ======== Death
    public delegate void Die(Death death);
    public static event Die OnDeath;

    public static void DispatchEvent(IBurgerEvent e) {
        if ( e.getEventClass() == Damage.event_id) {
            if (null != OnInflictDamage) {
                OnInflictDamage((Damage)e);
            }
            return;
        }
        else if ( e.getEventClass() == Death.event_id) {
            if (null != OnDeath) {
                OnDeath((Death)e);
            }
            return;
        }

        Debug.LogError("Attempted to dispatch unknown event!");
    }
}
