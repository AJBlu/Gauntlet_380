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

    public void onDeath(Attacks attack, Hero hero)
    {
        //send score
        Destroy(gameObject);
    }

    public void onDamage(int damageValue, Attacks attack, Hero hero)
    {

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
