using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    int _damage;
    float _shotSpeed;
    Vector3 _movementDirection;
    public GameObject _origin;
    public void SetShotAttributes(int damage, float shotSpeed, Vector3 movementDirection, GameObject origin)
    {
        damage = _damage;
        shotSpeed = _shotSpeed;
        _movementDirection = movementDirection;
        _origin = origin;

    }
    private void Update()
    {
        _movement();

    }

    private void _movement()
    {
        transform.position += _movementDirection * _shotSpeed * Time.deltaTime;
    }
}
