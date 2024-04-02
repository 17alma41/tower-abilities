using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShotAbility : ClasePadre
{
    LinearMovement linearMovement;

    [Header("Shoot")]
    [SerializeField] float speed;
    [SerializeField] GameObject projectile;
    [SerializeField] Transform spawnPoint;

    [Header("Icon")]
    [SerializeField] Image shotAbilityIcon;

    void Start()
    {
        shotAbilityIcon.fillAmount = 1f;
    }

    void Update()
    {
        if (isCooldown)
        {
            shotAbilityIcon.fillAmount = Mathf.Clamp01(elapsedCooldown / cooldown);
        }
    }

    public override void Trigger(Vector3 direction)
    {
        if (!isCooldown)
        {
            StartCooldown();

            GameObject projectileInsta = Instantiate(
                projectile,
                spawnPoint.position,
                Quaternion.identity
            );

            linearMovement = projectileInsta.GetComponent<LinearMovement>();
            linearMovement.ShotDirection(speed, direction);

            Destroy(projectileInsta, 2f);
        }
        else if (elapsedCooldown >= cooldown)
        {
            elapsedCooldown = 0;
        }
        
    }

}
