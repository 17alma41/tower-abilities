using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotAbility : ClasePadre
{
    [Header("Shoot")]
    [SerializeField] float speed;
    [SerializeField] GameObject proyectile;
    [SerializeField] Transform spawnPoint;

    public override void Trigger()
    {
        print("Clase 1 heredado de Clase Padre");

        GameObject.Instantiate(
            proyectile,
            spawnPoint.position,
            Quaternion.identity
            );
    }



}
