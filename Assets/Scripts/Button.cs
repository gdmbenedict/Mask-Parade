using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;

public class Button : MonoBehaviour
{
    public UIManager uIManager;
    public AudioManager audioManager;
    public enum ButtonType{play,start,quit,options,backToMenu,admit,reject}
    public ButtonType type;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if(uIManager == null)
        {
            uIManager = GameObject.FindAnyObjectByType<UIManager>();
        }
        if(audioManager == null)
        {
            audioManager = GameObject.FindAnyObjectByType<AudioManager>();
        }
    }

    public void PressButton()
    {
        switch(type)
        {
            case ButtonType.play:
                uIManager.GoToHowToPlay();
                audioManager.PlaySFX(1);
                break;
            case ButtonType.start:
                uIManager.StartGame();
                audioManager.PlaySFX(1);
                break;
            case ButtonType.quit:
                uIManager.systemManager.QuitGame();
                audioManager.PlaySFX(1);
                break;
            case ButtonType.options:
                uIManager.OptionsMenu();
                audioManager.PlaySFX(1);
                break;
            case ButtonType.backToMenu:
                uIManager.HowToBackToMenu();
                audioManager.PlaySFX(1);
                break;
            case ButtonType.admit:
                break;
            case ButtonType.reject:
                break;
        }
    }
}
