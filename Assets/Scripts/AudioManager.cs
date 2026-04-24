using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    [SerializeField]
    AudioSource source;

    public void Play(AudioClip clip)
    {
        source.PlayOneShot(clip);
    }
}