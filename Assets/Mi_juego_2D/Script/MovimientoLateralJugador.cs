using Unity.VisualScripting;
using UnityEngine;

public class MovimientoLateralJugador : MonoBehaviour
{
    public int velocidad;

    private float entradaX;
    private Rigidbody2D fisica;
    private GameObject Jugador;
    private GameObject player_idle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Jugador = transform.parent.gameObject;
        player_idle = Jugador.transform.GetChild(0).gameObject;
        fisica = player_idle.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        fisica.linearVelocity = new Vector2(entradaX * velocidad, fisica.linearVelocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        entradaX = Input.GetAxis("Horizontal");
    }
}
