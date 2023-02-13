using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GoalsUIController : MonoBehaviour
{
    public List <GoalsForTheDaySO> goals = new List<GoalsForTheDaySO>();
    List<GoalsForTheDaySO> usedGoals = new List<GoalsForTheDaySO>();
    GoalsForTheDaySO currentGoal;
    public GameObject[] goalButtons;
    public Button shuffleButton;
    int goalTypeIndex;

    public void Start()
    {
        Button btn = shuffleButton.GetComponent<Button>();
        btn.onClick.AddListener(Reset);
        DisplayGoal();
    }

    public void GetRandomGoal()
    {
        int index = Random.Range(0, goals.Count);
        currentGoal = goals[index];

        if (goals.Contains(currentGoal))
        {
            usedGoals.Add(currentGoal);
            goals.Remove(currentGoal);
        }
    }

    public void DisplayGoal()
    {
        for (int i = 0; i < goalButtons.Length; i++)
        {
            GetRandomGoal();
            TextMeshProUGUI goalText = goalButtons[i].transform.Find("ReflectionContent").GetComponentInChildren<TextMeshProUGUI>();
            goalText.text = currentGoal.GetGoal();

            TextMeshProUGUI happinessText = goalButtons[i].transform.Find("HappinessText").GetComponentInChildren<TextMeshProUGUI>();
            happinessText.text = "+" + currentGoal.GetHappinessPoints().ToString();
        }
    }

    public void Reset()
    {
        while (usedGoals.Count > 0)
        {
            int index = Random.Range(0, usedGoals.Count);
            currentGoal = usedGoals[index];
            if (usedGoals.Contains(currentGoal))
            {
                goals.Add(currentGoal);
                usedGoals.Remove(currentGoal);
            }
        }
        DisplayGoal();
    }

    public void OnGoalSelected(int index)
    {

    }

    public string DisplayPrompt(int index)
    {
        TextMeshProUGUI prompt = goalButtons[index].transform.Find("ReflectionContent").GetComponentInChildren<TextMeshProUGUI>();
        prompt.text = currentGoal.GetGoal();
        return prompt.text;
    }
}

// public void OnAnswerSelected(int index)
//     {
//         hasAnsweredEarly = true;
//         DisplayAnswer(index);
//         SetButtonState(false);
//         timer.CancelTimer();
//         scoreText.text  = "Score: " + scoreKeeper.CalculateScore() + "%";
//     }
//     void DisplayAnswer(int index)
//     {
//         Image buttonImage;
//         progressBar.value++;

//         if(index == currentQuestion.GetAnswerIndex())
//         {
//             questionText.text = "Correct!";
//             buttonImage = answerButtons[index].GetComponent<Image>();
//             buttonImage.sprite = correctAnswerSprite;
//             scoreKeeper.IncrementCorrectAnswers();
//         }
//         else
//         {
//             correctAnswerIndex = currentQuestion.GetAnswerIndex();
//             string correctAnswer = currentQuestion.GetAnswer(correctAnswerIndex);
//             questionText.text = "Sorry, the correct answer was:\n" + correctAnswer;
//             buttonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
//             buttonImage.sprite = correctAnswerSprite;
//         }
//     }