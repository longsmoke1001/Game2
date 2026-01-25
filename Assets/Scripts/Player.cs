using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class Player : ObjectHP
{
    public bool isSelected = false;
    public Vector2 destination;
    public Enemy target;
    [field: SerializeField] public Button skillButton { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        destination= transform.position;
        objectAnim = GetComponent<SPUM_Prefabs>()._anim;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(transform.position, destination, Color.green);
        //input handling
        if (isStunned)
        {
            objectAnim.SetBool("1_Move", false);
            transform.Translate(knockBackDirection * Time.deltaTime / 0.2f);
        }
        else if (target != null)
            ChaseTarget();
        else
            MoveToDestination();
    }

    void ChaseTarget()
    {
        if ((target.transform.position - transform.position).magnitude < attackRange)
        {
            if (Time.time - lastAttackTime > speed)
            {
                target.TakeDamage(this, 1f);
                lastAttackTime = Time.time;
                objectAnim.SetTrigger("2_Attack");
                objectAnim.SetBool("1_Move", false);
            }
        }
        else
        {
            if (Time.time - lastAttackTime < attackTimeNeeded)
            {
                objectAnim.SetBool("1_Move", false);
            }
            else
            {
                Vector2 movingVelocity = moveSpeed * (target.transform.position - transform.position).normalized * Time.deltaTime;
                transform.Translate(movingVelocity);
                objectAnim.SetBool("1_Move", true);
                if (movingVelocity.x > 0)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }
                else
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }
            }
        }
    }

    void MoveToDestination()
    {
        if ((destination - (Vector2)transform.position).magnitude > 0.1f)
        {
            Vector2 movingVelocity = moveSpeed * (destination - (Vector2)transform.position).normalized * Time.deltaTime;
            transform.Translate(movingVelocity);
            objectAnim.SetBool("1_Move", true);
            if (movingVelocity.x > 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
        else
        {
            objectAnim.SetBool("1_Move", false);
        }
    }
}
