using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clase3Mov : MonoBehaviour
{
    //DIRECCION
    private int movimientoHorizontal = 0;
    private int movimientoVertical = 0;
    private Vector2 mov = new Vector2(0, 0);

    //VELOCIDAD
    [SerializeField] private float speed = 10;

    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();//quiero acceder a las propiedades del RigidBody de mi objeto, para eso lo asigno a una variable
    }

    // Update is called once per frame
    void Update()
    {
        //MOVIMIENTO VERTICAL
        if (Input.GetKey(KeyCode.W))
        { movimientoVertical = 1; }
        else if (Input.GetKey(KeyCode.S))
        { movimientoVertical = (-1); }
        else
        { movimientoVertical = 0; } //puesto en el else
        //MOVIMIENTO HORIZONTAL
        if (Input.GetKey(KeyCode.D))
        { movimientoHorizontal = 1; }
        else if (Input.GetKey(KeyCode.A))
        { movimientoHorizontal = (-1); }
        else { movimientoHorizontal = 0; }//puesto en el else
    }
    void FixedUpdate()
    {
        //Asignamos la variable que determina la direccion
        mov = new Vector2(movimientoHorizontal, movimientoVertical);
        //Normalizamos el vector, hace que el movimiento sea igual en todas las direcciones, sin importar si es diagonal o recta
        mov = mov.normalized;
        //Empujamos nuestro objeto
        rb.AddForce(mov * speed * Time.fixedDeltaTime);
        //empuja al objeto en la direccion que le asignamos, multiplicado por la velocidad y por el tiempo que tarda en actualizarse el FixedUpdate
    }
}
