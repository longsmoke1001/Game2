using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityStun : RangeDisplay
{
    [SerializeField] protected float attackPowerRatio = 3f;
    Player player;
    Vector2 distanceFromPlayerToLocation;
    // Start is called before the first frame update
    void Start()
    {
        player = GameManager.selectedCharacter;
    }

    // Update is called once per frame
    void Update()
    {
        FollowMouse();
        if (Input.GetMouseButtonDown(0))
        {
            Collider2D[] hit=Physics2D.OverlapCircleAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.localScale.x/2);
            foreach (Collider2D c in hit)
            {
                Debug.Log("hit");
                if (c.gameObject.TryGetComponent<Enemy>(out var enemy))
                {
                    enemy.TakeDamage(this,3);
                    enemy.Stunned(3f);
                }
            }
            distanceFromPlayerToLocation = transform.position - player.transform.position;
            player.Stunned(0.2f);
            player.KnockBacked(distanceFromPlayerToLocation);
            GameManager.lastCastTime[GameManager.currentAbilty] = Time.time;
            Time.timeScale = 1f;
            Destroy(gameObject);
        }
    }


}
