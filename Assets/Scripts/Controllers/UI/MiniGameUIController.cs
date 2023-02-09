using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MiniGameUIController : MonoBehaviour
{
    public static MiniGameUIController instance;
    public GameObject miniGamePrefab, miniGame;
    public TextMeshProUGUI scoreText, timerText;
    public MiniGameEndPanelController miniGameEndUI;
    public MiniGamePetController miniGamePetController;
    private int score;
    private float timeRemaining;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else Debug.LogWarning("More than one MiniGameUIController in the Scene");
    }
    
    private void OnEnable()
    {
        miniGamePetController.enabled = true;
        miniGame = Instantiate(miniGamePrefab);
        miniGame.GetComponent<BaseMiniGameController>().Initialize(miniGamePetController.transform);
    }

    public virtual void ChangeScore(int amount)
    {
        score += amount;
        UpdateScore(score);
    }

    public void UpdateScore(int score)
    {
        this.score = score;
        if (score >= 3) FinishMiniGame(score, timeRemaining);
        scoreText.text = "Score: " + score;
    }

    private void GoalReached()
    { 
    }

    public void UpdateTimer(float timer)
    {
        timeRemaining = timer;
        timerText.text = string.Format("Time left: {0}", timer);
    }

    public void FinishMiniGame(int score, float timeRemaining)
    {
        miniGameEndUI.gameObject.SetActive(true);
        Camera.main.orthographicSize = 5;
        Camera.main.transform.position = new Vector3(0, 0, -10);
        miniGameEndUI.Initialize(score, timeRemaining, timeRemaining > 0);
        Destroy(miniGame);
    }

    public void LoseMiniGame()
    {
        miniGameEndUI.gameObject.SetActive(true);
        Camera.main.orthographicSize = 5;
        Camera.main.transform.position = new Vector3(0, 0, -10);
        miniGameEndUI.Initialize(score, timeRemaining, false);
        Destroy(miniGame);
    }

}
