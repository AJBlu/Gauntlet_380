using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSO : ScriptableObject
{
    [Header("Shot Attributes")]
    [SerializeField]
    int ShotStrength;
    [SerializeField]
    float shotSpeed;
    [SerializeField]
    ShotCollision colliderSize;

    [Header("Extra Shot Attributes")]
    [SerializeField]
    int extraShotStrength;
    [SerializeField]
    float extraShotSpeed;

    [Header("Magic Attributes")]
    [SerializeField]
    int magicMonsters;
    [SerializeField]
    int magicGenerators;
    [SerializeField]
    int magicShotMonsters;
    [SerializeField]
    int magicShotGenerators;

    [Header("Extra Magic Attributes")]
    [SerializeField]
    int extraMagicMonsters;
    [SerializeField]
    int extraMagicGenerators;
    [SerializeField]
    int extraMagicShotMonsters;
    [SerializeField]
    int extraMagicShotGenerators;

    [Header("Melee Attributes")]
    [SerializeField]
    int meleeMonsters;
    [SerializeField]
    float meleeGenerators;

    [Header("Extra Melee Attributes")]
    [SerializeField]
    int extraMelee;
    [SerializeField]
    float extraMeleeGenerators;

    [Header("Physical Attributes")]
    [SerializeField]
    float Armor;
    [SerializeField]
    int Health;
    [SerializeField]
    float RunningSpeed;

    [Header("Extra Physical Attributes")]
    [SerializeField]
    float extraArmor;
    [SerializeField]
    float extraSpeed;

}
