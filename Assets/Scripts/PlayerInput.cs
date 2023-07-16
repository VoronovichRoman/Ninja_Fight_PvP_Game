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
        float HorizontalDirection = Input.GetAxis("Horizontal");

        _playerMovement.Move(HorizontalDirection);
    }
}
