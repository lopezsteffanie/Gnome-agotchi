using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PetUIController : MonoBehaviour
{
    public Image foodImage, happinessImage, energyImage;
    public TextMeshProUGUI foodLevelsText, happinessLevelsText, energyLevelsText;

    public static PetUIController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else Debug.LogWarning("More than one PetUIController in this Scene");
    }

    public void UpdateImages(int food, int happiness, int energy)
    {
        foodImage.fillAmount = (float) food / 100;
        happinessImage.fillAmount = (float) happiness / 100;
        energyImage.fillAmount = (float) energy / 100;
    }

    public void UpdateText(int food, int happiness, int energy)
    {
        foodLevelsText.text = food + "/100";
        happinessLevelsText.text = happiness + "/100";
        energyLevelsText.text = energy + "/100";
    }
}