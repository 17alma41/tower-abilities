using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearMovement : MonoBehaviour
{
    Rigidbody2D rb;

    //Disparar hacia la dirección a la que apunta el jugador
    public void ShotDirection(float speed, Vector3 direction)
    {
        //Esto da como resultado un vector que apunta desde la posición del objeto hacia la posición del cursor del mouse.
        //direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;

        rb = GetComponent<Rigidbody2D>();

        rb.velocity = direction * speed;    
    }
}
