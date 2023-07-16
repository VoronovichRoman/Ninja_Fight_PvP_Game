using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerMovement : NetworkBehaviour
{
    [SerializeField] private float _speed;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        
    }

    public void Move(float direction)
    {
        HorizontalMovement(direction);
    }

    private void HorizontalMovement(float direction)
    {
        rb.velocity = new Vector2(direction * _speed, rb.velocity.y);
    }
}
