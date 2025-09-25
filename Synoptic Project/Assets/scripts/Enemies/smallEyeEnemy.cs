using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class smallEyeEnemy : generalEnemyClass
{
    // Start is called before the first frame update
    void Start()
    {
        hp = 3;
        dmg = 1;
        speed = Random.Range(2, 6);
        lootDropAmount = 2;

    }

    // Update is called once per frame
    void Update()
    {
        Combat();
    }
}
