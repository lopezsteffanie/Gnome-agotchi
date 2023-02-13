using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ReflectionsUIController : MonoBehaviour
{
    [SerializeField] List<ReflectionsSO> reflections = new List<ReflectionsSO>();
    List<ReflectionsSO> usedReflections = new List<ReflectionsSO>();
    ReflectionsSO currentReflection;
    [SerializeField] GameObject[] reflectionButtons;
    int reflectionTypeIndex;
    [SerializeField] GameObject shuffleButton;

    public void Start()
    {
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
        foreach (ReflectionsSO reflection in usedReflections)
        {
            reflections.Add(reflection);
            usedReflections.Remove(reflection);
        }
        DisplayReflection();
    }
}