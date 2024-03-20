using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotAbility : ClasePadre
{
    [Header("Shoot")]
    [SerializeField] float speed;
    [SerializeField] GameObject proyectile;
    [SerializeField] Transform spawnPoint;

    LinearMovement linearMovement;
    Rigidbody2D rb;

    public override void Trigger(Vector3 direction)
    {
        print("Clase 1 heredado de Clase Padre");

        GameObject proyectileInsta = Instantiate(
        proyectile,
        spawnPoint.position,
        Quaternion.identity
        );


        linearMovement = proyectileInsta.GetComponent<LinearMovement>();
        linearMovement.ShotDirection(speed, direction);


        Destroy(proyectileInsta, 2f);
    }

}
