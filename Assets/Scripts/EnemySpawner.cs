using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform enemySpawn;


    // Start is called before the first frame update
    void Start()
    {
        InstaciarEnemigo();
    }

    // Update is called once per frame
    void Update()
    {
       
    }


    void InstaciarEnemigo()
    {
        GameObject.Instantiate(
           enemyPrefab,
           enemySpawn.position,
           Quaternion.identity
           );
    }
}
