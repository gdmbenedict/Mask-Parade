using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;

public class Button : MonoBehaviour
{
    public UIManager uIManager;
    public AudioManager audioManager;
    public GameManager gameManager;

    public enum ButtonType{play,start,quit,options,backToMenu,menu,backFromOptions,resume,admit,reject}
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

    private void OnEnable()
    {
        if (type == ButtonType.admit || type == ButtonType.reject)
        {
            gameManager = FindAnyObjectByType<GameManager>();
        }
    }

    public void PressButton()
    {
        switch(type)
        {
            case ButtonType.play:
                audioManager.PlaySFX(1);
                uIManager.GoToHowToPlay();
                break;
            case ButtonType.start:
                audioManager.PlaySFX(1);
                uIManager.StartGame();
                break;
            case ButtonType.quit:
                audioManager.PlaySFX(1);
                uIManager.systemManager.QuitGame();
                break;
            case ButtonType.options:
                audioManager.PlaySFX(1);
                uIManager.OptionsMenu();
                break;
            case ButtonType.backToMenu:
                audioManager.PlaySFX(1);
                uIManager.HowToBackToMenu();
                break;
            case ButtonType.backFromOptions:
                audioManager.PlaySFX(1);
                uIManager.BackFromOptions();
                break;
            case ButtonType.menu:
                audioManager.PlaySFX(1);
                uIManager.ReturnToMenu();
                break;
            case ButtonType.resume:
                audioManager.PlaySFX(1);
                uIManager.systemManager.ChangeGameState(SystemManager.GameState.Gameplay);
                break;
            case ButtonType.admit:
                audioManager.PlaySFX(1);
                gameManager.ProcessResult(true);
                break;
            case ButtonType.reject:
                audioManager.PlaySFX(1);
                gameManager.ProcessResult(false);
                break;
        }
    }
}
