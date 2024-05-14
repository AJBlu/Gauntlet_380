using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour, IDamageable
{
    [SerializeField]
    GeneratorSO stats;
    
    int health;
    int points;
    Rank spawningRank;
    [SerializeField]
    GameObject[] ranks;
    public void assignDamageStats()
    {
        health = stats.health;
        spawningRank = stats.rank;
        points = stats.points;
    }

    public void onDeath(Attacks attackType, Hero hero)
    {
        SendScore(points, hero);
    }

    public void onDamage(int damageValue, Attacks attack, Hero hero)
    {
        health -= damageValue;
        if (health <= 0)
        {
            onDeath(attack, hero);
        }
    }

    private void spawnMonster()
    {
        switch (spawningRank)
        {
            case Rank.LOW:
                spawn(ranks[(int)Rank.LOW]);
                break;
            case Rank.MEDIUM:
                spawn(ranks[(int)Rank.MEDIUM]);
                break;
            case Rank.HIGH:
                spawn(ranks[(int)Rank.HIGH]);
                break;
        }
    }

    private void spawn(GameObject monster)
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 1.5f)){
            Instantiate(monster, transform.position + );
        }
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out hit, 1.5f))
        {

        }
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, 1.5f))
        {

        }
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, 1.5f))
        {

        }
    }
}
