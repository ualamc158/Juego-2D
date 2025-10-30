using Unity.VisualScripting;
using UnityEngine;

public class ControlAnimacionJugador : MonoBehaviour
{
    private GameObject jugador;
    private GameObject player_idle;
    private Animator animacion;
    private Rigidbody2D fisica;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        jugador = transform.parent.gameObject;
        player_idle = jugador.transform.Find("player-idle").gameObject;
        animacion = player_idle.GetComponent<Animator>();
        fisica = player_idle.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        animarJugador();
        //Debug.DrawRay(player_idle.transform.position + new Vector3(0, -1.5f, 0), Vector3.down * 5, Color.green, 2f);
        
    }

    private void animarJugador()
    {
        //Jugador Saltar
        if (!tocarSuelo())
            animacion.Play("JugadorSaltando");
        else
        {
            //Jugador Corriendo
            if (fisica.linearVelocity.x != 0 && fisica.linearVelocity.y == 0)
            {
                animacion.Play("JugadorCorriendo");
            }
            //Jugador Parado
            if (fisica.linearVelocity.x == 0 && fisica.linearVelocity.y == 0)
            {
                animacion.Play("JugadorParado");
            }
        }
        
    }

    private bool tocarSuelo()
    {
        // problema de offset +new Vector3(0,-2f,0) para que el rayo salga desde la base del jugador
        RaycastHit2D toca = Physics2D.Raycast(player_idle.transform.position + new Vector3(0, -2f, 0), Vector2.down, 0.2f);
        

        // Dibujar rayo
        Debug.DrawRay(player_idle.transform.position + new Vector3(0, -1.5f, 0), Vector3.down*(toca.distance + 0.5f) , Color.green, 2f);

        return toca.collider != null;
    }
}
