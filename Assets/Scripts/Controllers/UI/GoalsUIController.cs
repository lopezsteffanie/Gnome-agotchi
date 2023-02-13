using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GoalsUIController : MonoBehaviour
{
    [Header("Goals")]
    public List <GoalsForTheDaySO> goals = new List<GoalsForTheDaySO>();
    List<GoalsForTheDaySO> usedGoals = new List<GoalsForTheDaySO>();
    GoalsForTheDaySO currentGoal;
    public GameObject[] goalButtons;
    public Button shuffleButton;
    int goalTypeIndex;
    [Header("Journal")]
    public GameObject journalUI;
    public GameObject activeBullet;
    public GameObject[] journalBullets;

    public void Start()
    {
        Button shuffleBtn = shuffleButton.GetComponent<Button>();
        shuffleBtn.onClick.AddListener(Reset);

        DisplayGoal();
    }
    public void Update()
    {
        for (int i = 0; i < goalButtons.Length; i++)
        {
            goalButtons[i].GetComponent<Button>().onClick.AddListener(OpenJournal);
        }
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

    public void OpenJournal()
    {
        journalUI.SetActive(true);
    }
    
    public void NewBulletPoint()
    {
        for (int i = 0; i < journalBullets.Length; i++)
        {
            activeBullet = journalBullets[i];
            TMP_InputField inputBullet = activeBullet.GetComponent<TMP_InputField>();
            inputBullet.onValueChanged.addListener(delegate {Instantiate(activeBullet); });
        }
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