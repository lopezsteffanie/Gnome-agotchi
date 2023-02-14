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
    [Header("Journal")]
    public TextMeshProUGUI journalPrompt;
    public Button closeJournalButton;
    public GameObject journalPrefab, journalUI, journalBackground;
    public void Start()
    {
        Button shuffleBtn = shuffleButton.GetComponent<Button>();
        shuffleBtn.onClick.AddListener(Reset);

        Button closeJournalBtn = closeJournalButton.GetComponent<Button>();
        closeJournalBtn.onClick.AddListener(CloseJournal);
        
        for (int i = 0; i < goalButtons.Length; i++)
        {
            GameObject goal = goalButtons[i];
            goalButtons[i].GetComponent<Button>().onClick.AddListener(() => OpenJournal(goal));
        }

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

    public void OpenJournal(GameObject goal)
    {
        journalBackground.SetActive(true);
        journalUI = Instantiate(journalPrefab);
        journalUI.transform.parent = gameObject.transform;
        journalUI.SetActive(true);
        TextMeshProUGUI goalText = goal.transform.Find("ReflectionContent").GetComponentInChildren<TextMeshProUGUI>();
        journalPrompt.text = goalText.text;
    }

    public void CloseJournal()
    {
        Destroy(journalUI);
    }
}