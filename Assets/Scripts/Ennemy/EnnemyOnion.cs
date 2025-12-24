using System;
using UnityEngine;

public class EnnemyOnion : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private int moveDirection = 1;
    private float lastPosition;

    private bool isInKillRange = false;

    void Start()
    {
        lastPosition = transform.position.x;
    }

    void Update()
    {
        if (moveDirection > 0)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (moveDirection < 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }

    void FixedUpdate()
    {
        transform.position = new Vector3(
            transform.position.x + speed * moveDirection * Time.deltaTime,
            transform.position.y,
            0
        );

        if (transform.position.x == lastPosition) moveDirection *= -1;

        lastPosition = transform.position.x;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            if (isInKillRange) 
            {
                Die();
            }
            else
            {
                DeathManager.instance.PlayerDie();
            }
        }        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        isInKillRange = true;
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        isInKillRange = false;
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
