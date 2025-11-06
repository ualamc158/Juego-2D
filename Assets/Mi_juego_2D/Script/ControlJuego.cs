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
    private GameObject jugador;
    private GameObject player_idle;
    private SpriteRenderer sprite;

    public Canvas canvas;
    private ControlHUD hud;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tiempoInicio = (int) Time.time;
        tiempoNivel = 60;
        vulnerable = true;
        jugador = GameObject.FindGameObjectWithTag("Player").gameObject;
        player_idle = jugador.transform.Find("player-idle").gameObject;
        sprite = player_idle.GetComponent<SpriteRenderer>();
        hud = canvas.GetComponent<ControlHUD>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectsWithTag("PowerUp").Length == 0){
            GanarJuego();
        }

        //Actualizar tiempo empleado
        tiempoEmpleado = (int) Time.time - tiempoInicio;
        hud.setTiempo(tiempoEmpleado); 

        //Comprobar si hemos usado  todo el tiempo
        if (tiempoNivel - tiempoEmpleado < 0)
        {
            FinJuego();
        }

        hud.setPuntuacion(puntuacion);
        hud.setNumVidas(numVidas);
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
        if(vulnerable)
        {
            vulnerable = false;
            numVidas--;
            
            if (numVidas == 0)
            {
                FinJuego();
            }
            Invoke("HacerVulnerable", 2f);
            sprite.color = Color.red;
        } 
    }

    public void GanarJuego()
    { 
        puntuacion += (numVidas * 100) + (tiempoNivel - tiempoEmpleado); 
        Debug.Log("Has ganado el juego! Puntuación final: " + puntuacion);
    }

    private void HacerVulnerable()
    {
        vulnerable = true;
        sprite.color = Color.white;
    }
}
