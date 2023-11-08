using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniPalm01 : MonoBehaviour
{
    public string nombreDeLaEscena; // Nombre de la escena a la que quieres cambiar

    void update(){
    
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Main_character"))
        {
            Debug.Log("Colisión con Player detectada"); // Imprime en la consola
            SceneManager.LoadScene("MensajeAceptacion01");
        }else{
            Debug.Log("No hay");
        }
    }
}
