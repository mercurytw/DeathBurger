using UnityEngine;
using System.Collections;

public class ChaseNavMesh : MonoBehaviour {
    private NavMeshAgent agent = null;
    private GameObject player = null;
    private Vector3 target = new Vector3();

    // move me out into a header or some shit
    public enum LogicType
    {
        bunny,
        penguin
    }
    public LogicType logic;

    // hacky bulllshit
    // code duplication with ChaseNavMesh.cs
    private float getHeightForTarget() {
        if (LogicType.bunny == logic) {
            return 0.321f;
        }
        return 3f;
    }
    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        Debug.Assert(agent);
        player = GameObject.FindGameObjectWithTag("Player");
        Debug.Assert(player);
	}
	
	// Pathing is probably expensive, so set it on fixed update
    void FixedUpdate() {
        target.Set(player.transform.position.x,
                   getHeightForTarget(),
                   player.transform.position.z);
        agent.SetDestination(target);
    }
}
