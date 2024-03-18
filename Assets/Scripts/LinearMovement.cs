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
        rb.velocity = transform.position * speed;
        ShotDirection();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ShotDirection()
    {
        Vector3 mousePos = new Vector3(0, 0, 0);

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        Vector3 targetDir = mousePos - transform.position;
        float angle = Vector3.SignedAngle(Vector3.up, targetDir, Vector3.forward);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
