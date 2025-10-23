using UnityEngine;

public class MovimientoEnemigo : MonoBehaviour
{
    public enum Direction { Horizontal, Vertical }
    public Direction movementDirection = Direction.Horizontal;

    public float speed = 2f;     // Velocidad de movimiento
    public float distance = 3f;  // Distancia desde la posición inicial

    private Vector3 startPosition;
    private Vector3 targetPosition;

    void Start()
    {
        // Posición inicial del enemigo
        startPosition = transform.position;

        // Calcula el objetivo según la dirección
        targetPosition = movementDirection == Direction.Horizontal
            ? startPosition + new Vector3(distance, 0f, 0f)
            : startPosition + new Vector3(0f, distance, 0f);
    }

    void Update()
    {
        // Mover el enemigo hacia el objetivo
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Cambiar de dirección al llegar al objetivo
        if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
        {
            targetPosition = (targetPosition == startPosition)
                ? (movementDirection == Direction.Horizontal
                    ? startPosition + new Vector3(distance, 0f, 0f)
                    : startPosition + new Vector3(0f, distance, 0f))
                : startPosition;
        }
    }
}
