using UnityEngine;
using UnityEngine.SceneManagement;

public class SessionManager : MonoBehaviour
{
    public static SessionManager instance;

    [SerializeField] private Transform player;
    [SerializeField] private GameObject winScreen;

    private bool canConclude = false;

    void Awake()
    {
        if (instance == null) instance = this; 
    }

    void Start()
    {
        SessionData.spawnPosition = Vector2.zero;
        ReloadWithLastCheckpoint();
    }

    void Update()
    {
        if (canConclude)
        {
            if (Input.anyKeyDown) {
                string currentSceneName = SceneManager.GetActiveScene().name;
                SceneManager.LoadScene(currentSceneName);
            }
        }
    }

    public void ReloadWithLastCheckpoint()
    {
        DeathManager.instance.canReset = false;
        player.transform.position = SessionData.spawnPosition;
    }

    public void Conclude()
    {
        SoundManager.instance.PlayWinQueue();
        SessionData.spawnPosition = Vector3.zero;
        winScreen.SetActive(true);
        canConclude = true;
    }
}

public static class SessionData
{
    public static Vector3 spawnPosition;
}
