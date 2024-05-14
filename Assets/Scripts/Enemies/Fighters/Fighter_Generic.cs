using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Fighter_Generic : Enemy_Generic
{
    bool isAttacking;

    private void Awake()
    {
        isAttacking = false;
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player" && !isAttacking)
            StartCoroutine("delayedAttack");
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            StopCoroutine("delayedAttack");
    }

    public override void attack(GameObject player)
    {
        //base.attack(player);
        player.GetComponent<PlayerGeneric>().DamagePlayer(enemyData.meleeDamage);

        //implement melee attack pattern
    }

    IEnumerator delayedAttack(PlayerGeneric pg)
    {
        isAttacking = true;
        pg.DamagePlayer(enemyData.meleeDamage);
        yield return new WaitForSeconds(.25f);
        isAttacking = false;
    }
}
