using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlJuego : MonoBehaviour
{
    public int numVidas;
    public int puntuacion;
    public int tiempoNivel;

    private int tiempoInicio;
    private int tiempoEmpleado;
    private bool vulnerable;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tiempoInicio = (int) Time.time;
        vulnerable = true;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FinJuego()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void IncrementarPuntos(int cantidad)
    {
        puntuacion += cantidad;
    }

    public void QuitarVida()
    {
        numVidas--;
        if (numVidas <= 0)
        {
            FinJuego();
        }
    }
}
