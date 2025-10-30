using UnityEngine;

public class ControlAnimacionCangrejo : MonoBehaviour
{
    private Animator anim;

    void Start()
    {

        anim = transform.parent.GetComponentInChildren<Animator>();

        if (anim == null)
        {
            Debug.LogError("No se encontró un Animator en los hijos del objeto padre.");
        }
    }


    public void SetMoviendo(bool estaMoviendo)
    {
        if (anim == null) return;

        if (estaMoviendo)
        {
            anim.Play("CangrejoCaminando");
        }
        else
        {
            anim.Play("CangrejoParado");
        }
    }
}