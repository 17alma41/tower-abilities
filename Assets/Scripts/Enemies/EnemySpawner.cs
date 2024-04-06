using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] List<Transform> enemySpawn;

    bool playerIsDead = false;

    [Header("Tiempo de aparición del enemigo")]
    [SerializeField] float spawnTime;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(enemySpawner());
        GameEvents.PlayerDead.AddListener(OnPlayerDeath);
    }

    void OnPlayerDeath()
    {
        playerIsDead = true;
    }

    // Update is called once per frame
    void Update()
    {
    }

    //Una coruotina con un bucle infinito que solo instancie y espera.

    IEnumerator enemySpawner()
    {
        while (true)
        {
            if (!playerIsDead)
            {
                Vector3 spawnPos = enemySpawn[Random.Range(0, enemySpawn.Count)].position;
                GameObject.Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
            }


            yield return new WaitForSeconds(spawnTime);
        }
    }
 
    
    /*
    void InstaciarEnemigo()
    {
        GameObject.Instantiate(
           enemyPrefab,
           enemySpawn[0].position,
           Quaternion.identity
           );
    }
    */
}
