using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDamageable : Wall//, IDamageable
{
    int health;
    public void assignDamageStats()
    {
        health = 1;
    }

    public void onDamage(int damageValue, Attacks attack)
    {
        if(attack != Attacks.MAGICATTACK)
            health -= damageValue;
    }

    public void onDeath(Attacks attackType)
    {
        gameObject.SetActive(false);
    }
}
