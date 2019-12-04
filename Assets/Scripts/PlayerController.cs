using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D Rb;
    [SerializeField] private Animator Anim;
    [SerializeField] private GameObject SpawnLocation;
    [SerializeField] private float NormalSpeed = 5.0f;
    [SerializeField] private float FastSpeed = 7.5f;
    [SerializeField] private float JumpStrength = 100.0f;
    [SerializeField] private float Gravity = -9.8f;

    private bool IsJumping = false;


    private bool Collided;
    private bool IsGrounded = false;
    private GameObject Drop;


   
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Collectible")
        {
            this.Collided = true;
            this.Drop = other.gameObject;
        }

        // if(other.gameObject.tag == "Foreground")
        // {
        //     this.IsGrounded = true;
        // }

    }

    public void OnTriggerExit2D(Collider2D other)
    {
        this.Collided = false;

        // if(other.gameObject.tag == "Foreground")
        // {
        //     this.IsGrounded = true;
        // }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            this.IsJumping = false;
            this.Rb.velocity = Vector2.zero;
        }

        else if(other.gameObject.CompareTag("Platform"))
        {
            this.IsJumping = false;
            this.gameObject.GetComponent<BoxCollider2D>().transform.SetParent(other.transform);
        }
    }

    public void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Platform"))
        {
            this.gameObject.GetComponent<BoxCollider2D>().transform.SetParent(null);
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


    void FixedUpdate()
    {
        float moveSpeed = this.NormalSpeed;

        if(Input.GetKey(KeyCode.Z))
        {
            moveSpeed = this.FastSpeed;
        }

        float horizontalMovement = Input.GetAxis("Horizontal");
        float movementDelta = moveSpeed * horizontalMovement * Time.deltaTime;
        this.transform.position += new Vector3(movementDelta, 0.0f, 0.0f);
        updateMoveAnimation(horizontalMovement);

        if(Input.GetKey(KeyCode.Space) && !this.IsJumping)
        {   
            this.IsJumping = true;
            this.Rb.AddForce(new Vector2(this.Rb.velocity.x, this.JumpStrength));
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(this.Collided)
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
        this.gameObject.transform.position = this.SpawnLocation.transform.position;
    }
}
