using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D Rb;
    [SerializeField]
    private Animator Anim;

    private bool IsGrounded = true;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            Rb.velocity = new Vector2(-5, Rb.velocity.y);
            this.transform.localScale = new Vector2(-1, 1);
            this.Anim.SetBool("Run", true);
        }

        else if(Input.GetKey(KeyCode.D))
        {
            Rb.velocity = new Vector2(5, Rb.velocity.y);
            this.transform.localScale = new Vector2(1, 1);
            this.Anim.SetBool("Run", true);
        }

        else 
        {
             this.Anim.SetBool("Run", false);
        }

        if(Input.GetKey(KeyCode.Space))
        {
            Rb.velocity = new Vector2(Rb.velocity.x, 5);
            this.IsGrounded = false;
        }


    }
}
