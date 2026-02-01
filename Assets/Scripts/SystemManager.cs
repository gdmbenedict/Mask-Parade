using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SystemManager : MonoBehaviour
{
    [Header("Object Referances")]
    public UIManager uIManager;
    public AudioManager audioManager;
    public static SystemManager systemManager;
    public enum GameState{MainMenu, Gameplay, Paused, GameEnd}
    [Header("Game States")]
    public GameState gameState;
    public GameState prevState;
    public bool isPaused;
    public List<AsyncOperation> scenesToLoad = new List<AsyncOperation>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    #region Core Unity
    void Start()
    {
        if(systemManager != null)
        {
            GameObject.Destroy(this.gameObject);
        }
        else
        {
            GameObject.DontDestroyOnLoad(this.gameObject);
            systemManager = this;
        }
        uIManager.systemManager = this;
        audioManager.systemManager = this;
        uIManager.audioManager = audioManager;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #endregion
    #region Game States
    /// <summary>
    /// Used to change game state at specific points, runing methods only once instead of every frame.
    /// </summary>
    public void ChangeGameState(GameState state)
    {
        gameState = state;
        Debug.Log("Changing to " + gameState + " Gamestate");
        switch(gameState)
        {
            case GameState.MainMenu:
                MainMenu();
                break;
            case GameState.Gameplay:
                Gameplay();
                break;
            case GameState.Paused:
                break;
            case GameState.GameEnd:
                break;
        }
    }

    public void MainMenu()
    {
        uIManager.FetchUIElements();
        uIManager.ResetMenu();
        audioManager.PlayMusic(0);
    }

    public void Gameplay()
    {
        audioManager.PlayMusic(1);
    }

    public void Paused()
    {
        
    }

    public void GameEnd()
    {
        
    }

    #endregion
    #region Scene Managment
    /// <summary>
    /// Load target scene
    /// </summary>
    /// <param name="sceneName"></param>
    public void LoadScene(string sceneName)
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        uIManager.UILoadingScreen();
        StartCoroutine(WaitForScreenLoad(sceneName));   
    }

    /// <summary>
    /// Waits for screen to load before starting operation. 
    /// </summary>
    /// <param name="sceneName"></param>
    /// <returns></returns>
    private IEnumerator WaitForScreenLoad(string sceneName)
    {
        yield return new WaitForSeconds(uIManager.fadeTime);
        //Debug.Log("Loading Scene Starting");

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        operation.completed += OperationCompleted;
        scenesToLoad.Add(operation);
    }
    /// <summary>
    /// Gets average progress for Loading bar. 
    /// </summary>
    /// <returns></returns>
    public float GetLoadingProgress()
    {
        float totalprogress = 0;

        foreach (AsyncOperation operation in scenesToLoad)
        {
            totalprogress += operation.progress;
        }

        return totalprogress / scenesToLoad.Count;
    }
    /// <summary>
    /// Event for when load operation is finished. 
    /// </summary>
    /// <param name="operation"></param>
    private void OperationCompleted(AsyncOperation operation)
    {
        scenesToLoad.Remove(operation);
        operation.completed -= OperationCompleted;
    }

     void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(gameState == GameState.Gameplay)
        {
            uIManager.ActivateHUD();
        }
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    /// <summary>
    /// Quits Game. 
    /// </summary>
    public void QuitGame()
    {
        //Debug line to test quit function in editor
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
    #endregion
}
