using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy : ObjectHP
{
    Player[] players=new Player[3];

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
    private void OnDestroy()
    {

    }
}
