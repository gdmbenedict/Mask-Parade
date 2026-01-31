using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;

public class Button : MonoBehaviour
{
    public UIManager uIManager;
    public enum ButtonType{play,start,quit,options,backToMenu}
    public ButtonType type;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if(uIManager == null)
        {
            uIManager = GameObject.FindAnyObjectByType<UIManager>();
        }
    }

    public void PressButton()
    {
        switch(type)
        {
            case ButtonType.play:
                uIManager.GoToHowToPlay();
                break;
            case ButtonType.start:
                uIManager.StartGame();
                break;
            case ButtonType.quit:
                uIManager.systemManager.QuitGame();
                break;
            case ButtonType.options:
                break;
            case ButtonType.backToMenu:
                uIManager.HowToBackToMenu();
                break;
        }
    }
}
