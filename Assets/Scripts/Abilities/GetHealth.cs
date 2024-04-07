using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class GetHealth : Ability
{
    PlayerStats playerHealth;

    Image icon;


    void Update()
    {
     
    }

    public override void Trigger(Vector3 direction, MonoBehaviour mbCoroutine, List<Image> abilityIcon)
    {
        if (!isCooldown)
        {
            playerHealth = mbCoroutine.GetComponent<PlayerStats>();
            playerHealth.Heal(10);
            if (abilityIcon.Count > 0)
            {
                icon = abilityIcon[0];
                mbCoroutine.StartCoroutine(cooldownCouroutine(icon));
            }
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
