using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGamePetController : MonoBehaviour
{
    public GameObject pet, gardenBackground, petUI, gameBackground, manager;

    private void OnEnable()
    {
        petUI.SetActive(false);
        gameBackground.SetActive(false);
        gardenBackground.SetActive(true);
        // GetComponent<PetController>().enabled = false;
        GetComponent<PetAgeController>().enabled = false;
        GetComponent<NeedsController>().enabled = false;
        manager.GetComponent<PetManager>().enabled = false;
        manager.GetComponent<EndGamePetManager>().enabled = true;
    }
}
