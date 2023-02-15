using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetAgeController : MonoBehaviour
{
    public NeedsController needsController;
    public int age;
    public GameObject[] gnomeSprites;

    private void Update()
    {
        age = needsController.returnAge();
        ChangeSprite(age);
    }

    public void ChangeSprite(int age)
    {
        if (age < 20)
        {
            gnomeSprites[0].SetActive(true);
            gnomeSprites[1].SetActive(false);
            gnomeSprites[2].SetActive(false);
        }
        else if (age < 40)
        {
            gnomeSprites[0].SetActive(false);
            gnomeSprites[1].SetActive(true);
            gnomeSprites[2].SetActive(false);
        }
        else
        {
            gnomeSprites[0].SetActive(false);
            gnomeSprites[1].SetActive(false);
            gnomeSprites[2].SetActive(true);
        }
    }
}
