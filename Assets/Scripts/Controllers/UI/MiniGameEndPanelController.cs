using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MiniGameEndPanelController : MonoBehaviour
{
    public TextMeshProUGUI resultText, titleText;

    public void Initialize(int score, float timeRemaining, bool victory)
    {
        resultText.text = 
            string.Format("You obtained {0} points, and had {1} seconds left", score, timeRemaining);
        titleText.text = victory ? "You won!" : "You lost!";
    }
}
