using UnityEngine;

public class GameBackgroundMusicController : MonoBehaviour
{
    public AudioClip[] gameSounds;

    private void Start()
    {
        PlayGameSounds();
    }

    public void PlayGameSounds()
    {
        GetComponent<AudioSource>().clip = gameSounds[Random.Range(0, gameSounds.Length)];
        GetComponent<AudioSource>().Play();
    }

    public void OnDisable()
    {
        GetComponent<AudioSource>().Stop();
    }
}
