using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PetUIController : MonoBehaviour
{
    public Image foodImage, happinessImage, energyImage, ageImage;
    public TextMeshProUGUI foodLevelsText, happinessLevelsText, energyLevelsText, daysToNextAgeText, currentAgeText;

    public static PetUIController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else Debug.LogWarning("More than one PetUIController in this Scene");
    }

    public void UpdateImages(int food, int happiness, int energy, int age)
    {
        foodImage.fillAmount = (float) food / 100;
        happinessImage.fillAmount = (float) happiness / 100;
        energyImage.fillAmount = (float) energy / 100;
        ageImage.fillAmount = (float) age / 60;
    }

    public void UpdateText(int food, int happiness, int energy, int age)
    {
        foodLevelsText.text = food + "/100";
        happinessLevelsText.text = happiness + "/100";
        energyLevelsText.text = energy + "/100";
        currentAgeText.text = "Age: " + age;

        if (age < 20)
        {
            daysToNextAgeText.text = 20 - age + " days left until next stage";
        }
        else if (age < 40)
        {
            daysToNextAgeText.text = 40 - age + " days left until next stage";
        }
        else if (age < 60)
        {
            daysToNextAgeText.text = 60 - age + " days left until next stage";
        }
    }
}