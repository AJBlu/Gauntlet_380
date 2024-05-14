using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class Enemy_Generic : MonoBehaviour, IEnemy, IDamageable
{
    public EnemySO enemyData;

    public int health;


    [Range(0f, 50f)]
    public float speed = 1;
    //Damageable
   public void assignDamageStats()
   {
        health = enemyData.health;
   }

    private void Awake()
    {
        assignDamageStats();
    }


    private void Update()
    {
    
        transform.position = toPlayerStep();
        

    }

    public void onDamage(int damagevalue, Attacks attackType, Hero hero)
   {
        Debug.Log("Damaging");

            health -= damagevalue;
            if(health < 1)
            {
                onDeath(attackType, hero);
            }

   }

   public void onDeath(Attacks attackType, Hero hero)
   {
        switch (attackType)
        {
            case Attacks.FIGHTATTACK:
                SendScore(enemyData.pointsFightingKill, hero);
                break;

            case Attacks.SHOTATTACK:
                SendScore(enemyData.pointsShootingKill, hero);
                break;

            case Attacks.MAGICATTACK:
                SendScore(enemyData.pointsMagicKill, hero);
                break;
        }
        Destroy(this.gameObject);
   }


    public void SendScore(int points, Hero hero)
    {
        if (hero != Hero.ENEMY)
        {
            //TODO once scoring system and UI events are being made
            //fire off score event


        }
    }

    public virtual void attack(GameObject player)
    {
    
    }
        

    //set transform position to nearest player
    private Vector3 toPlayerStep()
    {
        return Vector3.MoveTowards(gameObject.transform.position, getNearestPlayer(), Time.deltaTime * speed);
    }

    //return position of closest player
    private Vector3 getNearestPlayer()
    {
        Vector3 closestEnemy = transform.position;
        float currentShortestPath = float.MaxValue;

        foreach (PlayerController player in FindObjectsOfType<PlayerController>())
        {
            //Debug.Log($"{FindObjectsOfType<PlayerController>().Length}");
            if(Vector3.Distance(player.transform.position, this.transform.position) < currentShortestPath)
            {
                //Debug.LogFormat($"Nearest player is: {player.name}");
                closestEnemy = player.transform.position;
                currentShortestPath = Vector3.Distance(player.transform.position, this.transform.position);
            }
        }
        return closestEnemy;
    
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Projectile")
        {
            if (other.GetComponent<Projectile>()._origin.tag == "Player")
                onDamage(other.GetComponent<Projectile>()._damage, Attacks.SHOTATTACK, other.GetComponent<Projectile>()._origin.GetComponent<PlayerGeneric>().hero);
            else
                onDamage(other.GetComponent<Projectile>()._damage, Attacks.SHOTATTACK, Hero.ENEMY);
        }
    }
}
