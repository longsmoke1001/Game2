using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHP : MonoBehaviour
{
    protected float moveSpeed = 0.5f;
    protected Animator objectAnim;
    public float health = 100f;
    [SerializeField] protected float attackRange = 2f;
    [SerializeField] protected float attackTimeNeeded = 0.5f;
    protected float speed = 2f;
    public bool isStunned = false;
    public float lastAttackTime { get; protected set; }
    [field: SerializeField] public float attackPower { get; protected set; } = 5f;
    protected Vector2 knockBackDirection;
    // Start is called before the first frame update
    void Start()
    {
        lastAttackTime = Time.time;
        //GetDamaged += TakeDamage;
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
}
