using UnityEngine;

public class PetSpriteController : MonoBehaviour
{
    public GameObject redEgg, redBaby, redKid, redAdult, redDead,
                    blueEgg, blueBaby, blueKid, blueAdult, blueDead,
                    greenEgg, greenBaby, greenKid, greenAdult, greenDead;
    private void Start()
    {
        int index = PickRandomGnomeColor();
        if (index == 1)
        {
            Destroy(redEgg);
            Destroy(redBaby);
            Destroy(redKid);
            Destroy(redAdult);
            Destroy(redDead);

            Destroy(blueEgg);
            Destroy(blueBaby);
            Destroy(blueKid);
            Destroy(blueAdult);
            Destroy(blueDead);
        }
        else if (index == 2)
        {
            Destroy(redEgg);
            Destroy(redBaby);
            Destroy(redKid);
            Destroy(redAdult);
            Destroy(redDead);

            Destroy(greenEgg);
            Destroy(greenBaby);
            Destroy(greenKid);
            Destroy(greenAdult);
            Destroy(greenDead);
        }
        else
        {
            Destroy(greenEgg);
            Destroy(greenBaby);
            Destroy(greenKid);
            Destroy(greenAdult);
            Destroy(greenDead);

            Destroy(blueEgg);
            Destroy(blueBaby);
            Destroy(blueKid);
            Destroy(blueAdult);
            Destroy(blueDead);
        }
    }
    public int PickRandomGnomeColor()
    {
        int randomInt = Random.Range(0,3);
        return randomInt;
    }
}
