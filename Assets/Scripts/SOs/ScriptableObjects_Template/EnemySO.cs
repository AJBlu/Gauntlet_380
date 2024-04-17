using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySO : ScriptableObject
{
    [Header("Points Values")]
    [SerializeField]
    int pointsMagicKill;
    [SerializeField]
    int pointsShootingKill;
    [SerializeField]
    int pointsFightingKill;

    [Header("Enemy Statistics")]
    [SerializeField]
    Rank rank;
    [SerializeField]
    bool isMelee;
    [SerializeField]
    int meleeDamage;
    [SerializeField]
    [Range(1,3)]
    int health;

    [Header("Projectile Values")]
    [SerializeField]
    bool passThroughWalls;
    [SerializeField]
    bool hitsObjects;
    [SerializeField]
    int projectileDamage;

}
