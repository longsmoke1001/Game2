using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] ObjectHP gameObjectAttached;
    Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = 1f;
        
    }

    void Update()
    {

        slider.value = gameObjectAttached.health / 100f;
        if (gameObjectAttached==null)
        {
            Destroy(gameObject);
            return;
        }
        transform.position = Camera.main.WorldToScreenPoint(gameObjectAttached.transform.position + Vector3.up);
    }

    void UpdateHealthBar(float damage)
    {
        //slider.value = gameObjectAttached.health / 100f;
    }
}

