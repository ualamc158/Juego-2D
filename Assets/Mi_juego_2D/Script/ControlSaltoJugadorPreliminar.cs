using System;
using UnityEngine;

public class ControlSaltoJugadorPreliminar : MonoBehaviour
{
    public int fuerzaSalto;

    private Rigidbody2D fisica;
    private bool entradaSalto;

    private GameObject Jugador;
    private GameObject player_idle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Jugador = transform.parent.gameObject;
        player_idle = Jugador.transform.Find("player-idle").gameObject;
        fisica = player_idle.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (entradaSalto == true)
        {
            fisica.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            entradaSalto = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && tocarSuelo())
        {
            entradaSalto = true;
        }
    }
    private bool tocarSuelo()
    {
        // problema de offset +new Vector3(0,-2f,0) para que el rayo salga desde la base del jugador
        RaycastHit2D toca = Physics2D.Raycast(player_idle.transform.position + new Vector3(0, -2f, 0), Vector2.down, 0.2f);
        return toca.collider != null;
    }


}
