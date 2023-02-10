using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PetNameController : MonoBehaviour
{
    public TextMeshProUGUI petName;
    public TMP_InputField userInputField;

    public void Initialize(string petName)
    {
        this.petName.text = petName;
    }

    public void setName()
    {
        petName.text = userInputField.text;
    }

    public void resetName()
    {
        petName.text = "";
    }
}
