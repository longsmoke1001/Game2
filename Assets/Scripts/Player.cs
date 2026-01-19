using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float attackPower = 25f;
    float health = 100f;
    float speed = 1f;
    float lastAttackTime;

    // Start is called before the first frame update
    void Start()
    {
        lastAttackTime=Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastAttackTime > speed)
        {
            Attack();
            lastAttackTime = Time.time;
        }
    }
    void Attack() { }
}
