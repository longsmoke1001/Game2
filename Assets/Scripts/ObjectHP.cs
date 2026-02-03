using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ObjectHP : MonoBehaviour
{
    protected float moveSpeed = 0.5f;
    protected Animator objectAnim;
    public float health = 100f;
    public float maxHealth {get;protected set;}
    [SerializeField] protected float attackRange = 2f;
    [SerializeField] protected float attackTimeNeeded = 0.5f;
    protected float speed = 2f;
    public bool isStunned = false;
    public float lastAttackTime { get; protected set; }
    [field: SerializeField] public float attackPower { get; protected set; } = 5f;
    protected Vector2 knockBackDirection;
    public ObjectHP target;
    // Start is called before the first frame update
    void Awake()
    {
        maxHealth = health;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(ObjectHP source, float attackPowerRatio)
    {
        health -= source.attackPower*attackPowerRatio;
        if (health <= 0f)
        {
            Destroy(gameObject);
        }
    }
    public void Stunned(float stunDuration)
    {
        isStunned = true;
        Invoke("RemoveStun", stunDuration);
    }

    public void KnockBacked(Vector2 direction)
    {
        knockBackDirection = direction;
        isStunned = true;
        Invoke("RemoveStun", 0.2f);
    }
    protected void RemoveStun()
    {
        isStunned = false;
        knockBackDirection = Vector2.zero;
    }

    protected void ChaseTarget()
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
}
