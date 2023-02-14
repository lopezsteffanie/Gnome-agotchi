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
    public TextMeshProUGUI journalPrompt;
    public Button closeJournalButton;

    public void Start()
    {
        Button shuffleBtn = shuffleButton.GetComponent<Button>();
        shuffleBtn.onClick.AddListener(Reset);
        
        for (int i = 0; i < goalButtons.Length; i++)
        {
            GameObject goal = goalButtons[i];
            goalButtons[i].GetComponent<Button>().onClick.AddListener(() => OpenJournal(goal));
        }

        DisplayGoal();
    }
    public void Update()
    {
        int count = 1;
        foreach (GameObject journal in journalBullets)
        {
            if (journal.activeSelf)
            {
                count++;
            }
        }

        for (int i = 0; i < count; i++)
        {
            Button setEntryBtn = activeBullet.transform.Find("EnterButton").GetComponentInChildren<Button>();
            setEntryBtn.onClick.AddListener(() => SetEntry(activeBullet, i));
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

    public void OpenJournal(GameObject goal)
    {
        journalUI.SetActive(true);
        TextMeshProUGUI goalText = goal.transform.Find("ReflectionContent").GetComponentInChildren<TextMeshProUGUI>();
        journalPrompt.text = goalText.text;
    }

    public void SetEntry(GameObject bullet, int index)
    {
        TextMeshProUGUI displayGoal = bullet.transform.Find("DisplayGoal").GetComponentInChildren<TextMeshProUGUI>();
        TMP_InputField inputGoal = bullet.transform.Find("InputGoal").GetComponentInChildren<TMP_InputField>();
        displayGoal.text = inputGoal.text;

        GameObject inputField = GameObject.Find($"Individual Reflection ({index - 2})/InputGoal");
        inputField.SetActive(false);
        
        GameObject enterButton = GameObject.Find($"Individual Reflection ({index - 2})/EnterButton");
        enterButton.SetActive(false);

        journalBullets[index - 1].SetActive(true);
        activeBullet = journalBullets[index - 1];
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