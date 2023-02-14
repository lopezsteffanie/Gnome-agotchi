using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JournalUIController : MonoBehaviour
{
    [Header("Journal")]
    public GameObject activeBullet;
    public GameObject[] journalBullets;

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