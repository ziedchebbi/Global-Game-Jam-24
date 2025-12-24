using UnityEngine;

public class SpikyPlatform : MonoBehaviour
{
    private GameObject spikes;

    void Start()
    {
        spikes = transform.Find("Spikes").gameObject;
    }

    void OnCollisionEnter2D()
    {
        spikes.SetActive(true);
        DeathManager.instance.PlayerDie();
    }
}
