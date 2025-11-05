using UnityEngine;

public class ColliderEnemigo : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Si el objeto ha colisionado con el enemigo es el jugador
        if(collision.gameObject.CompareTag ("Player_idle"))
        {
          GameObject.FindGameObjectWithTag("ControlJuego").GetComponent<ControlJuego>().QuitarVida();
        }
    }
}
