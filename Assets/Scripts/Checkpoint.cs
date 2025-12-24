using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private GameObject particles;

    void Start()
    {
        particles = transform.Find("Particle System").gameObject;
        particles.SetActive(false);
    }

    void OnTriggerEnter2D()
    {
        particles.SetActive(true);

        SessionData.spawnPosition = new Vector3(
            transform.position.x,
            Mathf.Round(transform.position.y) + 1,
            0
        );
    }
}
