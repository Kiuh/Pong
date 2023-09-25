using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float maxInitAngle = 0.67f;
    public float moveSpeed = 1f;

    private void Start()
    {
        Vector2 direction = Vector2.left;
        direction.y = Random.Range(-maxInitAngle, maxInitAngle);
        rb2d.velocity = direction * moveSpeed;
    }

    private void Update()
    {
        
    }
}
