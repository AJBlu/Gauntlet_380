using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NondamageableGeneric : MonoBehaviour, IPickup
{
    public PotionSO value;

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerGeneric>().OnPotionPickup(value.potion);
        }
    }
    public Potions onPickUp()
    {
        return value.potion;
    }
}
