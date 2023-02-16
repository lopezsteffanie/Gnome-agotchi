using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ReflectionsUIController : MonoBehaviour
{
    public GameObject pet;
    [Header("Reflections")]
    public List<ReflectionsSO> reflections = new List<ReflectionsSO>();
    List<ReflectionsSO> usedReflections = new List<ReflectionsSO>();
    ReflectionsSO currentReflection;
    public GameObject[] reflectionButtons;
    public Button shuffleButton;
    [Header("Journal")]
    public TextMeshProUGUI journalPrompt;
    public Button closeJournalButton;
    public GameObject journalPrefab, journalUI, journalBackground;

    public void Start()
    {
        Button btn = shuffleButton.GetComponent<Button>();
        btn.onClick.AddListener(Reset);

        Button closeJournalBtn = closeJournalButton.GetComponent<Button>();
        closeJournalBtn.onClick.AddListener(CloseJournal);

        for (int i = 0; i < reflectionButtons.Length; i++)
        {
            GameObject reflection = reflectionButtons[i];
            reflectionButtons[i].GetComponent<Button>().onClick.AddListener(() => OpenJournal(reflection));
        }

        DisplayReflection();
    }

    public void GetRandomReflection()
    {
        int index = Random.Range(0, reflections.Count);
        currentReflection = reflections[index];

        if (reflections.Contains(currentReflection))
        {
            usedReflections.Add(currentReflection);
            reflections.Remove(currentReflection);
        }
    }

    public void DisplayReflection()
    {
        for (int i = 0; i < reflectionButtons.Length; i++)
        {
            GetRandomReflection();
            TextMeshProUGUI headerText = reflectionButtons[i].transform.Find("ReflectionTitle").GetComponentInChildren<TextMeshProUGUI>();
            headerText.text = currentReflection.GetReflectionTitle();

            TextMeshProUGUI bodyText = reflectionButtons[i].transform.Find("ReflectionContent").GetComponentInChildren<TextMeshProUGUI>();
            bodyText.text = currentReflection.GetReflection();

            TextMeshProUGUI happinessText = reflectionButtons[i].transform.Find("HappinessText").GetComponentInChildren<TextMeshProUGUI>();
            happinessText.text = "+" + currentReflection.GetHappinessPoints().ToString();
        }
    }

    public void Reset()
    {
        while (usedReflections.Count > 0)
        {
            int index = Random.Range(0, usedReflections.Count);
            currentReflection = usedReflections[index];
            if (usedReflections.Contains(currentReflection))
            {
                reflections.Add(currentReflection);
                usedReflections.Remove(currentReflection);
            }
        }
        DisplayReflection();
    }

    public void OpenJournal(GameObject reflection)
    {
        journalBackground.SetActive(true);
        journalUI = Instantiate(journalPrefab);
        journalUI.transform.parent = gameObject.transform;
        journalUI.SetActive(true);
        TextMeshProUGUI reflectionText = reflection.transform.Find("ReflectionContent").GetComponentInChildren<TextMeshProUGUI>();
        journalPrompt.text = reflectionText.text;
        int happiness = currentReflection.GetHappinessPoints();
        pet.GetComponent<NeedsController>().ChangeHappiness(happiness);
    }

    public void CloseJournal()
    {
        Destroy(journalUI);
    }
}