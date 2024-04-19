using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGeneric : IPlayerClass
{
    PlayerSO playerData;
    int currentHealth;
    
    public void assignPlayerAttributes()
    {
        //assign changeable attributes to player
    }

    public void OnFight()
    {
        //hit everything around you when pressing shoot button with no direction input
    }

    public void OnMagic()
    {
        //fetch list of every creature on screen
        //do magic damage to them
    }

    public void OnShoot()
    {
        //shoot in direction player puts joystick in
    }

    public void OnMove()
    {

    }

    public void OnPotionPickup(Potions potion)
    {
        switch(potion) {

            case Potions.ARMORBOOST:
                break;
            case Potions.MAGICBOOST:
                break;
            case Potions.SHOTBOOST:
                break;
            case Potions.SHOTSPEEDBOOST:
                break;
            case Potions.FIGHTBOOST:
                break;
            case Potions.SPEEDBOOST:
                break;
            case Potions.DESTRUCTIBLEFOOD:
                break;
            case Potions.FOOD:
                break;
            case Potions.INVISIBILITY:
                break;
        }
    }
}
