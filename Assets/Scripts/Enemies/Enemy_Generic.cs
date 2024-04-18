using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class Enemy_Generic : IEnemy, IDamageable
{
    EnemySO enemyData;

    int health; 

    //Damageable
   public void assignDamageStats()
   {
        health = enemyData.health;
   }

   public virtual void onDamage(int damagevalue, Attacks attackType)
   {
        //if the damage type of the attack is accepted by the SO
        if(enemyData.canZap && attackType == Attacks.MAGICATTACK ||
           enemyData.canShoot && attackType == Attacks.SHOTATTACK ||
           enemyData.canFight && attackType == Attacks.FIGHTATTACK
        )
        {
            health -= damagevalue;
            if(health <= 0)
            {
                onDeath(attackType);
            }
        }

   }

   public virtual void onDeath(Attacks attackType)
   {
        switch (attackType)
        {
            case Attacks.FIGHTATTACK:
                SendScore(enemyData.pointsFightingKill);
                break;

            case Attacks.SHOTATTACK:
                SendScore(enemyData.pointsShootingKill);
                break;

            case Attacks.MAGICATTACK:
                SendScore(enemyData.pointsMagicKill);
                break;
        }
   }

    public void SendScore(int points)
    {
        //TODO once scoring system and UI events are being made
        //fire off score event
    }

    public virtual void attack()
    {

    }
}
