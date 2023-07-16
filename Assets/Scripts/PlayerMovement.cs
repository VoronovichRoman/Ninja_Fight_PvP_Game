using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerMovement : NetworkBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _jumpOffset;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private Transform _feetPos;
    private Rigidbody2D rb;
    public bool IsFacingRight;
    private bool _isGrounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        IsFacingRight = true;
    }
    void Update()
    {
        
    }

    public void Move(float direction, bool isJumpActive)
    {
        if (IsFacingRight && direction < 0)
        {
            Flip();
        }
        else if (!IsFacingRight && direction > 0)
        {
            Flip();
        }
        HorizontalMovement(direction);
        if (isJumpActive)
        {
            Jump();
        }
    }

    private void HorizontalMovement(float direction)
    {
        rb.velocity = new Vector2(direction * _speed, rb.velocity.y);
    }

    private void Jump()
    {
        if (IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, _jumpForce);
        }
    }
    private void Flip()
    {
        IsFacingRight = !IsFacingRight;
        Vector3 tempScale = transform.localScale;
        tempScale.x *= -1;
        transform.localScale = tempScale;
    }
    public bool IsGrounded()
    {
        _isGrounded = Physics2D.OverlapCircle(_feetPos.position, _jumpOffset, _groundMask);
        return _isGrounded;
    }
}
