using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 100f;
    [SerializeField] Player player;
    // Start is called before the first frame update
    void Start()
    {
        player.OnAttack += TakeDamage;
    }

    // Update is called once per frame
    void Update()
    {
        
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

    private void OnDestroy()
    {
        player.OnAttack -= TakeDamage;
    }
}
