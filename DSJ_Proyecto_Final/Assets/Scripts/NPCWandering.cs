using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCWandering : MonoBehaviour
{
    public float velocidad = 2.0f; // Velocidad de movimiento del NPC
    public float distancia = 10.0f; // Distancia total que el NPC recorrerá

    private float inicioX; // Posición inicial del NPC
    private bool moviendoseHaciaDerecha = true; // Dirección inicial

    void Start()
    {
        inicioX = transform.position.x;
    }

    void Update()
    {
        NPCMovement();   
    }

    void NPCMovement(){
        if (moviendoseHaciaDerecha)
        {
            transform.Translate(Vector2.right * velocidad * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * velocidad * Time.deltaTime);
        }

        // Si el NPC ha recorrido la distancia total, cambia de dirección
        if (Mathf.Abs(transform.position.x - inicioX) >= distancia)
        {
            moviendoseHaciaDerecha = !moviendoseHaciaDerecha;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }
}
