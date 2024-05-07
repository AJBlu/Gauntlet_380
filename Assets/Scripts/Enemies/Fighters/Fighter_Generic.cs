using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fighter_Generic : Enemy_Generic
{
    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
            attack(col.gameObject);
    }

    public override void attack(GameObject player)
    {
        base.attack(player);
        player.GetComponent<PlayerGeneric>().DamagePlayer(enemyData.meleeDamage);

        //implement melee attack pattern
    }
}
