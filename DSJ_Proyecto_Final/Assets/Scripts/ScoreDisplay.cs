using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreDisplay : MonoBehaviour
{
    public TextMesh scoreText; // Aquí, no se asigna un valor directo, sino el componente Text.

    void Update()
    {
        // scoreText no sea null antes de intentar acceder a su propiedad 'text'.
        if (scoreText != null)
        {
            // Actualización del texto mostrado con el puntaje actual desde el GameManager.
            scoreText.text = "Puntaje: " + GameManager.Instance.score.ToString();

            // Comprueba si el puntaje llega a 4 puntos.
            if (GameManager.Instance.score >= 1)
            {
                // Cambia a la escena deseada.
                SceneManager.LoadScene("Nivel02");
            }
        }

        // Muestra el puntaje en la consola.
        //Debug.Log("Puntaje: " + GameManager.Instance.score);
    }
}