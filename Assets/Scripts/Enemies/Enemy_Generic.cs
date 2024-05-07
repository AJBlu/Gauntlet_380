using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class Enemy_Generic : MonoBehaviour, IEnemy, IDamageable
{
    public EnemySO enemyData;

    protected int health;
    public bool canZap, canShoot, canFight;

    [Range(0f, 50f)]
    public float speed = 10;
    //Damageable
   public void assignDamageStats()
   {
        health = enemyData.health;
        canZap = enemyData.canZap;
        canShoot = enemyData.canShoot;
        canFight = enemyData.canFight;
   }


    protected void Update()
    {
        transform.position = toPlayerStep();        
    }

    public void onDamage(int damagevalue, Attacks attackType, Hero hero)
   {
        //if the damage type of the attack is accepted by the SO
        if(canZap && attackType == Attacks.MAGICATTACK ||
           canShoot && attackType == Attacks.SHOTATTACK ||
           canFight && attackType == Attacks.FIGHTATTACK
        )
        {
            health -= damagevalue;
            if(health <= 0)
            {
                onDeath(attackType, hero);
            }
        }

   }

   public void onDeath(Attacks attackType, Hero hero)
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

            default:
                break;
        }

        Destroy(this);
   }


    public void SendScore(int points)
    {
        //TODO once scoring system and UI events are being made
        //fire off score event
    }


    public virtual void attack(GameObject player)
    {
    //fill in with specific attack routines for every monster
    }
        

    //set transform position to nearest player
    private Vector3 toPlayerStep()
    {
        return Vector3.MoveTowards(gameObject.transform.position, getNearestPlayer(), speed * Time.deltaTime);
    }

    //return position of closest player
    private Vector3 getNearestPlayer()
    {
        Vector3 closestEnemy = transform.position;
        float currentShortestPath = float.MaxValue;

        foreach (PlayerController player in FindObjectsOfType<PlayerController>())
        {
            Debug.Log($"{FindObjectsOfType<PlayerController>().Length}");
            if(Vector3.Distance(player.transform.position, this.transform.position) < currentShortestPath)
            {
                //Debug.LogFormat($"Nearest player is: {player.name}");
                closestEnemy = player.transform.position;
                currentShortestPath = Vector3.Distance(player.transform.position, this.transform.position);
            }
        }
        return closestEnemy;
    
    }
}
