using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    SpriteRenderer sp;

    [Header("Health")]
    [SerializeField] int maxHealth;
    [SerializeField] int currentHealth = 0;

    [Header("Visuals")]
    [SerializeField] Gradient hurtColor;

    // Start is called before the first frame update
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GetDamage(int damage)
    {
        currentHealth -= damage;

        float hurt = 1f * damage / currentHealth;
        sp.color = hurtColor.Evaluate(hurt);

        if (currentHealth <= 0)
        {
            GameEvents.PlayerDead.Invoke();
        }

        yield return null;
    }

    public void ApplyDamage(int damage)
    {
        StartCoroutine(GetDamage(damage));
    }

    public void Heal(int health)
    {
        currentHealth += health;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    }
}
