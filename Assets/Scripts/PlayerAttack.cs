using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror; 

public class PlayerAttack : NetworkBehaviour
{
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private float _attackSpeed;
    [SerializeField] private Transform _attackPoint;
    private float _facing;
    [Command]
    public void CmdAttack(bool facingRight)
    {
        if (facingRight)
        {
            _facing = 1;
        }
        else
        {
            _facing = -1;
        }
        GameObject projectile = Instantiate(_projectilePrefab, _attackPoint.position, Quaternion.Euler(0,0,-90*_facing));
        Rigidbody2D projectileVelocity = projectile.GetComponent<Rigidbody2D>();
        projectileVelocity.velocity = new Vector2(_attackSpeed * _facing, projectileVelocity.velocity.y);
        NetworkServer.Spawn(projectile);
    }
}
