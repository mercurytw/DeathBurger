using UnityEngine;

public class Death : IBurgerEvent {
    public int victim;
    public GameObject victim_obj;
    public static int event_id = 0x02;

    public int getEventClass() { return Death.event_id; }
    public Death(int victim_hash, GameObject victim_object) {
        this.victim = victim_hash;
        this.victim_obj = victim_object;
    }
}
