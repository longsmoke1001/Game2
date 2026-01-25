using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy : ObjectHP
{
    Player[] players=new Player[3];
    Player target;

    // Start is called before the first frame update
    void Start()
    {
        objectAnim = GetComponent<SPUM_Prefabs>()._anim;
        players =FindObjectsByType<Player>(FindObjectsSortMode.None);
        target = players[Random.Range(0, players.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null && !isStunned)
        {
            ChaseTarget();
            
        } 
        else
        {
            objectAnim.SetBool("1_Move", false);
            transform.Translate(knockBackDirection * Time.deltaTime / 0.2f);
        }
    }

    void ChaseTarget()
    {
        if ((target.transform.position - transform.position).magnitude < attackRange)
        {
            if (Time.time - lastAttackTime > speed)
            {
                target.TakeDamage(this,1f);
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

    private void OnDestroy()
    {

    }
}
