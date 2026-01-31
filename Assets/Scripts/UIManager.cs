using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
using System.Linq;
using DG.Tweening;
using System.Data.Common;

public class UIManager : MonoBehaviour
{
    [Header("Manager Referances")]
    public SystemManager systemManager;
    public AudioManager audioManager;
    [Header("Object Referances")]
    public GameObject menuUI;
    public GameObject howToUI;
    [Header("Paramiters")]
    public float fadeTime = 0.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    #region Unity Core
    void Awake()
    {
        FetchUIElements();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #endregion
    #region UI Control
    /// <summary>
    /// grabs UI elemnts in case they are nulled (like when loading back to menu from gameplay)
    /// </summary>
    void FetchUIElements()
    {
        if(menuUI == null)
        {
            menuUI = GameObject.FindWithTag("MenuPanel");
        }
        if(howToUI == null)
        {
            howToUI = GameObject.FindWithTag("HowToPanel");
            if(systemManager.gameState == SystemManager.GameState.MainMenu)
            {
                howToUI.SetActive(false);
            }
        }
    }

    /// <summary>
    /// Used by first play button to go how to play and dificulty selection.
    /// </summary>
    public void GoToHowToPlay()
    {
        menuUI.SetActive(false);
        howToUI.SetActive(true); 
    }

    /// <summary>
    /// Goes back to main menu from how to play
    /// </summary>
    public void HowToBackToMenu()
    {
        menuUI.SetActive(true);
        howToUI.SetActive(false); 
    }

    public void StartGame()
    {
        systemManager.LoadScene("Gameplay");
        systemManager.ChangeGameState(SystemManager.GameState.Gameplay);
    }

    #endregion
}
