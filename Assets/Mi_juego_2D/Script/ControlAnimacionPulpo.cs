using UnityEngine;

public class ControlAnimacionPulpo : MonoBehaviour
{
    private Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
            anim.Play("PulpoMovimiento");
        }
        
    }
}
