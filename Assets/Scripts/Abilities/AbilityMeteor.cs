using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityMeteor : RangeDisplay
{ 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape)) { Destroy(gameObject); Time.timeScale = 1f; }
        FollowMouse();
        if (Input.GetMouseButtonDown(0))
        {
            Collider2D[] hit = Physics2D.OverlapCircleAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.localScale.x/2);
            foreach (Collider2D c in hit)
            {
                Debug.Log("hit");
                if (c.gameObject.TryGetComponent<Enemy>(out var enemy))
                {
                    enemy.TakeDamage(this, 7);
                }
            }
            Time.timeScale = 1f;
            GameManager.lastCastTime[GameManager.currentAbilty] = Time.time;
            Destroy(gameObject);
        }
    }
}
