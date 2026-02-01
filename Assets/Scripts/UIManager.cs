using System.Collections;
using System.Collections.Generic;
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
    [Header("UI Elements")]
    public GameObject menuUI;
    public GameObject howToUI;
    public GameObject optionsUI;
    public GameObject menuBG;
    [Header("Loading Screen UI Elements")]
    public GameObject loadingScreen;
    public CanvasGroup loadingScreenCanvasGroup;
    public Image loadingBar;
    public float fadeTime;
    [Header("Options Menu UI Elements")]
    public Slider masterVolSlider;
    public Slider musicVolSlider;
    public Slider sFXVolSlider;
    [Header("HUD Menu UI Elements")]
    public GameObject hudObject;
    public GameObject rulesClipbaord;
    public TextMeshProUGUI rulesText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    #region Unity Core
    void Start()
    {
        FetchUIElements();
        GetStartingVolume();
        ResetMenu();
    }
    #endregion
    #region UI Control
    /// <summary>
    /// grabs UI elemnts in case they are nulled (like when loading back to menu from gameplay)
    /// </summary>
    public void FetchUIElements()
    {
        if(systemManager.gameState == SystemManager.GameState.MainMenu)
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
            if(optionsUI == null)
            {
                optionsUI = GameObject.FindWithTag("OptionsPanel");
                if(systemManager.gameState == SystemManager.GameState.MainMenu)
                {
                    optionsUI.SetActive(false);
                }
            }  
        }
    }

    /// <summary>
    /// Used by first play button to go how to play and dificulty selection.
    /// </summary>
    public void GoToHowToPlay()
    {
        CloseAllUI();
        howToUI.SetActive(true); 
    }

    /// <summary>
    /// Goes back to main menu from how to play
    /// </summary>
    public void HowToBackToMenu()
    {
        ResetMenu();
        SetPresitantVolume(); 
    }

    public void StartGame()
    {
        systemManager.LoadScene("Gameplay");
        systemManager.ChangeGameState(SystemManager.GameState.Gameplay);

    }

    public void ResetMenu()
    {
        CloseAllUI();
        menuBG.SetActive(true);
        menuUI.SetActive(true);
    }
    public void OptionsMenu()
    {
        GetStartingVolume();
        CloseAllUI();
        optionsUI.SetActive(true);
    }

    public void CloseAllUI()
    {
        hudObject.SetActive(false);
        menuUI.SetActive(false);
        howToUI.SetActive(false); 
        optionsUI.SetActive(false);
    }

    #endregion
    #region Loading Screen
    /// <summary>
    /// Starts UI loading screen process.
    /// </summary>
    /// <param name="targetPanel"></param>
    public void UILoadingScreen()
    {
        StartCoroutine(LoadingUIFadeIN());
        //StartCoroutine(DelayedSwitchUIPanel(fadeTime, targetPanel));
    }

    /// <summary>
    /// Fades loading scnreen out.
    /// </summary>
    /// <returns></returns>
    private IEnumerator LoadingUIFadeOut()
    {
        //Debug.Log("Starting Fadeout");

        float timer = 0;

        while (timer < fadeTime)
        {
            loadingScreenCanvasGroup.alpha = Mathf.Lerp(1, 0, timer/fadeTime);
            timer += Time.deltaTime;
            yield return null;
        }

        loadingScreenCanvasGroup.alpha = 0;
        loadingScreen.SetActive(false);
        loadingBar.fillAmount = 0;
        //Debug.Log("Ending Fadeout");
    }
    /// <summary>
    /// Fades Loading screen in.
    /// </summary>
    /// <returns></returns>
    private IEnumerator LoadingUIFadeIN()
    {
        //Debug.Log("Starting Fadein");
        float timer = 0;
        loadingScreen.SetActive(true);

        while (timer < fadeTime)
        {
            loadingScreenCanvasGroup.alpha = Mathf.Lerp(0, 1, timer / fadeTime);
            timer += Time.deltaTime;
            yield return null;
        }

        loadingScreenCanvasGroup.alpha = 1;

        //Debug.Log("Ending Fadein");
        StartCoroutine(LoadingBarProgress());
    }
    /// <summary>
    /// Sets the loading bar progress to average progress of all loading. 
    /// </summary>
    /// <returns></returns>
    private IEnumerator LoadingBarProgress()
    {
        //Debug.Log("Starting Progress Bar");
        while (systemManager.scenesToLoad.Count <= 0)
        {
            //waiting for loading to begin
            yield return null;
        }
        while (systemManager.scenesToLoad.Count > 0)
        {
            loadingBar.fillAmount = systemManager.GetLoadingProgress();
            yield return null;
        }
        yield return new WaitForEndOfFrame();
        //Debug.Log("Ending Progress Bar");
        StartCoroutine(LoadingUIFadeOut());
    }
    #endregion
    #region OptionsMenu
    public void GetStartingVolume()
    {
        masterVolSlider.value = audioManager.GetStartingVol("MasterVol");
        musicVolSlider.value = audioManager.GetStartingVol("MusicVol");
        sFXVolSlider.value = audioManager.GetStartingVol("SFXVol");
    }
    public void SetPresitantVolume()
    {
        audioManager.UpdateVoluem(masterVolSlider.value,"MasterVol");
        audioManager.UpdateVoluem(musicVolSlider.value,"MusicVol");
        audioManager.UpdateVoluem(sFXVolSlider.value,"SFXVol");
    }
    #endregion
    #region HUD Control
    public void ActivateHUD()
    {
        CloseAllUI();
        menuBG.SetActive(false);
        hudObject.SetActive(true);
    }

    public void SetRulesText(string newText)
    {
        rulesText.text = newText;
    }
    #endregion
}
