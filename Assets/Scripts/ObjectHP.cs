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
    public float lastAttackTime { get; protected set; }
    [field: SerializeField] public float attackPower { get; protected set; } = 5f;
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
    public void GetAttacked(ObjectHP gameObject)
    {
        TakeDamage(gameObject.attackPower);
    }
    void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0f)
        {
            Destroy(gameObject);
            //Die();
        }
    }
}
