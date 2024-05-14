using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableGeneric : MonoBehaviour, IPickup, IDamageable
{
    int health;

    PotionSO value;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerGeneric>().OnPotionPickup(value.potion);
        }
    }
    public Potions onPickUp()
    {
        return value.potion;
    }

    public void assignDamageStats()
    {
        health = 1;
    }

    public void onDamage(int damageValue, Attacks attack, Hero hero)
    {
        if (attack != Attacks.MAGICATTACK)
            health -= damageValue;
    }

    public void onDeath(Attacks attackType, Hero hero)
    {
        gameObject.SetActive(false);
    }
}
