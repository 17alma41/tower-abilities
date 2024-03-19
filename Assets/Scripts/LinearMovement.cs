using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearMovement : MonoBehaviour
{
    public float speed = 20;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ShotDirection();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //Disparar hacia la dirección a la que apunta el jugador
    void ShotDirection()
    {
        //Esto da como resultado un vector que apunta desde la posición del objeto hacia la posición del cursor del mouse.
        Vector3 direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;

        rb.velocity = direction * speed;    
    }
}
