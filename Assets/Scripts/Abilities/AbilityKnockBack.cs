using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityKnockBack : RangeDisplay
{
    [SerializeField] protected float attackPowerRatio = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
        if (Input.GetMouseButtonDown(0))
        {
            Collider2D[] hit = Physics2D.OverlapCircleAll(GameManager.selectedCharacter.transform.position, transform.localScale.x/2);
            foreach (Collider2D c in hit)
            {
                Debug.Log("hit");
                if (c.gameObject.TryGetComponent<Enemy>(out var enemy))
                {
                    enemy.TakeDamage(this, 3);
                    enemy.KnockBacked((enemy.transform.position-GameManager.selectedCharacter.transform.position).normalized*3);
                }
            }
            Time.timeScale = 1f;
            GameManager.lastCastTime[GameManager.currentAbilty] = Time.time;
            Destroy(gameObject);
        }
    }
}
