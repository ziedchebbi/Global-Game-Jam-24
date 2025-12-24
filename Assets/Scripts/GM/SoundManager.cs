using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField] private AudioSource source;
    // [Space]
    // [SerializeField] private AudioClip lossClip;
    // [SerializeField] private AudioClip winClip;

    void Awake()
    {
        if (instance == null) instance = this;
    }

    public void PlayLooseQueue()
    {
        Debug.Log("sound");
        // source.PlayOneShot(lossClip);
    }

    public void PlayWinQueue()
    {
        Debug.Log("sound");
        // source.PlayOneShot(winClip);
    }
}
