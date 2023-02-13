using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogGoalsUIController : MonoBehaviour
{
    public GameObject backgroundPrefab, background;

    private void OnEnable()
    {
        background = Instantiate(backgroundPrefab);
    }
    private void OnDisable()
    {
        Destroy(background);
    }
}
