using UnityEngine;

public class EnnemyGarlic : MonoBehaviour
{
    [SerializeField] private float shootInterval = 5f;
    [SerializeField] private Vector2 startingVelocity;
    [SerializeField] private GameObject projectile;

    private bool isInKillRange = false;
    private float time = 0f;

    void Update()
    {
        time += Time.deltaTime;

        if (time >= shootInterval)
        {
            GameObject proc = Instantiate(projectile, transform);
            proc.GetComponent<Rigidbody2D>().linearVelocity = startingVelocity;

            time = 0f;
        }
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
