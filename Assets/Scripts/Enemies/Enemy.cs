using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    SpriteRenderer sp;
    bool playerIsDead = false;


    [Header("Vida del enemigo")]
    [SerializeField] int maxHealth;
    int currentHealth = 0;

    [Header("Seguimiento del jugador")]
    [SerializeField] float speed;
    [SerializeField] Transform playerTransform;

    [Header("Enemy Visuals")]
    [SerializeField] Gradient hurtColor;

    // Start is called before the first frame update
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();


        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        currentHealth = maxHealth;

        GameEvents.PlayerDead.AddListener(OnPlayerDeath);
    }
    void OnPlayerDeath()
    {
        playerIsDead = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 enemyToPlayer = (playerTransform.position - transform.position).normalized;

        if (playerIsDead)
            transform.position -= enemyToPlayer * speed * Time.deltaTime;
        else
            transform.position += enemyToPlayer * speed * Time.deltaTime;

    }


    IEnumerator Hurt(int damage)
    {
        currentHealth -= damage;

        float hurt = 1f * damage / currentHealth;
        sp.color = hurtColor.Evaluate(hurt);

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }

        yield return null;
    }

    public void ApplyDamage(int damage)
    {
        StartCoroutine(Hurt(damage));
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            ApplyDamage(1);

            //Destruir el proyectil cuando choca contra el enemigo
            Destroy(collision.gameObject);  
        }

        if (collision.gameObject.CompareTag("MegaProjectile"))
        {
            ApplyDamage(10);

            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerStats playerHealth = collision.gameObject.GetComponent<PlayerStats>();
            playerHealth.ApplyDamage(1);

            Destroy(gameObject);
        }
    }

}
