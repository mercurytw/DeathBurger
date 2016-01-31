using UnityEngine;

public class Damage : IBurgerEvent {
    public int amount;
    public Team.TeamEnum team;
    public int recipient_hash;
    public static int event_id = 0x01;

    public int getEventClass() { return Damage.event_id; }
    public Damage(int amount, Team.TeamEnum team, int recipient_hash) {
        this.amount = amount;
        this.team = team;
        this.recipient_hash = recipient_hash;
    }
}
