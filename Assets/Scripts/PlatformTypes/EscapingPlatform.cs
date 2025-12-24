using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D))]

public class EscapingPlatform : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [Space]
    [SerializeField] private Transform player;

    public float delay = 10;
    private float time;
    private Vector3 startPosition;

    private GameObject laugh;

    private bool isMoving = false;
    private float xPos = 0f;
    private bool isEscapingAllowed = true;

    void Start()
    {
        startPosition = transform.position;
        laugh = transform.Find("LaughSprite").gameObject;
    }

    void FixedUpdate()
    {
        if (!isMoving)
        {
            time += Time.deltaTime;

            if (time >= delay) transform.position = startPosition;
        }

        if (isMoving && isEscapingAllowed)
        {
            time = 0f;

            transform.position = new Vector3(
                xPos,
                transform.position.y,
                0
            );
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 10) isEscapingAllowed = false;
        laugh.SetActive(false);
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 10) isEscapingAllowed = true;
    }

    void OnTriggerStay2D()
    {
        isMoving = true;
        if(player.transform.position.x > transform.position.x)
        {
            xPos = transform.position.x - speed * Time.deltaTime;
        }
        else
        {
            xPos = transform.position.x + speed * Time.deltaTime;
        }
    }

    void OnTriggerEnter2D()
    {
        laugh.SetActive(true);
    }

    void OnTriggerExit2D()
    {
        isMoving = false;
    }

}
