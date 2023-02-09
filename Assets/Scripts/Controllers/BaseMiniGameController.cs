using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMiniGameController : MonoBehaviour
{
    protected int score;
    public float timer, cameraSize;

    private void Start()
    {
        if(timer == 0)
        {
            ChangeTimer(30);
        }
    }
    protected virtual void ChangeScore(int amount)
    {
        score += amount;
        if(MiniGameUIController.instance == null) return;
        MiniGameUIController.instance.UpdateScore(score);
    }

    protected virtual void ChangeTimer(float change)
    {
        timer += change;
        if(MiniGameUIController.instance == null) return;
        MiniGameUIController.instance.UpdateTimer(timer);
    }

    protected virtual void Update()
    {
        ChangeTimer(-Time.deltaTime);
        if(timer < 0)
        {
            MiniGameUIController.instance.FinishMiniGame(score, timer);
            Destroy(gameObject, 1);
        }
    }

    protected virtual void GoalReached()
    {
        if(MiniGameUIController.instance == null) return;
        MiniGameUIController.instance.FinishMiniGame(score, timer);
        Destroy(gameObject);
    }
}
