using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDamageable : Wall, IDamageable
{
    int health;
    public void assignDamageStats()
    {
        health = 1;
    }

    public void onDamage(int damageValue, Attacks attack, Hero hero)
    {
        if(attack == Attacks.SHOTATTACK)
            health -= damageValue;
        if(health < 1)
        {
            onDeath(Attacks.SHOTATTACK, Hero.ELF);
        }
    }

    public void onDeath(Attacks attackType, Hero hero)
    {
        gameObject.SetActive(false);
    }
}
