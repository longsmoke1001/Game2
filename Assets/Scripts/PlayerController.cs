using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator playerAnim;
    float moveSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<SPUM_Prefabs>()._anim;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            playerAnim.SetBool("1_Move",true);
            Vector2 movingVelocity = moveSpeed * (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized * Time.deltaTime;
            transform.Translate(movingVelocity);
            if (movingVelocity.x > 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
        else
        {
            playerAnim.SetBool("1_Move",false);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * Time.deltaTime * 5);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * Time.deltaTime * 5);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector2.up * Time.deltaTime * 5);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector2.down * Time.deltaTime * 5);
        }
    }
}
