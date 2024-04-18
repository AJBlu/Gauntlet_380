using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySO : ScriptableObject
{
    [Header("Points Values")]
    public int pointsMagicKill;
    public int pointsShootingKill;
    public int pointsFightingKill;

    [Header("Enemy Statistics")]
    public Rank rank;
    public bool isMelee;
    public int meleeDamage;
    [Range(1,3)]
    public int health;

    [Header("Damage Immunities")]
    public bool canFight;
    public bool canShoot;
    public bool canZap;

    [Header("Projectile Values")]
    public bool passThroughWalls;
    public bool hitsObjects;
    public int projectileDamage;

}
