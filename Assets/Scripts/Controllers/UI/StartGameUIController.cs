using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartGameUIController : MonoBehaviour
{
    public TextMeshProUGUI displayGnomeName;
    public TMP_InputField inputGnomeName;
    public GameObject nameEnterButton;
    public GameObject inputField;
    public GameObject resetNameButton;

    public void Initialize(string displayGnomeName)
    {
        this.displayGnomeName.text = displayGnomeName;
    }

    public void setName()
    {
        displayGnomeName.text = "Your gnome's name: " + inputGnomeName.text;
        inputField.SetActive(false);
        nameEnterButton.SetActive(false);
        resetNameButton.SetActive(true);
    }

    public void resetName()
    {
        inputGnomeName.text = "";
        displayGnomeName.text = "Your gnome's name:";
        inputField.SetActive(true);
        nameEnterButton.SetActive(true);
        resetNameButton.SetActive(false);
    }

    public string returnName()
    {
        return inputGnomeName.text;
    }
}
