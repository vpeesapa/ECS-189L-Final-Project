using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D Rb;
    [SerializeField]
    private Animator Anim;
    private bool collided;
    private bool IsGrounded = true;
    private GameObject Drop;


   
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Collectible")
        {
            this.collided = true;
            this.Drop = other.gameObject;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        this.collided = false;
    }


    // Start is called before the first frame update
    void Start()
    {
        Rb.freezeRotation = true;
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
        if(Input.GetKeyDown(KeyCode.E))
        {
            if (this.collided)
            {
                Destroy(this.Drop); 
            }
            else
            {
                Debug.Log("Space key was pressed.");
            }
        }


    }
}
