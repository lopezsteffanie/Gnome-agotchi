using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JournalUIController : MonoBehaviour
{
    ReflectionsUIController reflectionsUIController;
    GoalsUIController goalsUIController;

    public TextMeshProUGUI promptText, buttonText;

    private void Start()
    {
        DisplayPrompt();
    }
    private void DisplayPrompt()
    {
        promptText.text = buttonText.text;
    }
}