﻿#define DEBUG_PLAYER_LOOK_VECTOR

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class PlayerController : MonoBehaviour, Team.ITeamAligned
{
    public const float upSpeed = 5.0f;
    public const float sideSpeed = 5.0f;
    public GameObject model;
    private Camera cam;

    private Rigidbody phys_obj;
    private Vector3 temp_vec = new Vector3();
    bool isDead = false;

   // private BulletPool gun;
    //public const float rate_of_fire_seconds = 1.0f;
    public const Team.TeamEnum team = Team.TeamEnum.kPlayer;

    public Team.TeamEnum getAlignment() { return Team.TeamEnum.kPlayer; }
    // Use this for initialization
    void Start ()
    {
       
        phys_obj = GetComponent<Rigidbody>();
        Debug.Assert(phys_obj);
        model = gameObject.transform.GetChild(2).gameObject;
        Debug.Assert(model);
        cam = Camera.main;

        EventManager.OnDeath += OnPlayerDeath;
        gameObject.SetActive(true);

        //gun = new BulletPool(20, "Bullet");
        
    }

    void OnDestroy() {
        if (!isDead)
            EventManager.OnDeath -= OnPlayerDeath;
    }

    void OnPlayerDeath(Death death) {
        if (death.victim == gameObject.GetHashCode()) {
            DieInTheGameDieInRealLife();
        }
    }

    void DieInTheGameDieInRealLife() {
        EventManager.OnDeath -= OnPlayerDeath;
        isDead = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

   // private float shoot_time_agg = float.PositiveInfinity;
	// Update is called once per frame
	void Update ()
    {
        float up = Input.GetAxis("Vertical") * upSpeed;
        float side = Input.GetAxis("Horizontal") * sideSpeed;
        temp_vec.Set(side, 0.0f, up);
        phys_obj.velocity = temp_vec;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] hits;
        hits = Physics.RaycastAll(ray);
        foreach (RaycastHit hit in hits)
        {
            if (hit.collider.tag=="Floor")
            {
                Vector3 pointVector = new Vector3(hit.point.x, model.transform.position.y, hit.point.z);
                model.transform.LookAt(pointVector);
                break;
            }
        }

#if DEBUG_PLAYER_LOOK_VECTOR
        Debug.DrawRay(model.transform.position, model.transform.forward * 1.5f, Color.cyan);
#endif

        
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            DieInTheGameDieInRealLife();
        }
    }

}
