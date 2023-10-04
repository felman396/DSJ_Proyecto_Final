using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public GameObject[] paneles;
    private int panelActual = 0;
    public Text textoUI;

    void Start()
    {
        MostrarPanel(panelActual);
    }

    public void MostrarSiguientePanel()
    {
        panelActual++;
        if(panelActual==paneles.Length-1)
            textoUI.text = "Empezar";
        if (panelActual >= paneles.Length)
            //panelActual = 0;
            SceneManager.LoadScene("SampleScene");

        MostrarPanel(panelActual);
    }
        
    private void MostrarPanel(int indice)
    {
        for (int i = 0; i < paneles.Length; i++)
        {
            paneles[i].SetActive(i == indice);
        }
    }
}
