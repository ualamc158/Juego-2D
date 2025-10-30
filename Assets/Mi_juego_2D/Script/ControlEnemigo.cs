using UnityEngine;

public class ControlEnemigo : MonoBehaviour
{
    public Vector3 posicionFin;
    public float velocidad;

    private Vector3 posicionInicio;
    private bool movimientoAFin;


    private FlipCangrejo flipScript;
    private ControlAnimacionCangrejo animScript;

    private Transform parentTransform;

    void Start()
    {
        parentTransform = transform.parent;

        flipScript = GetComponent<FlipCangrejo>();
        animScript = GetComponent<ControlAnimacionCangrejo>();

        posicionInicio = parentTransform.position;
        movimientoAFin = true;


        DarOrdenDeVoltear(posicionFin - posicionInicio);
    }

    void Update()
    {
        moverEnemigo();
    }

    private void moverEnemigo()
    {
        Vector3 posicionDestino = (movimientoAFin) ? posicionFin : posicionInicio;

        Vector3 posAntesDeMover = parentTransform.position;

        parentTransform.position = Vector3.MoveTowards(posAntesDeMover, posicionDestino, velocidad * Time.deltaTime);

        bool seEstaMoviendo = (parentTransform.position != posAntesDeMover);


        if (animScript != null)
        {
            animScript.SetMoviendo(seEstaMoviendo);
        }


        if (Vector3.Distance(parentTransform.position, posicionDestino) < 0.1f)
        {
            Vector3 proximaDireccion;
            if (movimientoAFin)
            {
                movimientoAFin = false;
                proximaDireccion = posicionInicio - parentTransform.position;
            }
            else
            {
                movimientoAFin = true;
                proximaDireccion = posicionFin - parentTransform.position;
            }

            DarOrdenDeVoltear(proximaDireccion);
        }
    }

    void DarOrdenDeVoltear(Vector3 direccion)
    {

        if (flipScript != null)
        {
            flipScript.Voltear(direccion.x);
        }
    }
}