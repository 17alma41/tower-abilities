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

    public override void Trigger(Vector3 direction, MonoBehaviour mbCoroutine)
    {
        if (!isCooldown)
        {
            //StartCooldown();

            GameObject projectileInsta = Instantiate(
                megaProjectile,
                spawnPoint.position,
                Quaternion.identity
            );

            linearMovement = projectileInsta.GetComponent<LinearMovement>();
            linearMovement.ShotDirection(speed, direction);

            Destroy(projectileInsta, 8f);

            mbCoroutine.StartCoroutine(cooldownCouroutine());

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
