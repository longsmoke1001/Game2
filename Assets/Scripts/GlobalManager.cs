using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GlobalManager : MonoBehaviour
{
    [SerializeField] Player player1;
    [SerializeField] Player player2;
    [SerializeField] TextMeshProUGUI gameOverText;
    [SerializeField] Button exitButton;
    // Start is called before the first frame update
    void Start()
    {
        exitButton.onClick.AddListener(ReturnToMenu);
    }

    // Update is called once per frame
    void Update()
    {
        if(player1 == null && player2 == null)
        {
            gameOverText.gameObject.SetActive(true);
            exitButton.gameObject.SetActive(true);
        }
    }
    void ReturnToMenu()
    {
        SceneManager.LoadScene(1);
    }
}
