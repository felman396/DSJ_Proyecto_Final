using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
     public Transform jugador;
    public float margenHorizontal = 10f; // Margen para activar el movimiento de la cámara en horizontal
    public float suavizado = 5f; // Suavizado del movimiento de la cámara

    void Update()
    {
        if (EstaEnMargen())
        {
            Vector3 objetivo = new Vector3(jugador.position.x, transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, objetivo, suavizado * Time.deltaTime);
        }
    }

    bool EstaEnMargen()
    {
        return Mathf.Abs(transform.position.x - jugador.position.x) > margenHorizontal;
    }
}
