using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerInput : NetworkBehaviour
{
    private PlayerMovement _playerMovement;
    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        
    }
    void Update()
    {
        float horizontalDirection = Input.GetAxis("Horizontal");
        bool isJumpActive = Input.GetKeyDown(KeyCode.E);

        _playerMovement.Move(horizontalDirection, isJumpActive);
    }
}
