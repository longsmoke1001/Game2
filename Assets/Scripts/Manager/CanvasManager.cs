using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    TextMeshProUGUI[] cooldownText = new TextMeshProUGUI[4];
    [SerializeField] Button[] buttons = new Button[4];
    [SerializeField] TextMeshProUGUI playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HealthDisplay();
        AbilityCooldownDisplay();
    }

    void HealthDisplay()
    {
        if (GameManager.selectedCharacter == null)
            playerHealth.text = "";
        else
            playerHealth.text = $"Current Health:{GameManager.selectedCharacter.health:F0}/{GameManager.selectedCharacter.maxHealth:F0}";
    }
     void AbilityCooldownDisplay()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            float remainingCooldown = GameManager.Instance.cooldownTime[i] - (Time.time - GameManager.Instance.lastCastTime[i]);
            if (remainingCooldown > 0)
                cooldownText[i].text = $"{remainingCooldown:F1}";
            else
                cooldownText[i].text = "";
        }
    }
}
