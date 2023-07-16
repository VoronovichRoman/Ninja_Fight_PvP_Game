using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerInput : NetworkBehaviour
{
    private PlayerMovement _playerMovement;
    private PlayerAttack _playerAttack;
    private float _horizontalDirection;
    private bool _isJumpActive;
    private bool _isGounded;
    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _playerAttack = GetComponent<PlayerAttack>();
    }
    private void Update()
    {
        _horizontalDirection = Input.GetAxis("Horizontal");
        _isJumpActive = Input.GetKeyDown(KeyCode.Space);
    }
    private void FixedUpdate()
    {
        _playerMovement.Move(_horizontalDirection, _isJumpActive);
        if (Input.GetKeyDown(KeyCode.E))
        {
            _playerAttack.CmdAttack(_playerMovement.IsFacingRight);
        }
    }
}
