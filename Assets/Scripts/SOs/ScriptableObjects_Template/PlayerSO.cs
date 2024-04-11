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

    [Header("Magic Attributes")]
    [SerializeField]
    int magicMonsters;
    [SerializeField]
    int magicGenerators;
    [SerializeField]
    int magicShotMonsters;
    [SerializeField]
    int magicShotGenerators;

    [Header("Melee Attributes")]
    [SerializeField]
    int meleeMonsters;
    [SerializeField]
    int meleeGenerators;



    [Header("Physical Attributes")]
    [SerializeField]
    int Armor;
    [SerializeField]
    int Health;
    [SerializeField]
    float RunningSpeed;
}
