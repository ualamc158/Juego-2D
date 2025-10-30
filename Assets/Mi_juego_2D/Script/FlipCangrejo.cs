using UnityEngine;

public class FlipCangrejo : MonoBehaviour
{
    private float escalaOriginalX;


    private Transform parentTransform;

    void Start()
    {

        parentTransform = transform.parent;


        escalaOriginalX = Mathf.Abs(parentTransform.localScale.x);
    }


    public void Voltear(float direccionX)
    {
        if (direccionX > 0.01f)
        {

            parentTransform.localScale = new Vector3(escalaOriginalX, parentTransform.localScale.y, parentTransform.localScale.z);
        }
        else if (direccionX < -0.01f) 
        {

            parentTransform.localScale = new Vector3(-escalaOriginalX, parentTransform.localScale.y, parentTransform.localScale.z);
        }
    }
}