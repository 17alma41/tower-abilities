using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MegaShot : ClasePadre
{
    LinearMovement linearMovement;

    [Header("Shoot")]
    [SerializeField] float speed;
    [SerializeField] GameObject projectile;
    [SerializeField] Transform spawnPoint;

    [Header("Icon")]
    [SerializeField] Image megaShotIcon;

    void Start()
    {
        megaShotIcon.fillAmount = 1f;
    }

    void Update()
    {
        if (isCooldown)
        {
            megaShotIcon.fillAmount = Mathf.Clamp01(elapsedCooldown / cooldown);
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

            Destroy(projectileInsta, 8f);
        }
        else if (elapsedCooldown >= cooldown)
        {
            elapsedCooldown = 0;
        }

    }
}
