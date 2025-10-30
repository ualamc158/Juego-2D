using UnityEngine;

public class ControlPowerUP : MonoBehaviour
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
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            GameObject.FindGameObjectWithTag("ControlJuego").GetComponent<ControlJuego>().IncrementarPuntos(5);
            GameObject.Destroy(this);
        }
    }
}
