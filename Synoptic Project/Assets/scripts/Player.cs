using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] GameObject player;
    [SerializeField] GameObject prefabBullet;
    [SerializeField] GameObject gameCamera;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator animator;
    public Transform PlayerPos;
    public Transform bulletSpawn;

    [Header("Currency")]
    [SerializeField] private TextMeshProUGUI crystalPointText;
    public static int crystalCount;


    //bullet variables
    Vector2 mousePos;
    Vector2 playerPos;
    Vector2 direction;

    //combat variables
    public static float hp;
    public static float armour;
    public static float dmg;
    public static float hpRecover; // time taken to passively heal player
    float damageTaken;
    float speed;



    float Timer;
    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;

        rb.GetComponent<Rigidbody2D>();

        crystalCount = 1000;

        dmg = 1;
        armour = 1;
        hp = 10;
        hpRecover = 20;
    }

    // Update is called once per frame
    void Update()
    {
        if (Buttons.open == false)
        {
            Controls();
            animations();
            Combat();
            Healing();
        }
        else { }
        currency();
    }

    void Controls()
    {
        gameCamera.transform.position = new Vector3(PlayerPos.position.x, PlayerPos.position.y, PlayerPos.position.z - 1); //camera follow

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            player.transform.position = (new Vector2(player.transform.position.x, player.transform.position.y + speed));
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            player.transform.position = (new Vector2(player.transform.position.x, player.transform.position.y - speed));
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            player.transform.position = (new Vector2(player.transform.position.x - speed, player.transform.position.y));
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            player.transform.position = (new Vector2(player.transform.position.x + speed, player.transform.position.y));
            player.transform.localScale = new Vector3(-1, 1, 1);
        }

        else
        {
            rb.velocity = Vector3.zero;
            player.transform.localScale = new Vector3(1, 1, 1);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 0.10f;
        }
        else speed = 0.05f;
    }

    void animations()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            animator.SetBool("up", true);
        }
        else animator.SetBool("up", false);

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            animator.SetBool("down", true);
        }
        else animator.SetBool("down", false);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetBool("side", true);
        }

        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetBool("side", true);
        }
        else animator.SetBool("side", false);
    }

    void Combat()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            playerPos = PlayerPos.position;
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            direction = (mousePos - playerPos).normalized;

            GameObject bullet = Instantiate(prefabBullet, bulletSpawn.position, Quaternion.identity);
            Rigidbody2D bulletrb = bullet.GetComponent<Rigidbody2D>();
            bulletrb.velocity = (new Vector3(direction.x, direction.y, 0) * 15);
        }
    }

    void Healing()
    {
        Timer = Timer + Time.deltaTime;

        if (Timer >= hpRecover)
        {
            hp += 0.1f;
            Timer = 0;
        }
    }

    void currency()
    {
        crystalPointText.text = "Crystals: " + crystalCount.ToString();
    }



private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "basicEnemy" || collision.gameObject.tag == "flyingEnemy")
        {
            damageTaken = -1 + armour;
            if (damageTaken > 0) damageTaken = 0;
            hp += damageTaken;
        }

        else if (collision.gameObject.tag == "projectile")
        {
            damageTaken = -3 + armour;
            if (damageTaken > 0) damageTaken = 0;
            hp += damageTaken;
        }

        else if(collision.gameObject.tag == "redCurrency")
        {
            crystalCount++;
            Destroy(collision.gameObject);
        }
    }

private void OnTriggerStay2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "heal"))
        {
            //if (Input.GetKey(KeyCode.Space) && PointSystem.pointCount >= 50 && hp != 10)
            //{
            //    PointSystem.pointCount -= 50;
            //    hp = 10;
            //}
        }
    }

}

