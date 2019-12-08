using UnityEngine;

public class SquirrelController : MonoBehaviour
{
    SpriteRenderer SR;
    Rigidbody2D RB;

    void Start()
    {
        this.SR = gameObject.GetComponent<SpriteRenderer>();
        this.RB = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {        
        SR.flipX = RB.velocity.x >= 0;
    }
}
