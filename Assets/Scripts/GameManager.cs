using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static Player selectedCharacter { get; private set; }
    [SerializeField] LightEffect lightEffect;
    [SerializeField] GameObject abilityRangeCircle;
    [SerializeField] Button[] buttons = new Button[4];
    [SerializeField] GameObject[] abilityPrefabs;
    TextMeshProUGUI[] cooldownText= new TextMeshProUGUI[4];
    bool isCasting = false;
    public static int currentAbilty { get; private set; } = -1;
    [SerializeField] float[] attackPowerRatio= new float[4];
    [SerializeField] float[] cooldownTime = { 10, 10, 10, 10 };
    public static float[] lastCastTime = { -999, -999, -999, -999 };



    void CastAbility(int id)
    {
        
        Debug.Log("Casting Ability " + id);
        if (Time.time - lastCastTime[id] < cooldownTime[id])
            return;
        Instantiate(abilityPrefabs[id]);
        Time.timeScale = 0.1f;
        isCasting = true;
        currentAbilty = id;
    }
    // Start is called before the first frame update
    void Start()
    {
        
        for (int i = 0; i < 4; i++)
        {
            int x = i;
            buttons[i].onClick.AddListener(() => CastAbility(x));
            cooldownText[i] = buttons[i].GetComponentInChildren<TextMeshProUGUI>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isCasting)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isCasting = false;
            }
        }
        else
            SelectTarget();
        for(int i=0;i<buttons.Length;i++)
        {
            float remainingCooldown = cooldownTime[i] - (Time.time - lastCastTime[i]);
            if (remainingCooldown > 0)
                cooldownText[i].text = $"{remainingCooldown:F1}";
            else 
                cooldownText[i].text = "";
        }



    }

    void Select(Player player)
    {
        if (selectedCharacter != null)
        {
            selectedCharacter.skillButton.gameObject.SetActive(false);
        }
        selectedCharacter = player;
        selectedCharacter.skillButton.gameObject.SetActive(true);
        lightEffect.gameObject.SetActive(true);
    }
    void SelectTarget()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hit = Physics2D.OverlapPoint(mousePos);
            if (selectedCharacter == null && hit != null && hit.gameObject.TryGetComponent<Player>(out var p))
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
    }
}
