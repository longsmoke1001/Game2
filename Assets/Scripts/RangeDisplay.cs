using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeDisplay : ObjectHP
{
    Vector2 mosPosition;
    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.selectedCharacter != null)
            attackPower = GameManager.selectedCharacter.attackPower;
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected void FollowMouse()
    {
        mosPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mosPosition;
    }

    protected void FollowPlayer()
    {
        transform.position = GameManager.selectedCharacter.transform.position;
    }
    
    
}
