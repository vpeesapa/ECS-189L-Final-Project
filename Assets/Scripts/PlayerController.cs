using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D Rb;
    [SerializeField] private Animator Anim;
    [SerializeField] private float NormalSpeed = 5.0f;
    [SerializeField] private float FastSpeed = 7.5f;

    private bool collided;
    private bool IsGrounded = false;
    private GameObject Drop;


   
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Collectible")
        {
            this.collided = true;
            this.Drop = other.gameObject;
        }

        if(other.gameObject.tag == "Foreground")
        {
            this.IsGrounded = true;
        }

    }

    public void OnTriggerExit2D(Collider2D other)
    {
        this.collided = false;

        if(other.gameObject.tag == "Foreground")
        {
            this.IsGrounded = true;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        Rb.freezeRotation = true;
    }


    private void updateMoveAnimation(float horizontalMovement)
    {
        if(horizontalMovement < 0.0f)
        {
            this.transform.localScale = new Vector2(-1, 1);
            this.Anim.SetBool("Run", true);
        }

        else if(horizontalMovement > 0.0f)
        {
            this.transform.localScale = new Vector2(1, 1);
            this.Anim.SetBool("Run", true);
        }

        else
        {
            this.Anim.SetBool("Run", false);
        }
    }


    void Update()
    {
        float moveSpeed = this.NormalSpeed;

        if(Input.GetKey(KeyCode.Z))
        {
            moveSpeed = this.FastSpeed;
        }

        float horizontalMovement = Input.GetAxis("Horizontal");
        float movementDelta = moveSpeed * horizontalMovement * Time.deltaTime;
        this.transform.position += new Vector3(movementDelta, 0.0f, this.transform.position.z);
        updateMoveAnimation(horizontalMovement);


        if(Input.GetKey(KeyCode.Space) && this.IsGrounded)
        {   
            Rb.velocity = new Vector2(Rb.velocity.x, 5);
            this.IsGrounded = false;
            this.Anim.SetBool("Run",false);
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

    // If something kills the player, they return to the starting position
    public void Die()
    {
        this.gameObject.transform.position = new Vector3(0.0f,1.0f,0.0f);
    }
}
