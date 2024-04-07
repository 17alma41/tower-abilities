using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class MegaShot : Ability
{
    LinearMovement linearMovement;

    public Transform spawnPoint;

    [Header("Shoot")]
    [SerializeField] float speed;
    [SerializeField] public GameObject megaProjectile;

    Image icon;


    void Update()
    {
      
    }

    public override void Trigger(Vector3 direction, MonoBehaviour mbCoroutine, List<Image> abilityIcon)
    {
        if (!isCooldown)
        {
            GameObject projectileInsta = Instantiate(
                megaProjectile,
                spawnPoint.position,
                Quaternion.identity
            );

            linearMovement = projectileInsta.GetComponent<LinearMovement>();
            linearMovement.ShotDirection(speed, direction);

            Destroy(projectileInsta, 8f);

            mbCoroutine.StartCoroutine(cooldownCouroutine(icon));

        }
        else if (elapsedCooldown >= cooldown)
        {
            elapsedCooldown = 0;
        }

    }

    public override void Transform(Transform player)
    {
        spawnPoint = player.Find("Gun");
    }

}
