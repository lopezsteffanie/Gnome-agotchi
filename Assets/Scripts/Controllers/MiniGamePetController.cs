using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGamePetController : MonoBehaviour
{
    private void OnEnable()
    {
        GetComponent<PetController>().enabled = false;
    }

    private void OnDisable()
    {
        GetComponent<PetController>().enabled = true;
    }
}
