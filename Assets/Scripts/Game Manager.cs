using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Player selectedCharacter { get; private set; }
    [SerializeField] LightEffect lightEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hit = Physics2D.OverlapPoint(mousePos);
            if (selectedCharacter == null && hit!=null&&hit.gameObject.TryGetComponent<Player>(out var p))
            {
                Select(p);

                Debug.Log("Selected Character: " + selectedCharacter.name);
            }
            else if (selectedCharacter != null)
            {
                if (hit == null)
                {
                    selectedCharacter.target = null;
                    selectedCharacter.destination = mousePos;
                    return;
                }
                else if (hit.gameObject == selectedCharacter.gameObject)
                    selectedCharacter = null;
                else if (hit.gameObject.TryGetComponent<Enemy>(out var e))
                {
                    selectedCharacter.target = e;
                }
                else if (hit.gameObject.TryGetComponent<Player>(out var p2) && p2 != selectedCharacter)
                    Select(p2);
            }
        }

        void Select(Player player)
        {
            selectedCharacter = player;
            lightEffect.gameObject.SetActive(true);
        }
    }
}
