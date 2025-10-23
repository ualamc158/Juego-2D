using UnityEngine;

public class EnemigoMovimiento2D : MonoBehaviour
{

    [SerializeField] private float velocidad = 2f;
    [SerializeField] private bool movimientoDerecha = true;

    [SerializeField] private Transform controladorSuelo;
    [SerializeField] private float distancia = 0.5f;

    private Vector3 puntoDestino;

    void Start()
    {
      
        puntoDestino = transform.position + Vector3.right * 1f;
    }

    void Update()
    {
        
        Vector3 direccion = movimientoDerecha ? Vector3.right : Vector3.left;

       
        transform.position = Vector3.MoveTowards(transform.position,transform.position + direccion, velocidad * Time.deltaTime);



        RaycastHit2D informacionSuelo = Physics2D.Raycast(controladorSuelo.position, Vector2.down, distancia);

   
        if (informacionSuelo.collider == null)
        {
            Girar();
        }
    }

    private void Girar()
    {
       
        movimientoDerecha = !movimientoDerecha;

      
        transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y + 180f, 0f);
    }

    private void OnDrawGizmos()
    {
        if (controladorSuelo != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(controladorSuelo.position, controladorSuelo.position + Vector3.down * distancia);
        }
    }
}
