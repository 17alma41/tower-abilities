using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Transform playerTransform;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        Vector3 enemyToPlayer = (playerTransform.position - transform.position).normalized;

        transform.position += enemyToPlayer * speed * Time.deltaTime;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Proyectible"))
        {
            //Destruir el poreyectil cuando choca contra el enemigo
            Destroy(collision.gameObject);  

            //Destruir el enemigo
            Destroy(gameObject);
        }
    }
}
