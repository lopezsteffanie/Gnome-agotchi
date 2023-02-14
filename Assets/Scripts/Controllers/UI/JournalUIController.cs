using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JournalUIController : MonoBehaviour
{
    [Header("Journal")]
    public GameObject activeBullet;
    public GameObject[] journalBullets;
    
    public void Start()
    {
        OnEnterButtonClick();
    }

    public int GrabActiveBulletIndex()
    {
        int index = -1;
        foreach (GameObject journal in journalBullets)
        {
            if (journal.activeSelf)
            {
                index ++;
            }
        }
        return index;
    }

    public void OnEnterButtonClick()
    {
        int index = GrabActiveBulletIndex();
        activeBullet = journalBullets[index];

        Button setEntryBtn = activeBullet.transform.Find("EnterButton").GetComponentInChildren<Button>();
        setEntryBtn.onClick.AddListener(SetEntry);
    }
    public void SetEntry()
    {
        Debug.Log($"I've been clicked {activeBullet}");
        int index = GrabActiveBulletIndex();
        activeBullet = journalBullets[index];
    
        TextMeshProUGUI displayGoal = activeBullet.transform.Find("DisplayGoal").GetComponentInChildren<TextMeshProUGUI>();
        TMP_InputField inputGoal = activeBullet.transform.Find("InputGoal").GetComponentInChildren<TMP_InputField>();
        displayGoal.text = inputGoal.text;

        GameObject inputField = GameObject.Find($"Individual Reflection ({index})/InputGoal");
        inputField.SetActive(false);

        GameObject enterButton = GameObject.Find($"Individual Reflection ({index})/EnterButton");
        enterButton.SetActive(false);

        journalBullets[index + 1].SetActive(true);
        NextEntry();
    }

    public void NextEntry()
    {
        OnEnterButtonClick();
    }
}