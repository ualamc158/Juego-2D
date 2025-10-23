using UnityEngine;

public class ControlFlipJugador : MonoBehaviour
{
    private GameObject player;
    private GameObject player_idle;
    private Rigidbody2D phisics;
    private SpriteRenderer sprite;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
        player = transform.parent.gameObject;
        player_idle = player.transform.Find("player-idle").gameObject;
        phisics = player_idle.GetComponent<Rigidbody2D>();
        sprite = phisics.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (phisics.linearVelocity.x > 0) sprite.flipX = false;
        if(phisics.linearVelocity.x < 0) sprite.flipX = true;
    }
}
