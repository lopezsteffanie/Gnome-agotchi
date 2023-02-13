using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ReflectionsUIController : MonoBehaviour
{
    public List<ReflectionsSO> reflections = new List<ReflectionsSO>();
    List<ReflectionsSO> usedReflections = new List<ReflectionsSO>();
    ReflectionsSO currentReflection;
    public GameObject[] reflectionButtons;
    public Button shuffleButton;
    int reflectionTypeIndex;

    public void Start()
    {
        Button btn = shuffleButton.GetComponent<Button>();
        btn.onClick.AddListener(Reset);
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
}