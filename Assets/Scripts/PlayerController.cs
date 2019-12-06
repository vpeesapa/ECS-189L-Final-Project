using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D Rb;
    [SerializeField] private Animator Anim;
    [SerializeField] private GameObject SpawnLocation;
    [SerializeField] private float NormalSpeed = 5.0f;
    [SerializeField] private float FastSpeed = 7.5f;
    [SerializeField] private float JumpStrength = 100.0f;
    [SerializeField] private float JumpTime;

    private float JumpTimeCounter;
    private bool IsJumping = false;
    private bool Collided;
    private bool IsGrounded = false;
    private GameObject Drop;
    private int GemsCollected = 0;

   
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
            this.IsGrounded = true;
            this.Rb.velocity = Vector2.zero;
        }

        else if(other.gameObject.CompareTag("Gem"))
        {
            this.GemsCollected++;
            Debug.Log("Collected a Gem! Total Gem Count: " + this.GemsCollected.ToString());
            Destroy(other.gameObject);
        }

        else if(other.gameObject.CompareTag("Platform"))
        {
            this.IsGrounded = true;
            this.gameObject.GetComponent<BoxCollider2D>().transform.SetParent(other.transform);
        }

        else if(other.gameObject.CompareTag("Crate"))
        {
            this.IsGrounded = true;
            this.Rb.velocity = Vector2.zero;
        }
        
        else if(other.gameObject.CompareTag("Saw") || other.gameObject.CompareTag("Acid"))
        {
            // Kills the player upon contact with the blade.
            this.Die();
        }
    }

    public void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            this.IsGrounded = false;
        }

        // else if(other.gameObject.CompareTag("Crate"))
        // {
        //     this.IsGrounded = false;
        // }

        else if(other.gameObject.CompareTag("Platform"))
        {
            this.IsGrounded = false;
            this.gameObject.GetComponent<BoxCollider2D>().transform.SetParent(null);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Rb.freezeRotation = true;
        this.transform.position = this.SpawnLocation.transform.position;
    }


    private void updateMoveAnimation(float horizontalMovement)
    {
        if(horizontalMovement < 0.0f)
        {
            this.transform.localScale = new Vector2(-1, 1);
            if(!this.IsJumping)
            {
                // The run animation should only work while on the ground.
                this.Anim.SetBool("Run", true);
            }
        }

        else if(horizontalMovement > 0.0f)
        {
            this.transform.localScale = new Vector2(1, 1);
            if(!this.IsJumping)
            {
                // The run animation should only work while on the ground.
                this.Anim.SetBool("Run", true);
            }
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

        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        this.Rb.velocity = new Vector2(horizontalMovement * moveSpeed, this.Rb.velocity.y);
        //float movementDelta = moveSpeed * horizontalMovement * Time.deltaTime;
        //this.transform.position += new Vector3(movementDelta, 0.0f, 0.0f);
        updateMoveAnimation(horizontalMovement);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && this.IsGrounded)
        {   
            this.IsGrounded = false;
            this.IsJumping = true;
            this.JumpTimeCounter = this.JumpTime;
            this.Rb.velocity = Vector2.up * this.JumpStrength;
            //this.Rb.AddForce(new Vector2(this.Rb.velocity.x, this.JumpStrength));
            this.Anim.SetBool("Run",false);
            gameObject.GetComponent<AudioSource>().Play();
        }

        if(Input.GetKey(KeyCode.Space) && this.IsJumping)
        {
            if(this.JumpTimeCounter > 0.0f)
            {
                this.Rb.velocity = Vector2.up * this.JumpStrength;
                this.JumpTimeCounter -= Time.deltaTime;
            }

            else
            {
                this.IsJumping = false;
            }
        }

        if(Input.GetKeyUp(KeyCode.Space))
        {
            this.IsJumping = false;
        }



        if(Input.GetKeyDown(KeyCode.E))
        {
            if(this.Collided)
            {
                Destroy(this.Drop); 
            }
     
        }
    }

    // If something kills the player, the level is reloaded
    public void Die()
    {
        this.gameObject.transform.position = this.SpawnLocation.transform.position;
        this.Rb.velocity = Vector2.zero;
    }
}
