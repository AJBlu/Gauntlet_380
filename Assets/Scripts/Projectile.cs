using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int _damage;
    float _shotSpeed;
    Vector3 _movementDirection;
    public GameObject _origin;
    Hero hero;
    public void SetShotAttributes(int damage, float shotSpeed, Vector3 movementDirection, GameObject origin)
    {
        _damage = damage;
        _shotSpeed = shotSpeed;
        _movementDirection = movementDirection;
        _origin = origin;

    }

    private void Awake()
    {
        StartCoroutine("despawn");
    }

    IEnumerator despawn()
    {
        yield return new WaitForSeconds(7f);
        Destroy(gameObject);
    } 
    private void Update()
    {
        _movement();

    }

    private void _movement()
    {
        transform.position += _movementDirection * _shotSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(_origin.tag == "Player")
        {
            if (other.GetComponent<Enemy_Generic>())
            {
                Debug.Log("Hit monster");
                other.GetComponent<Enemy_Generic>().onDamage(_damage, Attacks.SHOTATTACK, _origin.GetComponent<PlayerGeneric>().hero);
                Destroy(gameObject);
            }
            else if (other.GetComponent<Generator>())
            {
                other.GetComponent<Generator>().onDamage(_damage, Attacks.SHOTATTACK, _origin.GetComponent<PlayerGeneric>().hero);
                Destroy(gameObject);
            }
        }

        if(_origin.tag == "Monster")
        {
            if (other.GetComponent<PlayerGeneric>())
            {
                Debug.Log("Hit Player");
                other.GetComponent<PlayerGeneric>().DamagePlayer(_damage);
                Destroy(gameObject);
            }
        }

    }
}
