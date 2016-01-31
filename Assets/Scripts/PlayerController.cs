#define DEBUG_PLAYER_LOOK_VECTOR

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour, Team.ITeamAligned
{
    public float move_speed = 5.0f;
    public GameObject model;
    private Camera cam;

    private Rigidbody phys_obj;
    private Vector3 temp_vec = new Vector3();
    bool isDead = false;

    //public Texture2D arrow;
    public Image arrow;

    // private BulletPool gun;
    //public const float rate_of_fire_seconds = 1.0f;
    public const Team.TeamEnum team = Team.TeamEnum.kPlayer;

    public Team.TeamEnum getAlignment() { return Team.TeamEnum.kPlayer; }

    float offset;

    // Use this for initialization
    void Start()
    {
        Cursor.visible = false;
        //Cursor.SetCursor(arrow, Vector2.zero, CursorMode.Auto);
        phys_obj = GetComponent<Rigidbody>();
        Debug.Assert(phys_obj);
        model = gameObject.transform.GetChild(1).gameObject;
        Debug.Assert(model);
        cam = Camera.main;

        EventManager.OnDeath += OnPlayerDeath;
        gameObject.SetActive(true);

        offset = cam.transform.position.z;
        //gun = new BulletPool(20, "Bullet");

    }

    void OnDestroy()
    {
        if (!isDead)
            EventManager.OnDeath -= OnPlayerDeath;
    }

    void OnPlayerDeath(Death death)
    {
        if (death.victim == gameObject.GetHashCode())
        {
            DieInTheGameDieInRealLife();
        }
    }

    void DieInTheGameDieInRealLife()
    {
        EventManager.OnDeath -= OnPlayerDeath;
        isDead = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // private float shoot_time_agg = float.PositiveInfinity;
    // Update is called once per frame
    void Update()
    {
        //mouse arrow
        if (Input.GetKeyDown("escape"))
        {
            print("Quitting");
            Cursor.visible = true;
        }
        Vector3 pos = Input.mousePosition;
        arrow.transform.position = pos;

        Vector3 world_pos = Camera.main.ScreenToWorldPoint(pos);
        print(world_pos);
        Vector3 center = (/*model.*/transform.position + new Vector3(0, 0, offset));
        Vector3 direction = world_pos - center;

        Quaternion rot = Quaternion.LookRotation(direction, new Vector3(center.x,1,center.z));

        arrow.transform.eulerAngles = new Vector3(0, 0, -rot.eulerAngles.y);

        //player movement
        float up = Input.GetAxis("Vertical");
        float side = Input.GetAxis("Horizontal");
        temp_vec.Set(side, 0.0f, up);
        temp_vec.Normalize();
        temp_vec = move_speed * temp_vec;
        phys_obj.velocity = temp_vec;

        //player direction
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] hits;
        hits = Physics.RaycastAll(ray);
        foreach (RaycastHit hit in hits)
        {
            if (hit.collider.tag == "Floor")
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
