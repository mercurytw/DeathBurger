
public class Death : IBurgerEvent {
    public int victim;
    public static int event_id = 0x02;

    public int getEventClass() { return Death.event_id; }
    public Death(int victim_hash) {
        this.victim = victim_hash;
    }
}
