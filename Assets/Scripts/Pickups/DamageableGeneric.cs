using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageableGeneric : MonoBehaviour, IPickup, IDamageable
{
    [SerializeField]
    PotionSO potionType;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            onPickUp(other.gameObject);

        }

        if(other.tag == "Projectile")
        {
            if(potionType.isPotion)
            {
                if (other.GetComponent<Projectile>().isPlayer)
                {
                    other.GetComponent<Projectile>().potionTrigger();
                }

                Destroy(this);
            }
        }
    }
    public void onPickUp(GameObject player)
    {
        if(player.GetComponent<PlayerGeneric>() != null)
        {
            player.GetComponent<PlayerGeneric>().OnPotionPickup(potionType.potion);
        }
        else
        {
            Debug.Log("Player Inventory not attached!");
        }
    }

    public void assignDamageStats()
    {

    }

    public void onDamage(int dv, Attacks attackType, Hero hero)
    {

    }

    public void onDeath(Attacks attackType, Hero hero)
    {
        
    }


}
