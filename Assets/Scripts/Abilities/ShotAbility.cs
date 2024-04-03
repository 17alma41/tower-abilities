using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class ShotAbility : Ability
{
    LinearMovement linearMovement;

    public Transform spawnPoint;

    [Header("Shoot")]
    [SerializeField] float speed;
    [SerializeField] public GameObject projectile;

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

    public override void Trigger(Vector3 direction, MonoBehaviour mbCoroutine)
    {
        if (!isCooldown)
        {

            GameObject projectileInsta = Instantiate(
                projectile,
                spawnPoint.position,
                Quaternion.identity
            );

            linearMovement = projectileInsta.GetComponent<LinearMovement>();
            linearMovement.ShotDirection(speed, direction);

            Destroy(projectileInsta, 2f);

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
