using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityCrowdControl : RangeDisplay
{
    [SerializeField] protected float attackPowerRatio = 3f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        FollowMouse();
        if (Input.GetMouseButtonDown(0))
        {
            Collider2D[] hit = Physics2D.OverlapCircleAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.localScale.x/2);
            foreach (Collider2D c in hit)
            {
                Debug.Log("hit");
                if (c.gameObject.TryGetComponent<Enemy>(out var enemy))
                {
                    enemy.TakeDamage(this, 3);
                    enemy.KnockBacked(Camera.main.ScreenToWorldPoint(Input.mousePosition) - enemy.transform.position);
                }
            }
            GameManager.lastCastTime[GameManager.currentAbilty] = Time.time;
            Time.timeScale = 1f;
            Destroy(gameObject);
        }
    }
}
