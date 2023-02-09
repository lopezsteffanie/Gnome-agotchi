using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MiniGameUIController : MonoBehaviour
{
    public static MiniGameUIController instance;
    public GameObject miniGamePrefab;
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
        GameObject miniGame = Instantiate(miniGamePrefab);
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
        scoreText.text = "Score: " + score;
    }

    public void UpdateTimer(float timer)
    {
        timeRemaining = timer;
        timerText.text = string.Format("Time left: {0}", timer);
    }

    public void FinishMiniGame(int score, float timeRemaining)
    {
        miniGameEndUI.gameObject.SetActive(true);
        miniGameEndUI.Initialize(score, timeRemaining, timeRemaining > 0);
    }

    public void LoseMiniGame()
    {
        miniGameEndUI.gameObject.SetActive(true);
        miniGameEndUI.Initialize(score, timeRemaining, false);
    }
}
