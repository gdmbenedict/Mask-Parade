using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    public CriteriaManager criteriaManager;
    public GuestManager guestManager;

    [Header("Time")]
    public float startingTime = 300f;
    public float bonusTime = 3f;
    public float quickProcessTime = 5f;
    private float quickProcessTimer;
    public float gameTimer = 0f;

    [Header("Score")]
    public long score = 0;
    public float startingComboMult = 1;
    public float comboStep = 0.01f;
    public float comboMult;
    public float quickProcessPoints = 100;
    public float basePoints = 100;

    [Header("Sttrikes")]
    public int maxStrikes = 5;
    public int currentStrikes = 0;

    private bool gameStarted = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        comboMult = startingComboMult;
        gameTimer = startingTime;
        quickProcessTimer = quickProcessTime;

        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (SystemManager.systemManager.gameState != SystemManager.GameState.Gameplay || !gameStarted) return;

        //process timers
        if (gameTimer > 0) gameTimer -= Time.deltaTime;
        else EndGame();

        SystemManager.systemManager.uIManager.SetTimeRemaining(gameTimer);  

        if (quickProcessTimer > 0) quickProcessTimer -= Time.deltaTime;
        else if (quickProcessTimer < 0) quickProcessTimer = 0;
    }

    public void StartGame()
    {
        SystemManager.systemManager.uIManager.ResetStrikes();
        guestManager.GenerateNewGuest();
        gameStarted = true;
    }

    public void EndGame()
    {
        gameStarted = false;

        SystemManager.systemManager.uIManager.GetResults(score);
    }

    public void ProcessResult(bool letGuestIn)
    {
        if(letGuestIn != criteriaManager.CheckGuest())
        {
            IncorrectChoice();
        }
        else
        {
            CorrectChoice();
        }

        guestManager.GenerateNewGuest();
    }

    private void CorrectChoice()
    {
        gameTimer += bonusTime;
        int bonusPoints = (int)(100 * (quickProcessTimer / quickProcessTime));
        score += (int)((basePoints + bonusPoints) * comboMult);

        SystemManager.systemManager.uIManager.SetHUDScore(score);

        comboMult += comboStep;
        quickProcessTimer = quickProcessTime;
    }

    private void IncorrectChoice()
    {
        currentStrikes++;
        SystemManager.systemManager.uIManager.SetStrikes(currentStrikes);

        if (currentStrikes >= maxStrikes) EndGame();
        else
        {
            comboMult = startingComboMult;
            quickProcessTimer = quickProcessTime;
        }
    }
}
