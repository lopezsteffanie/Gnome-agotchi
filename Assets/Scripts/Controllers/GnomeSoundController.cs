
using UnityEngine;

public class GnomeSoundController : MonoBehaviour
{
    public AudioClip[] happySounds;
    public AudioClip[] sadSounds;
    public AudioClip[] eatingSounds;
    public AudioClip[] tiredSounds;
    public AudioClip[] energeticSounds;
    public AudioClip[] deadSounds;
    NeedsController needsController;
    PetUIController petUIController;

    void Start()
    {
        RandomTime();
    }

    public void RandomTime()
    {
        needsController = FindObjectOfType<NeedsController>();
        float randomTime = Random.Range(5f, 60f);
        InvokeRepeating("PlaySound", 5f, randomTime);
    }

    public void PlaySound()
    {
        int age = needsController.returnAge();
        if (age >= 60)
        {
            GetComponent<AudioSource>().clip = deadSounds[Random.Range(0, deadSounds.Length)];
            GetComponent<AudioSource>().Play();
        }
        else
        {
            int happinessLevel = needsController.returnHappiness();
            if (happinessLevel > 50)
            {
                GetComponent<AudioSource>().clip = happySounds[Random.Range(0, happySounds.Length)];
                GetComponent<AudioSource>().Play();
            }
            else if (happinessLevel <= 50)
            {
                GetComponent<AudioSource>().clip = sadSounds[Random.Range(0, sadSounds.Length)];
                GetComponent<AudioSource>().Play();
            }

            int energyLevel = needsController.returnEnergy();
            if (energyLevel > 50)
            {
                GetComponent<AudioSource>().clip = energeticSounds[Random.Range(0, energeticSounds.Length)];
                GetComponent<AudioSource>().Play();
            }
            else if (energyLevel <=  50)
            {
                GetComponent<AudioSource>().clip = tiredSounds[Random.Range(0, tiredSounds.Length)];
                GetComponent<AudioSource>().Play();
            }
        }
    }

    public void PlayEatingSounds()
    {
        GetComponent<AudioSource>().clip = eatingSounds[Random.Range(0, eatingSounds.Length)];
        GetComponent<AudioSource>().Play();
    }
}
