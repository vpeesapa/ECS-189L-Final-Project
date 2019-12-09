

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D Rb;
    [SerializeField] private Animator Anim;
    [SerializeField] private GameObject SpawnLocation;
    [SerializeField] private float NormalSpeed = 5.0f;
    [SerializeField] private float FastSpeed = 7.5f;
    [SerializeField] private float JumpStrength = 100.0f;
    [SerializeField] private float JumpTime;
    [SerializeField] private Text UIScore;
    [SerializeField] private Text UILevelName;
    [SerializeField] private Image UIPanelImage;
    [SerializeField] private TextMesh UINumGemsLeft;
    [SerializeField] private int NumGemsLeft = 0;

    private float JumpTimeCounter;
    private bool IsJumping = false;
    private bool Collided;
    private bool IsGrounded = false;
    private GameObject Drop;
    private int GemsCollected = 0;
    private bool OnConveyor = false;
    private float ConveyorSpeed = 3.0f;



    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Gem"))
        {
            this.GemsCollected++;
            this.NumGemsLeft--;
            Debug.Log("Collected a Gem! Total Gem Count: " + this.GemsCollected.ToString());
            other.gameObject.SetActive(false);
            this.UIScore.text = this.GemsCollected.ToString();
            this.UINumGemsLeft.text = this.NumGemsLeft.ToString();
            
        }

        else if (other.gameObject.tag == "Spike")
        {
            this.Die();
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
        if (other.gameObject.CompareTag("Ground"))
        {
            this.IsGrounded = true;
            this.Rb.velocity = Vector2.zero;
        }

        else if (other.gameObject.CompareTag("Platform"))
        {
            this.IsGrounded = true;
            this.gameObject.GetComponent<BoxCollider2D>().transform.SetParent(other.transform);
        }

        else if(other.gameObject.CompareTag("Conveyor"))
        {
            this.IsGrounded = true;
            this.gameObject.GetComponent<BoxCollider2D>().transform.SetParent(other.transform);
            this.OnConveyor = true;
        }

        else if (other.gameObject.CompareTag("Crate"))
        {
            this.IsGrounded = true;
            this.Rb.velocity = Vector2.zero;
        }

        else if (other.gameObject.CompareTag("Spikes"))
        {
            this.Die();
        }

        else if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            this.Die();
        }

        else if (other.gameObject.CompareTag("Saw") || other.gameObject.CompareTag("Acid"))
        {
            // Kills the player upon contact with the blade.
            this.Die();
        }
    }

    public void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            this.IsGrounded = false;
        }

        else if (other.gameObject.CompareTag("Platform"))
        {
            this.IsGrounded = false;
            this.gameObject.GetComponent<BoxCollider2D>().transform.SetParent(null);
        }

        else if(other.gameObject.CompareTag("Conveyor"))
        {
            this.IsGrounded = false;
            this.OnConveyor = false;
            this.gameObject.GetComponent<BoxCollider2D>().transform.SetParent(null);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Rb.freezeRotation = true;
        this.transform.position = this.SpawnLocation.transform.position;
        this.GemsCollected = 0;
            this.UINumGemsLeft.text = this.NumGemsLeft.ToString();
    }


    private void updateMoveAnimation(float horizontalMovement)
    {
        if (horizontalMovement < 0.0f)
        {
            this.transform.localScale = new Vector2(-1, 1);
            if (!this.IsJumping)
            {
                // The run animation should only work while on the ground.
                this.Anim.SetBool("Run", true);
            }
        }

        else if (horizontalMovement > 0.0f)
        {
            this.transform.localScale = new Vector2(1, 1);
            if (!this.IsJumping)
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

        if (Input.GetKey(KeyCode.Z))
        {
            moveSpeed = this.FastSpeed;
        }

        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        this.Rb.velocity = new Vector2(horizontalMovement * moveSpeed, this.Rb.velocity.y);
        updateMoveAnimation(horizontalMovement);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && this.IsGrounded)
        {
            this.IsGrounded = false;
            this.IsJumping = true;
            this.JumpTimeCounter = this.JumpTime;
            this.Rb.velocity = Vector2.up * this.JumpStrength;
            this.Anim.SetBool("Run", false);
            gameObject.GetComponent<AudioSource>().Play();
        }

        if (Input.GetKey(KeyCode.Space) && this.IsJumping)
        {
            if (this.JumpTimeCounter > 0.0f)
            {
                this.Rb.velocity = Vector2.up * this.JumpStrength;
                this.JumpTimeCounter -= Time.deltaTime;
            }

            else
            {
                this.IsJumping = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            this.IsJumping = false;
        }



        if (Input.GetKeyDown(KeyCode.E))
        {
            if (this.Collided)
            {
                Destroy(this.Drop);
            }

        }

        if(UILevelName.color.a != 0.0f)
        {
            // The name of the level slowly fades out every frame.
            var textColor = UILevelName.color;
            textColor.a -= Time.deltaTime;
            UILevelName.color = textColor;
            if(UIPanelImage.color.a != 0.0f)
            {
                // The panel that serves as a name also fades out every frame.
                var panelColor = UIPanelImage.color;
                panelColor.a -= Time.deltaTime;
                UIPanelImage.color = panelColor;
            }
        }

        if(this.OnConveyor)
        {
            var playerPos = this.gameObject.transform.position;
            playerPos.x -= ConveyorSpeed * Time.deltaTime;
            this.gameObject.transform.position = playerPos;
        }

    }

    // If something kills the player, the level is reloaded
    public void Die()
    {
        this.gameObject.transform.position = this.SpawnLocation.transform.position;
        this.Rb.velocity = Vector2.zero;
    }
}