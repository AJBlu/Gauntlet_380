using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSO : ScriptableObject
{
    [Header("Shot Attributes")]
    public int ShotStrength;
    public float shotSpeed;
    public  ShotCollision colliderSize;

    [Header("Extra Shot Attributes")]
    public int extraShotStrength;
    public float extraShotSpeed;

    [Header("Magic Attributes")]
    public int magicMonsters;
    public int magicGenerators;
    public int magicShotMonsters;
    public int magicShotGenerators;

    [Header("Extra Magic Attributes")]
    public int extraMagicMonsters;
    public int extraMagicGenerators;
    public int extraMagicShotMonsters;
    public int extraMagicShotGenerators;

    [Header("Melee Attributes")]
    public int meleeMonsters;
    public float meleeGenerators;

    [Header("Extra Melee Attributes")]
    public int extraMelee;
    public float extraMeleeGenerators;

    [Header("Physical Attributes")]
    public float Armor;
    public int Health;
    public float RunningSpeed;

    [Header("Extra Physical Attributes")]
    public float extraArmor;
    public float extraSpeed;

}
