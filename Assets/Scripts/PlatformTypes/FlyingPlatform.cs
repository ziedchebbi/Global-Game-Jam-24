using System;
using UnityEngine;

public class FlyingPlatform : MonoBehaviour
{
    [SerializeField] private float maxHeight;
    [SerializeField] private float minHeight;
    [SerializeField] private bool readMinHeightFromScene = true;
    [Space]
    [SerializeField] private float speedFactor = 0.1f;
    [SerializeField] private AnimationCurve speedOverTime;
    [SerializeField] private float resetSpeed;
    [Space]
    [SerializeField] private bool isMoving = false;
    [SerializeField] private bool resetAfterDuration = true;
    [SerializeField] private float resetDelay = 5f;

    private float yPosition = 0f;
    private bool canCrush = false;
    private float time = 0f;

    void Start()
    {
        if (readMinHeightFromScene) minHeight = transform.position.y;
        yPosition = minHeight;
    }

    void Update()
    {
        if (resetAfterDuration && transform.position.y >= maxHeight)
        {
            time += Time.deltaTime;

            if (time >= resetDelay)
            {
                isMoving = false;

                time = 0f;
            }
        }

        if (isMoving && transform.position.y < maxHeight)
        {
            float factor = MathF.Abs(transform.position.y) / (maxHeight - minHeight);
            yPosition += speedOverTime.Evaluate(factor) * speedFactor * Time.deltaTime;
        }

        if (!isMoving && transform.position.y > minHeight)
        {
            yPosition -= resetSpeed * Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        transform.position = new Vector3(
            transform.position.x,
            yPosition,
            0
        );
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        isMoving = true;

        // Crushing
        if (collision.gameObject.layer == 10)
        {
            if (canCrush) 
                DeathManager.instance.PlayerDie();
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        isMoving = false;
    }

    void OnTriggerEnter2D()
    {
        canCrush = true;
    }

    void OnTriggerExit2D()
    {
        canCrush = false;
    }
}
