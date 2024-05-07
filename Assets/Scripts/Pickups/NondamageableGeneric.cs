using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NondamageableGeneric : MonoBehaviour, IPickup
{
    [SerializeField]
    PotionSO potionType;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            onPickUp(other.gameObject);

        }

    }
    public void onPickUp(GameObject player)
    {
        if (player.GetComponent<PlayerGeneric>() != null)
        {
            player.GetComponent<PlayerGeneric>().OnPotionPickup(potionType.potion);
        }
        else
        {
            Debug.Log("Player Inventory not attached!");
        }
    }
}
