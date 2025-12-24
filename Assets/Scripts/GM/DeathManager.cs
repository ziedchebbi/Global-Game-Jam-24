using UnityEngine;

public class DeathManager : MonoBehaviour
{
    public static DeathManager instance;

    [SerializeField] private Transform player;
    [Space]
    [SerializeField] private float yMinOOB;
    [SerializeField] private GameObject lossPannel;

    [SerializeField] private CharacterController2D playerController;
    // [SerializeField] private Transform scoreTextObject;

    // private TextMeshPro scoreTextMesh;
    public bool canReset = false;

    void Awake()
    {
        if (instance == null) instance = this;
    }

    // void Start()
    // {
    //     scoreTextMesh = scoreTextObject.GetComponent<TextMeshPro>();        
    // }

    void Update()
    {
        if (player.transform.position.y < yMinOOB)
        {
            PlayerDie();
        }

        if (canReset)
        {
            if (Input.anyKeyDown) 
            {
                SessionManager.instance.ReloadWithLastCheckpoint();
                lossPannel.SetActive(false);
                playerController.enabled = true;
            }
        }
    }

    public void PlayerDie()
    {
        // float score = player.transform.position.x;
        // if (score < 0) score = 0;
        // scoreTextMesh.text = score.ToString();
        SoundManager.instance.PlayLooseQueue();
        playerController.enabled = false;
        lossPannel.SetActive(true);
        canReset = true;
    }
}
