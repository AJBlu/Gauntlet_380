using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour, IDamageable
{
    [SerializeField]
    GeneratorSO stats;
    
    int health;

    Rank spawningRank;
    [SerializeField]
    GameObject[] ranks;
    public void assignDamageStats()
    {
        health = stats.health;
        spawningRank = stats.rank;

    }

    public void onDeath(Attacks attack)
    {
        //send score
        Destroy(gameObject);
    }

    public void onDamage(int damageValue, Attacks attack)
    {

    }

    private void spawnMonster()
    {

    }
}
