using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FlyingEnemy : generalEnemyClass
{
    [SerializeField] GameObject projectile;
    float timer;

    Vector2 projectileDirection;
    // Start is called before the first frame update
    void Start()
    {
        hp = 5;
        dmg = 1;
        speed = 1;

    }

    // Update is called once per frame
    void Update()
    {
        Combat();
        Attack();
    }

    void Attack()
    {
        timer += Time.deltaTime;

        projectileDirection = (target.transform.position - gameObject.transform.position).normalized;

        if (timer > Random.Range(1, 10))
        {
            GameObject attack = Instantiate(projectile, gameObject.transform.position, Quaternion.identity);
            Rigidbody2D attackrb = attack.GetComponent<Rigidbody2D>();
            attackrb.velocity = new Vector2(projectileDirection.x * 7, projectileDirection.y * 7);
            timer = 0;

            Destroy(attack, 1.5f);
        }

    }

}
