using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGeneric : MonoBehaviour, IPlayerClass
{
    PlayerInventory inventory;
    ScreenBounds _screenBounds;
    PlayerSO playerData;
    int _currentHealth, _shotStrength, _magicMonsters, _magicGenerators, _magicShotMonsters, _magicShotGenerators, _meleeMonsters;
    float _armor, _meleeGenerators, _shotSpeed, _runningSpeed;
    
    public void assignPlayerAttributes()
    {
        _currentHealth = playerData.Health;
        _shotStrength = playerData.ShotStrength;
        _shotSpeed = playerData.shotSpeed;
        _shotStrength = playerData.ShotStrength;
        _magicMonsters = playerData.magicMonsters;
        _magicShotMonsters = playerData.magicShotMonsters; 
        _magicGenerators = playerData.magicGenerators;
        _magicShotGenerators = playerData.magicShotGenerators;
        _runningSpeed = playerData.RunningSpeed;
        _meleeMonsters = playerData.meleeMonsters;
        _meleeGenerators = playerData.meleeGenerators;
        _armor = playerData.Armor;
        inventory = gameObject.AddComponent<PlayerInventory>();
        _screenBounds = gameObject.AddComponent<ScreenBounds>();

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy" || other.tag == "Generator")
            OnFight(other);


    }

    public void OnFight(Collider collider)
    {
            if(collider.tag == "Enemy")
            {
                collider.GetComponent<Enemy_Generic>().onDamage(_meleeMonsters, Attacks.FIGHTATTACK);
            }

            if(collider.tag == "Generator")
            {
                if(Random.Range(0f, 1f) < _meleeGenerators)
                {
                    collider.GetComponent<Enemy_Generic>().onDamage(_meleeMonsters, Attacks.FIGHTATTACK);
                }
            }
    }

    public void OnMagic()
    {
        //fetch list of every creature on screen
        //do magic damage to them
        if (inventory.hasPotion())
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
                if (enemy.GetComponent<Renderer>().isVisible)
                {
                    enemy.GetComponent<Enemy_Generic>().onDamage(_magicMonsters, Attacks.MAGICATTACK);
                }
            }

            GameObject[] generators = GameObject.FindGameObjectsWithTag("Generator");
            foreach (GameObject generator in generators)
            {
                if(generator.GetComponent<Renderer>().isVisible)
                {
                    //todo: generator code
                }
            }
        }
    }

    public void OnShoot()
    {
        //shoot in direction player puts joystick in
    }

    public void OnMove()
    {

    }

    public void DamagePlayer(int damageTaken)
    {
        _currentHealth -= damageTaken;
    }
    public void OnPotionPickup(Potions potion)
    {
        switch(potion) {

            case Potions.ARMORBOOST:
                _armor = playerData.extraArmor;
                break;
            case Potions.MAGICBOOST:
                _magicMonsters = playerData.extraMagicMonsters;
                _magicGenerators = playerData.extraMagicGenerators;
                _magicShotMonsters = playerData.extraMagicShotMonsters;
                _magicShotGenerators= playerData.extraMagicShotGenerators;
                break;
            case Potions.SHOTBOOST:
                _shotStrength = playerData.extraShotStrength;
                break;
            case Potions.SHOTSPEEDBOOST:
                _shotSpeed = playerData.extraShotSpeed;
                break;
            case Potions.FIGHTBOOST:
                _meleeMonsters = playerData.extraMelee;
                break;
            case Potions.SPEEDBOOST:
                _runningSpeed = playerData.extraSpeed;
                break;
            case Potions.DESTRUCTIBLEFOOD:
                _currentHealth += 100;
                break;
            case Potions.FOOD:
                _currentHealth += 100;
                break;
            case Potions.INVISIBILITY:
                StartCoroutine("isInvisible");
                break;
        }
    }
    IEnumerator isInvisible()
    {
        yield return new WaitForSeconds(5);
    }
}
