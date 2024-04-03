using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class GetHealth : Ability
{
    PlayerStats playerHealth;

    [Header("Icon")]
    [SerializeField] Image getHealthIcon;

    void Start()
    {
        getHealthIcon.fillAmount = 1f;
        //playerHealth = GetComponent<PlayerStats>();
    }

    void Update()
    {
        if (isCooldown)
        {
            getHealthIcon.fillAmount = Mathf.Clamp01(elapsedCooldown / cooldown);
        }
    }

    public override void Trigger(Vector3 direction)
    {
        if (!isCooldown)
        {
            //StartCooldown();

            playerHealth.Heal(10);
        }
        else if (elapsedCooldown >= cooldown)
        {
            elapsedCooldown = 0;
        }
    }

    public override void Transform(Transform player)
    {

    }

}
