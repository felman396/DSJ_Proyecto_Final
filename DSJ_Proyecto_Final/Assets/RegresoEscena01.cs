using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RegresoEscena01 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void IniciarEscena() {
        SceneManager.LoadScene("Nivel01");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
