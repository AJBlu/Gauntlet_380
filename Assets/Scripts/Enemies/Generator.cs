using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour, IDamageable
{
    [SerializeField]
    GeneratorSO stats;
    
    public int health;
    int points;
    Rank spawningRank;
    [SerializeField]
    GameObject[] ranks;
    bool isRunning;
    public Transform v;

    private void Awake()
    {
        isRunning = false;
        assignDamageStats();
    }
    public void Update()
    {
        if(gameObject.GetComponent<Renderer>().isVisible && !isRunning)
        {
            StartCoroutine("spawnCoroutine");
        }
    }
    public void assignDamageStats()
    {
        health = stats.health;
        spawningRank = stats.rank;
        points = stats.points;
    }

    public void onDeath(Attacks attack, Hero hero)
    {
        SendScore(points, hero);
        StopCoroutine("spawnCoroutine");
        Destroy(gameObject);

    }
    public void SendScore(int points, Hero hero)
    {
        if (hero != Hero.ENEMY)
        {
            //TODO once scoring system and UI events are being made
            //fire off score event


        }
    }
    public void onDamage(int damageValue, Attacks attack, Hero hero)
    {
        Debug.Log("Generator Hit");
        health -= damageValue;
        if (health < 1)
        {
            onDeath(attack, hero);
        }
    }

    private void spawnMonster()
    {
        switch (spawningRank)
        {
            case Rank.LOW:
                spawn(ranks[(int)Rank.LOW]);
                break;
            case Rank.MEDIUM:
                spawn(ranks[(int)Rank.MEDIUM]);
                break;
            case Rank.HIGH:
                spawn(ranks[(int)Rank.HIGH]);
                break;
        }
    }

    private void spawn(GameObject monster)
    {
        //RaycastHit hit;
        if (gameObject.GetComponent<Renderer>().isVisible)
        {
            /*if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 1.5f))
            {
                v.position = Vector3.forward * 1.5f;
            }
            else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out hit, 1.5f))
            {
                v.position = Vector3.back * 1.5f;
            }
            else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, 1.5f))
            {
                v.position = Vector3.right * 1.5f;
            }
            else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, 1.5f))
            {
                v.position = Vector3.left * 1.5f;
            }
            else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward + Vector3.left), out hit, 1.5f))
            {
                v.position = (Vector3.left + Vector3.forward) * 1.5f;

            }
            else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back + Vector3.right), out hit, 1.5f))
            {
                v.position = (Vector3.back + Vector3.right) * 1.5f;

            }
            else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left + Vector3.back), out hit, 1.5f))
            {
                v.position = (Vector3.left + Vector3.back) * 1.5f;

            }
            else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right + Vector3.forward), out hit, 1.5f))
            {
                v.position = (Vector3.right + Vector3.forward) * 1.5f;

            }*/


            Instantiate(monster, transform.position + getNearestPlayerNormalized(), Quaternion.identity);
        }
    }

    public IEnumerator spawnCoroutine()
    {
        Debug.Log("Spawn!");
        isRunning = true;
        spawnMonster();
        yield return new WaitForSeconds(2f);
        isRunning = false;
    }
    private Vector3 getNearestPlayerNormalized()
    {
        Vector3 closestEnemy = transform.position;
        float currentShortestPath = float.MaxValue;

        foreach (PlayerController player in FindObjectsOfType<PlayerController>())
        {
            //Debug.Log($"{FindObjectsOfType<PlayerController>().Length}");
            if (Vector3.Distance(player.transform.position, this.transform.position) < currentShortestPath)
            {
                //Debug.LogFormat($"Nearest player is: {player.name}");
                closestEnemy = player.transform.position;
                currentShortestPath = Vector3.Distance(player.transform.position, this.transform.position);
            }
        }
        return closestEnemy.normalized;

    }
}
