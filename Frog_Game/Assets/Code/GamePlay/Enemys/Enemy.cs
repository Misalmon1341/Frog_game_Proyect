using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    private float timer;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 6f)
        {
            Destroy(gameObject);
        }
        rb.linearVelocity = Vector2.left * (speed + GameManager.Instance.speedMultiplier);
    }
}
