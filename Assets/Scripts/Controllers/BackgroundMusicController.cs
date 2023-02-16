using UnityEngine;

public class BackgroundMusicController : MonoBehaviour
{
    public AudioClip[] soundtrack;

    void Start()
    {
        if (!GetComponent<AudioSource>().playOnAwake)
        {
            GetComponent<AudioSource>().clip = soundtrack[Random.Range(0, soundtrack.Length)];
            GetComponent<AudioSource>().Play();
        }
    }

    void Update()
    {
        if (!GetComponent<AudioSource>().isPlaying)
        {
            GetComponent<AudioSource>().clip = soundtrack[Random.Range(0, soundtrack.Length)];
            GetComponent<AudioSource>().Play();
        }
    }
}
