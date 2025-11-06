using UnityEngine;
using TMPro;

public class ControlHUD : MonoBehaviour
{
    public TextMeshProUGUI puntuacion;
    public TextMeshProUGUI numVidas;
    public TextMeshProUGUI tiempoEmpleado;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setNumVidas(int vidas)
    {
        numVidas.text = "Número de Vidas: " + vidas;
    }

    public void setPuntuacion(int puntos)
    {
        puntuacion.text = "Puntuación: " + puntos;
    }

    public void setTiempo(int tiempo)
    {
        tiempoEmpleado.text = "Tiempo empleado: " + tiempo;
    }
}
