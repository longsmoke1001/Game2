using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEffect : MonoBehaviour
{
    float upwardOffset = 0.35f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.selectedCharacter != null)
            transform.position = GameManager.selectedCharacter.transform.position + Vector3.up * upwardOffset;
        else
            gameObject.SetActive(false);
    }
}
