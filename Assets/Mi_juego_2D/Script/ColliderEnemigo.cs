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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Si el objeto ha colisionado con el enemigo es el jugador
        if(collision.gameObject.CompareTag ("Player"))
        {
          GameObject.FindGameObjectWithTag("ControlJuego").GetComponent<ControlJuego>().FinJuego();
        }
    }
}
