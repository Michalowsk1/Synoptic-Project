using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class generalEnemyClass : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject target;
    [SerializeField] GameObject hitFrame;
    [SerializeField] GameObject deathAnim;
    [SerializeField] GameObject healthBar;

    [SerializeField] GameObject pointDrop;

    bool follow;
    public bool hit;
    //bool knockback;

    public float hp;
    public float dmg;
    public int lootDropAmount;
    public float speed;

    Vector2 knockbackDirection;


    void Start()
    {
        hit = false;
        hitFrame.SetActive(false);
        agent.speed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = new Vector3(target.transform.rotation.x, target.transform.rotation.y, 25.0f);

        followPlayer();
        Combat();
    }

    void followPlayer()
    {
        if (follow)
        {
            agent.SetDestination((target.transform.position));
        }
    }

    public void Combat()
    {
        target = GameObject.Find("/Player");
        if (hit)
        {
            hp -= Player.dmg;
            StartCoroutine(HIT());
            healthBar.transform.localScale = new Vector3((0.25f * hp), healthBar.transform.localScale.y, healthBar.transform.localScale.z);
            hit = false;
        }

        if (hp <= 0)
        {
            Destroy(gameObject);
            GameObject Prefab = Instantiate(deathAnim, gameObject.transform.position, Quaternion.identity);
            Destroy(Prefab, 0.5f);

            for (int i = 0; i < lootDropAmount; i++)
            {
                GameObject loot = Instantiate(pointDrop, gameObject.transform.position, Quaternion.identity);
                Rigidbody2D lootrb = loot.GetComponent<Rigidbody2D>();
                lootrb.velocity = (new Vector2(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f)));

                Destroy(loot, 5.0f);
            }


        }

        
    }

    IEnumerator HIT()
    {
        hitFrame.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        hitFrame.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "bullet")
        {
            hit = true;
        }
    }
}

